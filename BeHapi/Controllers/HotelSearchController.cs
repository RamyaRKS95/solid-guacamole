using BeHapi.Interfaces;
using BeHapi.Models.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BeHapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelSearchController : ControllerBase
    {

        //Dependency Injection
        private readonly IHotelSearchService _hotelSearchService;
        public HotelSearchController(IHotelSearchService hotelSearchService)
        {
            _hotelSearchService = hotelSearchService;
        }

        [HttpPost]
        [Route("HotelSearchByName")]
        public ActionResult SearchByName(string hotelName)
        {
            HotelSearchResponse searchResponse = new HotelSearchResponse();
            try
            {
                searchResponse = _hotelSearchService.FindByName(hotelName);

                if (searchResponse.Status)
                {
                    return Ok(searchResponse);
                }
                else
                {
                    return StatusCode(403, searchResponse);
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

        [HttpPost]
        [Route("HotelSearchByLocation")]
        public ActionResult SearchByLocation(string  location)
        {
            HotelSearchResponse searchResponse = new HotelSearchResponse(); ;
            try
            {
                searchResponse = _hotelSearchService.FindByLocation(location);

                if (searchResponse.Status)
                {
                    return Ok(searchResponse);
                }
                else
                {
                    return StatusCode(403, searchResponse);
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

        //// GET: api/<HotelSearchController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<HotelSearchController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<HotelSearchController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<HotelSearchController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<HotelSearchController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
