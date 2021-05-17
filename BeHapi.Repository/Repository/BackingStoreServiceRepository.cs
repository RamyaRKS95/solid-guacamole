using BeHapi.Interfaces.Interfaces;
using BeHapi.Models.Models;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeHapi.Repository.Repository
{
    public class BackingStoreServiceRepository : IBackingStoreServiceRepository
    {
        public string Insert(List<Products> jsonData)
        {
            string message = string.Empty;
            try
            {
                const string connectionString = "mongodb://localhost:27017";

                // Create a MongoClient object by using the connection string
                var client = new MongoClient(connectionString);

                //Use the MongoClient to access the server
                var database = client.GetDatabase("BeHapi");

                //get mongodb collection
                var collection = database.GetCollection<Products>("Products");

                if (jsonData != null)
                {
                    collection.InsertMany(jsonData);
                }
            }
            catch(Exception ex)
            {
                message = ex.Message;
            }

            return message;
        }
    }
}
