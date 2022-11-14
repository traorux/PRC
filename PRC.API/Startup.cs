using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using PRC.CORE.Media.Call;
using PRC.CORE.Repository;
using PRC.CORE.Service;
using PRC.DATA;
using PRC.DATA.Repository;
using PRC.MEDIA.OXE;
using PRC.PROCESS;
using PRC.PROCESS.Hubs;
using PRC.SERVICE;
using System;
using System.Text;
using System.Threading.Tasks;

namespace PRC.COEUR
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Inject Dbcontext
            services.AddDbContext<PRCDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DbConnectionString"), x => x.MigrationsAssembly("PRC.DATA")));
            services.AddControllers().AddJsonOptions(option =>
            {
                option.JsonSerializerOptions.PropertyNameCaseInsensitive = false;
                option.JsonSerializerOptions.PropertyNamingPolicy = null;
            });//, ServiceLifetime.Transient
            services.AddSingleton<IMediaCall, MediaOXE>();
            services.AddScoped<IMediaService, MediaService>();
            services.AddScoped<IUserService, UserService>();
            services.AddTransient<ICallRepository, CallRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IStateRepository, StateRepository>();
            services.AddScoped<IDataCustomRepository, DataCustomRepository>(); 
            services.AddScoped<IRequestRepository, RequestRepository>();
            services.AddScoped<IHistoryRepository, HistoryRepository>();
            services.AddScoped<IUserRepository, UserRepository> ();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IExtensionRepository, ExtensionRepository>();
            services.AddHostedService<ServiceBackground>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PRC.API", Version = "v1" });
            });

            // AutoMapper
            //services.AddAutoMapper(typeof(Startup));
            //services.AddScoped<IMediaService, MediaService>();
            services.AddAutoMapper(typeof(Startup));
            // Jwt
            var key = Encoding.ASCII.GetBytes(Configuration.GetValue<string>("AppSettings:Secret"));

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.Events = new JwtBearerEvents
                {
                    OnTokenValidated = context =>
                    {
                        var userService = context.HttpContext.RequestServices.GetRequiredService<IUserService>();
                        var userId = int.Parse(context.Principal.Identity.Name);
                        var user = userService.GetUserById(userId);
                        if (user == null)
                        {
                            // return unauthorized if user no longer exists
                            context.Fail("Unauthorized");
                        }
                        return Task.CompletedTask;
                    }
                };
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });


            services.AddSignalR(hubOptions =>
            {
                hubOptions.EnableDetailedErrors = true;
            });
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.WithOrigins("http://localhost:4200", "https://localhost:4200")
                        .AllowAnyHeader()
                        .WithMethods("GET", "POST", "PUT")
                        .AllowCredentials();
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PRC.COEUR v1"));
            }


            //app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCors();
            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<SignalR>("/signalr");
            });
        }
    }

}
