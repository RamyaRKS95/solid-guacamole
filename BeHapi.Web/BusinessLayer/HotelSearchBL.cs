using BeHapi.Web.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BeHapi.Web.BusinessLayer
{
    public class HotelSearchBL
    {
        public (List<Products>, string) FindByName(string name="")
        {
            string message = string.Empty;
            string apiURL = string.Empty;
            List<Products> data = new List<Products>();
            try
            {
                apiURL = "https://sncdn.com/hapi/products.json";
                (data, message) = ReadDataFromAPI(apiURL);

                if(!string.IsNullOrEmpty(name))
                {
                    data = data.Where(x => x.Name.ToLower().Contains(name.ToLower())).ToList();
                }

            }
            catch (Exception ex)
            {
                message = ex.Message;

            }
            return (data,message);
        }

        public (List<Products>, string) ReadDataFromAPI(string apiURL)
        {
            string message = string.Empty;
            string jsonData = string.Empty;
            List<Products> productData = new List<Products>();

            try
            {

                using (var w = new WebClient())
                {

                    jsonData = w.DownloadString(apiURL);

                    if (!string.IsNullOrEmpty(jsonData))
                        productData = JsonConvert.DeserializeObject<List<Products>>(jsonData);
                }

            }
            catch (Exception ex)
            {
                message = ex.Message;

            }
            return (productData, message);
        }

    }
}
