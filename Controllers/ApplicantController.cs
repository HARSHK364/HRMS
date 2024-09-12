using FM.HRMS.DTO;
using FM.HRMS.Models;
using FM.HRMS.Repository.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace FM.HRMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantController : ControllerBase
    {
        private readonly IApplicantRepository _repo;
        private readonly UserManager<Company> userManager;
        public ApplicantController(IApplicantRepository candidate)
        {
            _repo = candidate;
        }


        [HttpPost("RegisterAndUploadResume")]
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
                HighestQualification = model.Highest_Qualification,
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


        }

        [HttpGet("GetAllJobs")]
        public async Task<ActionResult<IEnumerable<AddJob>>> GetAllJobs()
        {
            var jobs = await _repo.GetAllJobsAsync();
            return Ok(jobs);
        }




    }
}
