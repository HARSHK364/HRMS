using Microsoft.AspNetCore.Http;

namespace FM.HRMS.DTO.Account
{
    public class ResumeUploadDto
    {
        public int ApplicantId { get; set; } 
        public IFormFile File { get; set; }  
        public string ApplicantName { get; set; } 
        public int JobId { get; set; } 
    }
}
