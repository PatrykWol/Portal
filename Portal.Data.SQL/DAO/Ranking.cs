using System;
using System.Collections.Generic;

namespace Portal.Data.Sql.DAO
{
    public class Ranking
    {
        public Ranking()
        {
            uzytkownik = new List<Uzytkownik>();
            ranking = new List<Ranking>();
        }
        
        public int RankingId{ get; set; }
        public int IdUser{ get; set; }
        public int PozycjaRanking { get; set; }

        public virtual Uzytkownik Uzytkownik { get; set; }
        public virtual ICollection<Uzytkownik> uzytkownik { get; set; }
        public virtual ICollection<Ranking> ranking { get; set; }

    }
}