using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using InsuranceIssue.Model;

namespace InsuranceIssue.Repository
{
    public class IssueRepository : IIssueRepository
    {
        private readonly IIssueContext _context;

        public IssueRepository(IIssueContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Issue>> GetAllIssues()
        {
            return await _context
                            .Issues
                            .Find(_ => true)
                            .ToListAsync();
        }

        public Task<Issue> GetIssue(string Carrier)
        {
            FilterDefinition<Issue> filter = Builders<Issue>.Filter.Eq(m => m.Carrier, Carrier);

            return _context
                    .Issues
                    .Find(filter)
                    .FirstOrDefaultAsync();
        }
       
        public async Task Create(Issue issue)
        {
            await _context.Issues.InsertOneAsync(issue);
        }

        public async Task<bool> Update(Issue issue)
        {
            ReplaceOneResult updateResult =
                await _context
                        .Issues
                        .ReplaceOneAsync(
                            filter: g => g.Id == issue.Id,
                            replacement: issue);

            return updateResult.IsAcknowledged
                    && updateResult.ModifiedCount > 0;
        }

        public async Task<bool> Delete(string Carrier)
        {
            FilterDefinition<Issue> filter = Builders<Issue>.Filter.Eq(m => m.Carrier, Carrier);

            DeleteResult deleteResult = await _context
                                                .Issues
                                                .DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }
    }
}