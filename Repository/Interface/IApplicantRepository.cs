using FM.HRMS.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FM.HRMS.Repository.Interface
{
    public interface IApplicantRepository
    {
        Applicant CreateCandidate(Applicant candidate);
        Task<IEnumerable<AddJob>> GetAllJobsAsync();
    }
}
