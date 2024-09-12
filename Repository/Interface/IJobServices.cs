using FM.HRMS.DTO.Trynew;
using FM.HRMS.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FM.HRMS.Repository.Interface
{
    public interface IJobServices
    {
        Task<JobApplicantsAndRoundsDTO> GetApplicantsAndRoundsByJobIdRoundid(int jobId, int roundId);
        Task<bool> MoveApplicantsToNextRoundAsync(int jobId, int roundId);
    }
}
