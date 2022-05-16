using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using PRC.API.Hubs;
using PRC.API.serviceTest;
using PRC.CORE.Media.Call;
using PRC.MEDIA.OXE;
using Microsoft.EntityFrameworkCore;
using PRC.PROCESS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PRC.SERVICE.Media;
using PRC.DATA;
using PRC.CORE.Service;
using PRC.CORE.Repository;
using PRC.DATA.Repository;

namespace PRC.API
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
            options.UseSqlServer(Configuration.GetConnectionString("DbConnectionString"), x => x.MigrationsAssembly("PRC.DATA")), ServiceLifetime.Transient);
            services.AddControllers();
            services.AddSingleton<IMediaCall, MediaOXE>();
            services.AddScoped<ICallService, CallService>();
            services.AddScoped<ICallRepository, CallRepository>();
            services.AddSignalR(hubOptions =>
            {
                hubOptions.EnableDetailedErrors = true;
            });
          
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PRC.API", Version = "v1" });
            });
            services.AddRazorPages();
            services.AddSignalR(hubOptions =>
            {
                hubOptions.EnableDetailedErrors = true;
            });

            services.AddHostedService<ServiceBackground>();

           

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
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PRC.API v1"));
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCors();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<SignalR>("/signalr");
            });
        }
    }

}
