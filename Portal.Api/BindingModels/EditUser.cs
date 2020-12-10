using System;
using System.ComponentModel.DataAnnotations;
using FluentValidation;
using Portal.Common.Enums;

namespace Portal.Api.BindingModels
{
    public class EditUser
    { 
//        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

//        [Required]
//        [EmailAddress]
//        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }
        
        
//        [Required]
        [Display(Name = "BirthDate")]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Gender")]
//        [Required]
        public Gender Gender { get; set; }
    }
    
    public class EditUserValidator : AbstractValidator<EditUser> {
            public EditUserValidator() {
                    RuleFor(x => x.Name).NotNull();
                    RuleFor(x => x.BirthDate).NotNull();
                    RuleFor(x => x.Email).EmailAddress();
                    RuleFor(x => x.Gender).NotNull();
            }
            
    }

}