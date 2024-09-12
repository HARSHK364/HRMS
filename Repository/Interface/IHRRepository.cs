using FM.HRMS.DTO;
using FM.HRMS.Models;
/*using FM.HRMS.Models.Old;*/
using Microsoft.AspNetCore.Mvc;

using System.Collections.Generic;

using FM.HRMS.Models.Latest;
using System.Threading.Tasks;

namespace FM.HRMS.Repository.Interface
{
    public interface IHRRepository
    {
        
        AddJob Job(AddJob job_Positions);
        Task<IEnumerable<AddJob>> GetAllJobsAsync();
        Task<List<AppliedRoleDTO>> GetApplicantsByJobIdAsync(int jobId);
        Round AddRound(Round Round);
        Task<IEnumerable<JobRoundDTO>> GetRoundsByJobRoleAsync(string jobRole);
       /* Task<List><InRoundDTO> GetListOfAllApplicantByRoundAndJobId(int jobId,int RoundId);*/

        /*        Task<IEnumerable<string>> GetAllJobRolesAsync();*/
        /*  Rounds CreateRounds(Rounds rounds);
          RoundType CreateRoundType(RoundType roundtypes);
          Task<Company> GetByUsernameAndPasswordAsync(string username, string password);*/
        /*        void UpdateResumePath(int applicantId, string resumePath);*/
        /*        Company CreateCompany(Company company);*/
        /*        ApplicantRounds ApplicantRound(ApplicantRounds applicantround);
                InterviewSchedules Interview(InterviewSchedules interviewSchedules);

        */

    }
}




