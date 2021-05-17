using BeHapi.Interfaces;
using BeHapi.Interfaces.Interfaces;
using BeHapi.Models.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeHapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoadDataController : ControllerBase
    {

        //Dependency Injection
        private readonly IBackingStoreService _backingStoreService;
        public LoadDataController(IBackingStoreService backingStoreService)
        {
            _backingStoreService = backingStoreService;
        }

        [Authorize]
        [HttpGet]
        [Route("LoadProductsData")]
        public ActionResult LoadProduct()
        {
            ResponseOutput response = new ResponseOutput();
            try
            {
                response = _backingStoreService.LoadAPIData();

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
                return StatusCode(500, new ResponseOutput
                {
                    Status = false,
                    Message = ex.Message
                });
            }
        }
    }
}
