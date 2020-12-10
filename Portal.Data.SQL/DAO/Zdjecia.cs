using System;
using System.Collections.Generic;
using Portal.Data.Sql.DAO;
using Portal.Common.Enums;

namespace Portal.Data.Sql.DAO
{
    public class Zdjecia
    {

        public int IdZdjecia { get; set; }
        public int IdUser { get; set; }
        public MediaType MediaType { get; set; }
        public string MediaHref { get; set; }

        public virtual Uzytkownik Uzytkownik { get; set; }
    }
}