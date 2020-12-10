using System;
using System.ComponentModel.DataAnnotations;
using Portal.Common.Enums;

namespace Portal.Api.BindingModels
{
    public class CreateUser
    {
       [Required]
       [Display(Name = "UserId")]
        public int UserId { get; set; }
        
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
        
        
        
        
        //[Required]
        //[Display(Name = "Gender")]
       // public Gender Gender { get; set; }
        
        //[Required]
        //[Display(Name = "BirthDate")]
       // public DateTime BirthDate { get; set; }
    }
}