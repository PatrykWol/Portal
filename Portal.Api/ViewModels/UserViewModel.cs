using System;
using Portal.Common.Enums;

namespace Portal.Api.ViewModels
{
    public class UserViewModel
    {
        public int UserId { get; set; }
        public int IdUser { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        
        public int Age { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
        public string Nationality { get; set; }
        public string Login{ get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int Couple{ get; set; }

    }
}