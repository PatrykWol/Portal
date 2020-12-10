using System;
using System.Collections.Generic;
using System.Linq;
using Portal.Common.Enums;
using Portal.Common.Extensions;
using Portal.Data.Sql.DAO;

namespace Portal.Data.Sql.Migrations
{
    //klasa odpowiadająca za wypełnienie testowymi danymi bazę danych
    public class DatabaseSeed
    {
        private readonly PortalDbContext _context;
        
        //wstrzyknięcie instancji klasy FoodlyDbContext poprzez konstruktor
        public DatabaseSeed(PortalDbContext context)
        {
            _context = context;
        }
        
        //metoda odpowiadająca za uzupełnienie utworzonej bazy danych testowymi danymi
        //kolejność wywołania ma niestety znaczenie, ponieważ nie da się utworzyć rekordu
        //w bazie dnaych bez znajmości wartości klucza obcego
        //dlatego należy zacząć od uzupełniania tabel, które nie posiadają kluczy obcych
        //--OFFTOP
        //w przeciwną stronę działa ręczne usuwanie tabel z wypełnionymi danymi w bazie danych
        //należy zacząć od tabel, które posiadają klucze obce, a skończyć na tabelach, które 
        //nie posiadają
        public void Seed()
        {
            //regiony pozwalają na zwinięcie kodu w IDE
            //nie sa dobrą praktyką, kod w danej klasie/metodzie nie powinien wymagać jego zwijania
            //zastosowałem je z lenistwa nie powinno to mieć miejsca 
            #region CreateUsers
            var userList = BuildUserList();
            //dodanie użytkowników do tabeli User
            _context.Uzytkownik.AddRange(userList);
            //zapisanie zmian w bazie danych
            _context.SaveChanges();
            #endregion
            
            #region CreatePreference
            var preferencjeList = BuildPreferencjeList(userList);
            _context.Preferencje.AddRange(preferencjeList);
            _context.SaveChanges();
            #endregion
            
            #region CreateRank
            var rankingList = BuildRankingList(userList);
            _context.Ranking.AddRange(rankingList);
            _context.SaveChanges();
            #endregion
            

            #region CreateOceny
            var ocenyList = BuildOcenyList(rankingList, userList);
            _context.Oceny.AddRange(ocenyList);
            _context.SaveChanges();
            #endregion

            #region CreateMedia
            var zdjeciaList = BuildZdjeciaList(rankingList, userList);
            _context.Zdjecia.AddRange(zdjeciaList);
            _context.SaveChanges();
            #endregion
        }

        private IEnumerable<Uzytkownik> BuildUserList()
        {
            var userList = new List<Uzytkownik>();
            var user = new Uzytkownik()
            {
                UserId = 1,
                IdUser = 1,
                Name =  "Patryk",
                LastName = "Wolozonek",
                Age = 21,
                Gender = Gender.Male,
                Nationality = "PL",
                Login = "Patryk",
                Password = "Patryk",
                Email = "wolozonek.patryk@gmail.com",
                Couple = 0,
                BirthDate = new DateTime(1998, 08, 28),
                
            };
            userList.Add(user);

            var user2 = new Uzytkownik()
            {
                UserId = 2,
                IdUser = 2,
                Name = "Patka",
                LastName = "Parta",
                Age = 23,
                Gender = Gender.Female,
                Nationality = "PL",
                Login = "Patka",
                Password = "Patka",
                Email = "patka@gmail.com",
                Couple = 0,
                BirthDate = new DateTime(1996, 02, 10)
            };
            userList.Add(user2);
            
            for (int i = 3; i <= 20; i++)
            {
                var user3 = new Uzytkownik
                {
                    UserId=i,
                    IdUser = i,
                    Name = "user" + i,
                    LastName = "user" + i,
                    Age = 15 + i,
                    Email = "user" + i + "@student.po.edu.pl",
                    Nationality = "PL",
                    Login = "login" + i,
                    Password = "pass" + i,
                    BirthDate = new DateTime(1992, 3, 4),
                    Gender = i % 2 == 0 ? Gender.Female : Gender.Male,
                    
                };
                userList.Add(user3);
            }

            return userList;
        }
        
        private IEnumerable<Preferencje> BuildPreferencjeList(
            IEnumerable<Uzytkownik> userList)
        {
            var preferencje = new List<Preferencje>();
            foreach (var user in userList)
            {
                if(user.Name!="Patryk")
                    preferencje.Add(new Preferencje
                    {
                        IdUser = userList.First(x=>x.Name=="Patryk").UserId,
                        
                    });
                if(user.Name!="Patryk"&&user.Name=="Patka")
                    preferencje.Add(new Preferencje
                    {
                        IdUser = userList.First(x=>x.Name=="Patryk").UserId,
                    });
            }
            foreach (var user in userList)
            {
                if(user.Name!="Patryk"&&user.Name!="Patka")
                    preferencje.Add(new Preferencje
                    {
                        IdUser = userList.First(x=>x.Name=="Patryk").UserId,
                    });
                if(user.Name!="Patka"&&user.Name=="Patryk")
                    preferencje.Add(new Preferencje
                    {
                        IdUser = userList.First(x=>x.Name=="Patka").UserId,
                    });
            }
            
            return preferencje;
        }

        

        private IEnumerable<Ranking> BuildRankingList(IEnumerable<Uzytkownik> userList)
        {
            
            var rankingList = new List<Ranking>();
            for (int i = 1; i <= 20; i++)
            {
                rankingList.Add(new Ranking
                {
                    IdUser = userList.First(x=>x.Name=="Patryk").UserId,
                    PozycjaRanking = i,
                    RankingId = i
                });
            }

            
           
            return rankingList;
        }

      

        private IEnumerable<Oceny> BuildOcenyList(
            IEnumerable<Ranking> rankingList,
            IEnumerable<Uzytkownik> userList)
        {
            var ocenyList = new List<Oceny>();
            foreach (var user in userList)
            {
                if (user.Name != "Patryk")
                {
                    rankingList.ToList().Shuffle();
                    ocenyList.Add(new Oceny
                    {
                        
                        IdUser = user.UserId,
                        LikeDate = new DateTime(),
                        Like = true,
                    });
                }
            }

            return ocenyList;
        }

        private IEnumerable<Zdjecia> BuildZdjeciaList(
            IEnumerable<Ranking> rankingList,
            IEnumerable<Uzytkownik> userList)
        {
            var zdjeciaList = new List<Zdjecia>();
           
            return zdjeciaList;
        }
    }

}