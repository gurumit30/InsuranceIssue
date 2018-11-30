using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using InsuranceIssue.Model;
using InsuranceIssue.Repository;

namespace InsuranceIssue.Controllers
{
    [Produces("application/json")]
    [Route("api/Issue")]
    public class IssueController : Controller
    {
        private readonly IIssueRepository _issueRepository;

        public IssueController(IIssueRepository issueRepository)
        {
            _issueRepository = issueRepository;
        }

        // GET: api/Issue
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return new ObjectResult(await _issueRepository.GetAllIssues());
        }

        // GET: api/Issue/name
        [HttpGet("{name}", Name = "Get")]
        public async Task<IActionResult> Get(string name)
        {
            var issue = await _issueRepository.GetIssue(name);

            if (issue == null)
                return new NotFoundResult();

            return new ObjectResult(issue);
        }

        // POST: api/Issue
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Issue issue)
        {
            await _issueRepository.Create(issue);
            return new OkObjectResult(issue);
        }

        // PUT: api/Issue/5
        [HttpPut("{name}")]
        public async Task<IActionResult> Put(string name, [FromBody]Issue issue)
        {
            var issueFromDb = await _issueRepository.GetIssue(name);

            if (issueFromDb == null)
                return new NotFoundResult();

            issue.Id = issueFromDb.Id;

            await _issueRepository.Update(issue);

            return new OkObjectResult(issue);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{name}")]
        public async Task<IActionResult> Delete(string name)
        {
            var issueFromDb = await _issueRepository.GetIssue(name);

            if (issueFromDb == null)
                return new NotFoundResult();

            await _issueRepository.Delete(name);

            return new OkResult();
        }
    }
}
