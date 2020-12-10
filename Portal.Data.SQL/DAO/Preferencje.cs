using System;
using Portal.Common.Enums;

namespace Portal.Data.Sql.DAO
{
    public class Preferencje
    {
        public int IdPreferencje { get; set; }
        public int IdUser { get; set; }
        public int Wiek { get; set; }
        public Gender Gender{ get; set; }

        public virtual Uzytkownik Uzytkownik { get; set; }


    }
}