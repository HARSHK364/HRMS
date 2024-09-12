using FM.HRMS.DTO;
using FM.HRMS.DTO.Account;

using FM.HRMS.Models;
using FM.HRMS.Repository.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Threading.Tasks;

namespace HR_Management_Systems.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HRContoller : ControllerBase
    {
        private readonly IHRRepository _repo;
        private readonly UserManager<Company> userManager;
        public HRContoller(IHRRepository candidate)
        {
            _repo = candidate;
        }

       /* [HttpPost("RegisterAndUploadResume")]
        public async Task<IActionResult> Register([FromForm] ApplicantRegisterWithResumeDTO model)
        {
            if (model.ResumeFile == null || model.ResumeFile.Length == 0)
            {
                return BadRequest("Invalid file.");
            }

            if (!model.ResumeFile.ContentType.Equals("application/pdf", StringComparison.OrdinalIgnoreCase))
            {
                return BadRequest("Only PDF files are allowed.");
            }

            byte[] fileData;
            using (var memoryStream = new MemoryStream())
            {
                await model.ResumeFile.CopyToAsync(memoryStream);
                fileData = memoryStream.ToArray();
            }


            var filePath = Path.Combine("uploads", model.ResumeFile.FileName);
            if (!Directory.Exists("uploads"))
            {
                Directory.CreateDirectory("uploads");
            }


            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await model.ResumeFile.CopyToAsync(stream);
            }

            var applicantToAdd = new Applicant
            {
                Firstname = model.Firstname,
                Lastname = model.Lastname,
                Experience = model.Experience,
                Highest_Qualification = model.Highest_Qualification,
                Email = model.Email,
                Current_Address = model.Current_Address,
                Pincode = model.Pincode,
                City = model.City,
                PhoneNumber = model.PhoneNumber,
                PreviousCompanyName = model.PreviousCompanyName,
                CurrentCompanyName = model.CurrentCompanyName,
                Platform = model.Platform,
                ResumeData = fileData,
                JobId = model.JobId,

            };
            var createdApplicant = _repo.CreateCandidate(applicantToAdd);

            return Created("Success", new
            {
                filePath,
                message = "Applicant registered and resume uploaded successfully.",
                applicantName = $"{model.Firstname} {model.Lastname}",

            });

        }*/


        [HttpPost("JobPositions")]
        public async Task<IActionResult> JobPositions([FromForm] AddJobDTO model)
        {
            var AddJob = new AddJob
            {
                JobRole = model.JobRole,
                Experience = model.Experience,
                JobDescription = model.JobDescription,
                Address = model.Address
            };
            return Created("Success", _repo.Job(AddJob));

        }


        [HttpPost("AddRounds")]
        public async Task<IActionResult> Round([FromBody]RoundsDTO RDT) 
        {
            var Round = new Round
            {
                JobId = RDT.JobId,
                RoundName = RDT.RoundName,
            };
            return Created("success", _repo.AddRound(Round));   
        
        }


        [HttpGet("GetAllJobs")]
        public async Task<ActionResult<IEnumerable<AddJob>>> GetAllJobs()
        {
            var jobs = await _repo.GetAllJobsAsync();
            return Ok(jobs);
        }


        [HttpGet("GetApplicantsByJobId")]
        public async Task<IActionResult> GetApplicantsByJobId(int jobId)
        {
            var applicantsWithJobDetails = await _repo.GetApplicantsByJobIdAsync(jobId);

            return Ok(applicantsWithJobDetails);
        }


        [HttpGet("GetAllRoundsByJobRole")]
        public async Task<IActionResult> RoundsByJobRole(string jobRole)
        {
            if (string.IsNullOrEmpty(jobRole))
            {
                return BadRequest("Job role is required");
            }

            var rounds = await _repo.GetRoundsByJobRoleAsync(jobRole);
            if (rounds == null || !rounds.Any())
            {
                return NotFound();
            }

            return Ok(rounds);
        }




        /*    [HttpGet]
                   public async Task<IActionResult> Register()
                   {
                       var jobRoles = await _repo.GetAllJobRolesAsync();
                       var model = new ApplicantRegisterWithResumeDTO
                       {
                           JobRole = jobRoles.Select(jr => new SelectListItem
                           {
                               Value = jr,
                               Text = jr
                           }).ToList()
                       };
                       return Ok(model);
                   }*/




        /*[HttpPost("CompanyRegister")]
    public async Task<IActionResult> CompanyRegister(CompanyRegisterDTO model)
    {
        var AddCompany = new Company
        {
            UserName = model.UserName,
            PhoneNumber = model.PhoneNumber,
            Companyname = model.Companyname,
            Address = model.Address
        };
        *//*return Created("Success", _repo.CreateCompany(AddCompany));*//*
        var result = await userManager.CreateAsync(AddCompany, model.Password);
        if (!result.Succeeded)
        {
            return BadRequest(result.Errors);
        }

        return Ok("Registered Successfully!");
    }
}
*/

        /*     [HttpPost("Applicant_Rounds")]
             public async Task<IActionResult> ApplicantRound(ApplicantRoundsDTO model)
             {
                 var AddStatus = new ApplicantRounds
                 {
                     Feedback = model.Feedback,
                     Current_Status = model.Current_Status
                 };
                 return Created("Success", _repo.ApplicantRound(AddStatus));

             }

             [HttpPost("CompanyLogin")]
             public async Task<IActionResult> LogIn([FromBody] CompanyLoginDTO login)
             {
                 var log = await _repo.GetByUsernameAndPasswordAsync(login.UserName, login.Password);

                 if (log == null)
                 {
                     return Unauthorized(new { message = "Invailid Username or password." });

                 }
                 return Ok(new
                 {
                     Id = log.Id,
                     Companyname = log.Companyname,
                     Address = log.Address
                 });
             }*/



        /*[HttpPost("Rounds")]
        public async Task<IActionResult> Rounds(RoundsDTO model)
        {
            var AddRound = new Rounds
            {
                RoundName = model.RoundName
            };
            return Created("Success", _repo.CreateRounds(AddRound));
        }*/

        /*  [HttpPost("InterviewSchedules")]
          public async Task<IActionResult> InterviewSchedules(InterviewDTO model)
          {
              var AddSchedule = new InterviewSchedules
              {
                  InterviewStatus = model.InterviewStatus
              };
              return Created("Success", _repo.Interview(AddSchedule));
          }*/

        /*
                [HttpPost("RoundTypes")]
                public async Task<IActionResult> RoundType(RoundTypeDTO model)
                {
                    var AddRoundType = new RoundType
                    {
                        RoundName = model.RoundName
                    };
                    return Created("Success", _repo.CreateRoundType(AddRoundType));
                }*/

    }
}

