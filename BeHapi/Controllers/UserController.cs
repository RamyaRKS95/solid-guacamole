using BeHapi.Interfaces;
using BeHapi.Models.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeHapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        //Dependency Injection
        private readonly IUserService _userService;
        private readonly IConfiguration _config;
        public UserController(IConfiguration config, IUserService userService)
        {
            _config = config;
            _userService = userService;
        }

        [HttpPost]
        [Route("ValidateLoginUser")]
        public ActionResult LoginUser(string username, string password)
        {
            UserOutputResponse response = new UserOutputResponse();
            try
            {
                response =  _userService.LoginUser(username, password);

                if(response.Status)
                {
                    return Ok(response);
                }
                else
                {
                    return StatusCode(403, response);
                }
            }
            catch(Exception ex)
            {
                return StatusCode(500, new UserOutputResponse
                                           { Status = false,
                                             Message = ex.Message});
            }
            
        }

        [HttpPost]
        [Route("CreateNewUser")]
        public ActionResult RegisterUser(string username, string name, string email, string password)
        {
            UserOutputResponse response = new UserOutputResponse();
            try
            {
                response = _userService.RegisterUser(username, name, email, password);

                if (response.Status)
                {
                    return Ok(response);
                }
                else
                {
                    return StatusCode(403, response);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new UserOutputResponse
                {
                    Status = false,
                    Message = ex.Message
                });
            }
        }
    }
}
