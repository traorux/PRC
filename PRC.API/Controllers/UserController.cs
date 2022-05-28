using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PRC.API.Resources;
using PRC.API.Validation;
using PRC.CORE.Model;
using PRC.CORE.Service;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PRC.API.Controllers{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IMapper _mapper;
        private readonly Microsoft.Extensions.Configuration.IConfiguration _config;

        public UserController(IUserService userService, IMapper mapper,
            Microsoft.Extensions.Configuration.IConfiguration config)
        {
            this.userService = userService;
            _mapper = mapper;
            _config = config;
        }


        //[HttpPost]
        //public async Task<User> CreerUser(User user, string password)
        //{
        //    return await userService.CreateUser(user, password);
        //}


        //[HttpPost]
        //public void ModifierUser(User user, string password = null)
        //{
        //    userService.UpdateUserParam(user, password);
        //}

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate(UserResource userResource)
        {
            var user = await userService.Authenticate(userResource.Username, userResource.Password);
            if (user == null) return BadRequest(new { message = "Username or password is incorrect" });

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config.GetValue<string>("AppSettings:Secret"));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                 {
                    new Claim(ClaimTypes.Name, user.IdUser.ToString())
                 }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            return Ok(new
            {
                Id = user.IdUser,
                Username = user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserEmail = user.UserEmail,
                DeviceNumber = user.DeviceNumber,
                Token = tokenString
            });
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register(UserResource userResource)
        {
            // validation
            var validation = new SaveUserResourceValidation();
            var validationResult = await validation.ValidateAsync(userResource);
            if (!validationResult.IsValid) return BadRequest(validationResult.Errors);
            var user = _mapper.Map<UserResource, User>(userResource);
            // mappage
            var userSave = await userService.CreateUser(user, userResource.Password);
            //send tocken 
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config.GetValue<string>("AppSettings:Secret"));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                 {
                    new Claim(ClaimTypes.Name, user.IdUser.ToString())
                 }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            return Ok(new
            {
                Id = user.IdUser,
                Username = user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserEmail = user.UserEmail,
                Token = tokenString
            });

        }

    }
}
