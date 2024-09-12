using FM.HRMS.DTO.Account1;
using FM.HRMS.Models;
using HR_Management_Systems.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace FM.HRMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Account1Controller : ControllerBase
    {
        private readonly JWTServices _jwtServices;
        private readonly SignInManager<Company> signInManager;
        private readonly UserManager<Company> userManager;
        private readonly HRDBContext context;



        public Account1Controller(SignInManager<Company> signInManager, UserManager<Company> userManager, HRDBContext context, JWTServices _jwtServices)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.context = context;
            this._jwtServices = _jwtServices;
        
        }
        [HttpPost("Login")]

        public async Task<ActionResult<CompanyUserDTO>> Login(LoginDTO company)
        {
            var company1 = await userManager.FindByNameAsync(company.UserName);
            if (company == null)
            {
                return Unauthorized("Invalid username or password ");
            }
            var result = await signInManager.CheckPasswordSignInAsync(company1, company.Password, false);
            if (!result.Succeeded)
                return Unauthorized(" Invalid username or password");

            return CreateApplicationDTO(company1);


        }

        [HttpPost("Company Register")]
        public async Task<ActionResult> RegisterCompany(CompanyRegisterDTO detail)
        {
            if (await context.Company.AnyAsync(c => c.CompanyCIN.ToLower() == detail.CompanyCIN.ToLower()))
            {
                return BadRequest("Already Exists");
            }

            var addcompany = new Company
            {
                CompanyCIN = detail.CompanyCIN,
                CompanyName = detail.CompanyName,
                UserName = detail.UserName,
                Location = detail.Location,
                Email = detail.Email,
                PhoneNumber = detail.Phone,
                EmailConfirmed = true

            };
            var result = await userManager.CreateAsync(addcompany, detail.Password);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return Ok("Registered Successfully!");
        }


        private async Task<bool> CheckCINexists(string companyCIN, HRDBContext context)
        {
            bool cinExists = await context.Company.AnyAsync(c => c.CompanyCIN == companyCIN);
            return cinExists;
        }
        private CompanyUserDTO CreateApplicationDTO(Company company)
        {
            return new CompanyUserDTO
            {
                CompanyName = company.CompanyName,
                CompanyCIN = company.CompanyCIN,
                JWT = _jwtServices.CreateJWT(company)

            };
        }
    }
}
