using System;

namespace Portal.Data.Sql.DAO
{
    public class Oceny
    {
        public int OcenaId { get; set; }
        public int IdUser { get; set; }
        public bool Like { get; set; }
        public DateTime LikeDate { get; set; }
        public virtual Ranking Ranking { get; set; }
        public virtual Uzytkownik Uzytkownik { get; set; }

    }
}