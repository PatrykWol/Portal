using System;
using System.ComponentModel.DataAnnotations;
using FluentValidation;
using Portal.Common.Enums;

namespace Portal.Api.BindingModels
{
    public class DeleteRanking
    { 
//        [Required]
        [Display(Name = "IdUser")]
        public int IdUser { get; set; }


    }
    
    public class DeleteRankingValidator : AbstractValidator<DeleteRanking> {
        public DeleteRankingValidator() {
            RuleFor(x => x.IdUser).NotNull();
            
        }
            
    }

}