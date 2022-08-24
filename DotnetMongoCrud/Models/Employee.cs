using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetMongoCrud.Models
{
    public class Employee
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public decimal Salary { get; set; }
        //[BsonExtraElements]
        [BsonIgnoreIfNull]
        public IDictionary<string, string> Info { get; set; }
        public IList<IDictionary<string, string>> Demo { get; set; }
    }
}
