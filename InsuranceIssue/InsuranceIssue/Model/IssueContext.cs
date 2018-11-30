using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace InsuranceIssue.Model
{
    public class IssueContext : IIssueContext
    {
        private readonly IMongoDatabase _db;

        public IssueContext(IOptions<Settings> options)
        {
            var client = new MongoClient(options.Value.ConnectionString);
            _db = client.GetDatabase(options.Value.Database);
        }

        public IMongoCollection<Issue> Issues => _db.GetCollection<Issue>("Issues");
    }
}