using DataAnnotationsExtensions;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BeHapi.Models.Models
{
    public class UserDetails
    {
        [BsonId]

        [JsonConverter(typeof(StringEnumConverter))]
        [BsonRepresentation(BsonType.ObjectId)]

        public string _id { get; set; }
        //[StringLength(4, ErrorMessage = "Mininum Length 4", MinimumLength = 4)]
        public string Username { get; set; }

        public string Name { get; set; }
        public string Password { get; set; }
        
       // [Email]
        public string EMail { get; set; }

        [BsonExtraElements]
        public BsonDocument CatchAll { get; set; }

    }
}
