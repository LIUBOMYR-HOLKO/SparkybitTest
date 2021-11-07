using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SparkybitTestTask.Model
{
    [BsonIgnoreExtraElements]
    public class Logs
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonElement("date-time")]
        public DateTime DateTime { get; set; }
        [BsonElement("level")]
        public Level Level { get; set; }
        [BsonElement("title")]
        public string Title { get; set; }
        [BsonElement("description")]
        public string Description { get; set; }
    }
}
