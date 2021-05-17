using BeHapi.Interfaces.Interfaces;
using BeHapi.Models.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeHapi.Repository.Repository
{
    public class HotelSearchServiceRepository : IHotelSearchServiceRepository
    {
        public HotelSearchResponse GetDataByLocation(string location)
        {
            HotelSearchResponse output = new HotelSearchResponse();

            try
            {
                const string connectionString = "mongodb://localhost:27017";

                // Create a MongoClient object by using the connection string
                var client = new MongoClient(connectionString);

                //Use the MongoClient to access the server
                var database = client.GetDatabase("BeHapi");

                //get mongodb collection
                var collection = database.GetCollection<Products>("Products");

                output.Data = collection.Find(x => x.LocationPath.ToLower().Contains(location.ToLower())).ToList();

                output.Status = true;
            }
            catch (Exception ex)
            {
                output.Message = ex.Message;
                output.Status = false;
            }

            return output;
        }

        public HotelSearchResponse GetDataByName(string name)
        {
            HotelSearchResponse output = new HotelSearchResponse();

            try
            {
                const string connectionString = "mongodb://localhost:27017";

                // Create a MongoClient object by using the connection string
                var client = new MongoClient(connectionString);

                //Use the MongoClient to access the server
                var database = client.GetDatabase("BeHapi");

                //get mongodb collection
                var collection = database.GetCollection<Products>("Products");

                output.Data = collection.Find(x => x.Name.ToLower().Contains(name.ToLower())).ToList();

                output.Status = true;
            }
            catch (Exception ex)
            {
                output.Message = ex.Message;
                output.Status = false;
            }

            return output;
        }
    }
}
