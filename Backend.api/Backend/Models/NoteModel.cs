using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Backend.Models
{
    public class NoteModel
    {
        [BsonId]

        [BsonRepresentation(BsonType.ObjectId)]
        public string? id { get; set; }

        public string name { get; set; }

        public string description { get; set; }
    }
}
