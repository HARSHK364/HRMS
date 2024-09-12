using System.ComponentModel.DataAnnotations;

namespace FM.HRMS.DTO.Account
{
    public class CompanyLoginDTO
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
