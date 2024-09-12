using System.ComponentModel.DataAnnotations;

namespace FM.HRMS.DTO.Account1
{
    public class LoginDTO
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
