using System.Collections.Generic;
using System.Threading.Tasks;
using InsuranceIssue.Model;

namespace InsuranceIssue.Repository
{
    public interface IIssueRepository
    {
        Task<IEnumerable<Issue>> GetAllIssues();
        Task<Issue> GetIssue(string name);
        Task Create(Issue issue);
        Task<bool> Update(Issue issue);
        Task<bool> Delete(string name);
    }
}