using BeHapi.Interfaces;
using BeHapi.Interfaces.Interfaces;
using BeHapi.Models.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BeHapi.BusinessLogic.BusinessLogic
{
    public class UserBLService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _config;
        public UserBLService(IConfiguration config, IUserRepository userRepository)
        {
            _config = config;
            _userRepository = userRepository;
        }
        private readonly IUserService _userService;
        
        public UserOutputResponse LoginUser(string username, string password)
        {
            UserOutputResponse output = new UserOutputResponse();
            string message = string.Empty;
            try
            {
                message = _userRepository.ValidateUserAccess(username, password);


                output.Token = (string.IsNullOrEmpty(message)) ? getJWT(username) : string.Empty;
                output.Status = (string.IsNullOrEmpty(message)) ? true : false;
                    output.Message = (string.IsNullOrEmpty(message)) ? "Login Successfull !!" : message;
            }
            catch(Exception ex)
            {
                output.Status = false;
                output.Message = ex.Message;

            }
            return output;
        }

        public UserOutputResponse RegisterUser(string username, string name, string email, string password)
        {
            UserOutputResponse output = new UserOutputResponse();
            string message = string.Empty;
            try
            {
                message = _userRepository.InsertUserDetails(username, name, email, password);

                output.Status = (string.IsNullOrEmpty(message)) ? true : false;
                output.Message = (string.IsNullOrEmpty(message)) ? "User Registration Successfull !!" : message;

            }
            catch (Exception ex)
            {
                output.Status = false;
                output.Message = ex.Message;

            }
            return output;
        }

        public string getJWT(string UserName)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,UserName),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            var encodeToken = new JwtSecurityTokenHandler().WriteToken(token);


            return encodeToken;
        }
    }
}
