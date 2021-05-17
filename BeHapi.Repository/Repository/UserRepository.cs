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
    public class UserRepository : IUserRepository
    {
        public string InsertUserDetails(string username, string name, string email, string password)
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
                var collection = database.GetCollection<UserDetails>("UserDetails");

                List<UserDetails> user = collection.Find(x => x.Username == username).ToList();

                if(user.Count > 0)
                {
                    message = "Username Already Exists !! Please enter another UserName !!";
                }
                else
                {
                    collection.InsertOne(new UserDetails { Username = username , Name = name, EMail = email, Password = password});
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }

            return message;
        }

        public string ValidateUserAccess(string username, string password)
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
                var collection = database.GetCollection<UserDetails>("UserDetails");

                var filter = Builders<UserDetails>.Filter.Eq(x => x.Username, username) &
                             Builders<UserDetails>.Filter.Eq(x => x.Password, password);

                List<UserDetails> user = collection.Find(filter).ToList();
                if (user.Count == 0)
                {
                    List<UserDetails> userExists = collection.Find(x => x.Username == username).ToList();

                    if (userExists.Count == 0)
                        message = "Given user doesn't Exist !!";
                    else
                        message = "Please Enter Correct password !!";
                }

            }
            catch (Exception ex)
            {
                message = ex.Message;
            }

            return message;
        }
    }
}
