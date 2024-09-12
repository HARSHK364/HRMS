using FM.HRMS.Models;
using static FM.HRMS.Repository.JobServiceRepository;
using System.Collections.Generic;
using System.Threading.Tasks;
using FM.HRMS.DTO.Trynew;
using System.Linq;
using Microsoft.EntityFrameworkCore;

using FM.HRMS.Repository.Interface;

namespace FM.HRMS.Repository
{
    public class JobServiceRepository:IJobServices
    {
            private readonly HRDBContext _context;
        public JobServiceRepository(HRDBContext context)
        {
            _context = context;
        }
        public async Task<JobApplicantsAndRoundsDTO> GetApplicantsAndRoundsByJobIdRoundid(int jobId,int roundid)
        {
            
            var applicants = await _context.Applicant.Where(a => a.JobId == jobId) .ToListAsync();

            
            var rounds = await _context.Round .Where(r => r.RoundId == roundid)  .ToListAsync();

           
            var result = new JobApplicantsAndRoundsDTO
            {
                Applicants = applicants,
                Rounds = rounds
            };

            return result;
        }
        public async Task<bool> MoveApplicantsToNextRoundAsync(int jobId,int roundid)
            {
            var result = await GetApplicantsAndRoundsByJobIdRoundid(jobId, roundid);
            if (result == null)
                {
                    return false;
                }

                var nextRound = await GetNextRoundForJobAsync(jobId);

                if (nextRound == null)
                {
                    return false;
                }

                //foreach (var applicant in result.Applicants)
                //{
                //    Round.RoundId = nextRound.RoundId; // Assign next round
                //}

                await _context.SaveChangesAsync();
                return true;
            }

       
        private async Task<Round> GetNextRoundForJobAsync(int jobId)
            {
                return await _context.Round
                                     .Where(r => r.JobId == jobId)
                                     .OrderBy(r => r.RoundId)
                                     .Skip(1) 
                                     .FirstOrDefaultAsync();
            }
        }

    }

