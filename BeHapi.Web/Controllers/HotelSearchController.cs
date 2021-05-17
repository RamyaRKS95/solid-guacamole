using BeHapi.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BeHapi.Web.BusinessLayer;

namespace BeHapi.Web.Controllers
{
    public class HotelSearchController : Controller
    {
        // GET: HotelSearchController
        public ActionResult Index()
        {
            string msg = string.Empty;
            List<Products> productData = new List<Products>();

            HotelSearchBL hotelSearchBLObj = new HotelSearchBL();
            (productData,msg) = hotelSearchBLObj.FindByName();


            return View(productData);
        }

        [HttpPost]
        public ActionResult Index(string HotelName)
        {
            string msg = string.Empty;
            List<Products> productData = new List<Products>();

            HotelSearchBL hotelSearchBLObj = new HotelSearchBL();
            (productData, msg) = hotelSearchBLObj.FindByName(HotelName);

            return View(productData);
        }
    }
}
