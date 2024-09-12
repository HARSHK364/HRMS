using FM.HRMS.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FM.HRMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly IJobServices _jobServices;
        private readonly HRDBContext context;

        public JobController(IJobServices jobServices,HRDBContext context)
        {
            _jobServices = jobServices;
            this.context = context;
        }

        [HttpGet("GetApplicantsAndRoundsByJobId")]
        public async Task<IActionResult> GetApplicantsAndRoundsByJobId(int jobId, int roundid)
        {
            var result = await _jobServices.GetApplicantsAndRoundsByJobIdRoundid(jobId,roundid);

            if (result.Applicants == null)
            {
                return NotFound("No applicants found for the given job ID.");
            }

            return Ok(result);
        }

    }
}
