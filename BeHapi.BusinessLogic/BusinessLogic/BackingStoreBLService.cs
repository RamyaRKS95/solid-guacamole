using BeHapi.Interfaces;
using BeHapi.Interfaces.Interfaces;
using BeHapi.Models;
using BeHapi.Models.Models;
using BeHapi.Repository.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace BeHapi.BusinessLogic.BusinessLogic
{
    public class BackingStoreBLService : IBackingStoreService
    {
        //public void Insert() { }
        //public void Update() { }
        //public void Get() { }
        //public Task GetManyAsync() { throw new NotImplementedException(); }
        //public void Delete() { }

        private readonly IBackingStoreServiceRepository _backingStoreRepository;
        public BackingStoreBLService(IBackingStoreServiceRepository backingStoreRepository)
        {
            _backingStoreRepository = backingStoreRepository;
        }
        public ResponseOutput LoadAPIData()
        {
            ResponseOutput output = new ResponseOutput();
            string message = string.Empty;
            string apiURL = string.Empty;
            List<Products> jsonData = new List<Products>();
            try
            {
                apiURL = "https://sncdn.com/hapi/products.json";
                (jsonData, message) = ReadDataFromAPI(apiURL);
                message = _backingStoreRepository.Insert(jsonData);

                output.Status = (string.IsNullOrEmpty(message)) ? true : false;
                output.Message = (string.IsNullOrEmpty(message)) ? "DataLoad Successfull !!" : message;

            }
            catch (Exception ex)
            {
                output.Status = false;
                output.Message = ex.Message;

            }
            return output;

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

                    if(!string.IsNullOrEmpty(jsonData))
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
