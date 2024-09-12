using FM.HRMS.Models;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.ComponentModel.DataAnnotations;

namespace FM.HRMS.DTO
{
    public class RoundsDTO
    {
        public int JobId {  get; set; }
        public string RoundName { get; set; }
       
    }
}
