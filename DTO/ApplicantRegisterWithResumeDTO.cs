using FM.HRMS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FM.HRMS.DTO
{
    public class ApplicantRegisterWithResumeDTO
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Experience { get; set; }
        public string Highest_Qualification { get; set; }
        public string Email { get; set; }
        public string Current_Address { get; set; }
        public string Pincode { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }
        public string Platform { get; set; }
        public string PreviousCompanyName { get; set; }
        public string CurrentCompanyName { get; set; }
        public IFormFile ResumeFile { get; set; }
        public int JobId { get; set; }

    }

}
