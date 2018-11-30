using MongoDB.Driver;

namespace InsuranceIssue.Model
{
    public interface IIssueContext
    {
        IMongoCollection<Issue> Issues { get; }
    }
}