using FM.HRMS.Models;
using FM.HRMS.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FM.HRMS.Repository
{
    public class ApplicantRepository: IApplicantRepository
    {
        private readonly HRDBContext _usercontext;
        public ApplicantRepository(HRDBContext context)
        {
            _usercontext = context;
        }
        public Applicant CreateCandidate(Applicant candidate)
        {
            _usercontext.Add(candidate);
            _usercontext.SaveChanges();
            return candidate;
        }
        public async Task<IEnumerable<AddJob>> GetAllJobsAsync()
        {
            return await _usercontext.JobPositions.ToListAsync();
        }
    }
}
