using Azure.Messaging;
using FM.HRMS.DTO;

using FM.HRMS.Models;
/*using FM.HRMS.Models.Old;*/

using FM.HRMS.Models.Latest;
using FM.HRMS.Repository.Interface;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace FM.HRMS.Repository
{
    public class HRrepository : IHRRepository
    {
        private readonly HRDBContext _usercontext;
        public HRrepository(HRDBContext context)
        {
            _usercontext = context;
        }
        public Applicant CreateCandidate(Applicant candidate)
        {
            _usercontext.Add(candidate);
            _usercontext.SaveChanges();
            return candidate;
        }

        public AddJob Job(AddJob job_Positions)
        {
            _usercontext.Add(job_Positions);
            _usercontext.SaveChanges();
            return job_Positions;
        }
        public async Task<IEnumerable<AddJob>> GetAllJobsAsync()
        {
            return await _usercontext.JobPositions.ToListAsync();
        }

    
        public async Task<List<AppliedRoleDTO>> GetApplicantsByJobIdAsync(int jobId)
        {
            
            var result = await (from applicant in _usercontext.Applicant
                                join jobpositions in _usercontext.JobPositions
                                on applicant.JobId equals jobpositions.JobId
                                where jobpositions.JobId == jobId
                                select new AppliedRoleDTO
                                {
                                    ApplicantId = applicant.Applicantid,
                                    ApplicantName = applicant.Firstname + " " + applicant.Lastname,
                                    Role = jobpositions.JobRole,
                                }).ToListAsync();

            return result;
        }
        public Round AddRound(Round Round)
        {   
            _usercontext.Add(Round);
            _usercontext.SaveChanges();
            return Round;
        }
        public async Task<IEnumerable<JobRoundDTO>> GetRoundsByJobRoleAsync(string jobRole)
        {
            var query = from job in _usercontext.JobPositions
                        join round in _usercontext.Round on job.JobId equals round.JobId
                        where job.JobRole == jobRole
                        select new JobRoundDTO
                        {
                            /*JobRole = job.JobRole,*/
                            RoundId = round.RoundId,
                            RoundName = round.RoundName
                        };

            return await query.ToListAsync();
        }





        /*   public async Task<IActionResult> AddRounds(int JobId, List<string> roundNames)
           {
               foreach (var roundName in roundNames)
               {
                   _usercontext.Round.Add(new Round { JobId = JobId, RoundName = roundName });
               }

               await _usercontext.SaveChangesAsync();
               return JsonResult("JobDetails", new { id = JobId });
           }*/



        /*        public Company CreateCompany(Company company)
                {
                    _usercontext.Add(company);
                    _usercontext.SaveChanges();
                    return company;
                }
            */
        /*  public Rounds CreateRounds(Rounds rounds)
          {
              _usercontext.Add(rounds);
              _usercontext.SaveChanges();
              return rounds;
          }*/
        /*        public RoundType CreateRoundType(RoundType roundtypes)
                {
                    _usercontext.Add(roundtypes);
                    _usercontext.SaveChanges();
                    return roundtypes;
                }
                public async Task<Company> GetByUsernameAndPasswordAsync(string username, string password)
                {
                    return await _usercontext.Set<Company>()
                        .FirstOrDefaultAsync(s => s.UserName == username && s.Password == password);*/
    }
    /* public void UpdateResumePath(int applicantId, string resumePath)
     {
         var applicant = _usercontext.Set<Applicant>().FirstOrDefault(a => a.Applicantid == applicantId);
         if (applicant != null)
         {
             applicant.Resumelink = resumePath;
             _usercontext.SaveChanges();
         }
     }*/
    /*    public ApplicantRounds ApplicantRound(ApplicantRounds applicantround)
     {
         _usercontext.Add(applicantround);
         _usercontext.SaveChanges();
         return applicantround;
     }*/
    /*     public InterviewSchedules Interview(InterviewSchedules interviewSchedules)
         {
             _usercontext.Add(interviewSchedules);
             _usercontext.SaveChanges();
             return interviewSchedules;
         }*/
    /*   public async Task<List<string>> GetAllJobRolesAsync()
        {
            // Retrieve distinct job roles from the database
            var jobRoles = await _usercontext.JobPositions
                .Select(j => j.JobRole)
                .Distinct()
                .ToListAsync();

            return jobRoles;
        }*/


/*
        public async Task<List<AppliedRoleDTO>> GetApplicantsByJobIdAsync(int jobId)
        {
            // Join Applicant and Job tables and filter by JobId
            var result = await (from applicant in _usercontext.Applicant
                                join jobpositions in _usercontext.JobPositions
                                on applicant.JobId equals jobId
                                where jobId == jobId
                                select new AppliedRoleDTO
                                {
                                    ApplicantId = applicant.Applicantid,
                                    ApplicantName = applicant.Firstname + " " + applicant.Lastname,
                                    Role = jobpositions.JobRole,
                                }).ToListAsync();

            return result;
        }*/

        /* Task<IEnumerable<Applicant>> IRepository.GetApplicantsByJobIdAsync(int JobId)
         {
             throw new System.NotImplementedException();
         }*/

       /* public async Task<IEnumerable<Applicant>> GetApplicantsByJobIdAsync(int JobId)
        {
            return await _usercontext.Applicant.Where(a => a.JobId == JobId).ToListAsync();
        }
*/
}

