using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace InsuranceIssue.Model
{
    public class Issue
    {
        [BsonId]
        public ObjectId Id { get; set; }

        public string Carrier { get; set; }

        public string TYPE { get; set; }

    }
}