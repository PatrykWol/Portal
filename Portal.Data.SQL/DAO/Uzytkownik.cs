using System;
using System.Collections.Generic;
using Portal.Common.Enums;

namespace Portal.Data.Sql.DAO
{
    public class Uzytkownik
    {
        public Uzytkownik()
        {
            oceny = new List<Oceny>();
            ranking = new List<Ranking>();
            preferencje = new List<Preferencje>();
            zdjecia = new List<Zdjecia>();
        }

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
        

        public virtual ICollection<Oceny> oceny { get; set; }
        public virtual ICollection<Ranking> ranking { get; set; }
        public virtual ICollection<Zdjecia> zdjecia { get; set; }
        public virtual ICollection<Preferencje> preferencje { get; set; }

    }
}