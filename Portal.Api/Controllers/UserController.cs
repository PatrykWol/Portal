using System;
using System.Threading.Tasks;
using Portal.Api.BindingModels;
using Portal.Api.Validation;
using Portal.Api.ViewModels;
using Portal.Data.Sql;
using Portal.Data.Sql.DAO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Portal.Api.Controllers
{
    [ApiVersion( "1.0" )]
    [Route( "api/v{version:apiVersion}" )]

    public class UserController : Controller
    {
        private readonly PortalDbContext _context;

        public UserController(PortalDbContext context)
        {
            _context = context;
        }

        [HttpGet("{userId:min(1)}", Name = "GetUserById")]
        public async Task<IActionResult> GetUserById(int userId)
        {
            var uzytkownik = await _context.Uzytkownik.FirstOrDefaultAsync(x=>x.UserId== userId);

            if (uzytkownik != null)
            {
                return Ok(new UserViewModel
                {
                    UserId = uzytkownik.UserId,
                    IdUser = uzytkownik.IdUser,
                    Name = uzytkownik.Name,
                    LastName = uzytkownik.LastName,
                    Age =  uzytkownik.Age,
                    BirthDate = uzytkownik.BirthDate,
                    Gender = uzytkownik.Gender,
                    Nationality = uzytkownik.Nationality,
                    Login = uzytkownik.Login,
                    Password = uzytkownik.Password,
                    Email = uzytkownik.Email,
                    Couple = uzytkownik.Couple,
                });
            }
            return NotFound();
        }
        

        
        [HttpGet("name/{userName}", Name = "GetUserByUserName")]
        public async Task<IActionResult> GetUserByUserName(string userName)
        {
            var uzytkownik = await _context.Uzytkownik.FirstOrDefaultAsync(x=>x.Name == userName);

            if (uzytkownik != null)
            {
                return Ok(new UserViewModel
                {
                    UserId = uzytkownik.IdUser,
                    IdUser = uzytkownik.IdUser,
                    Name = uzytkownik.Name,
                    LastName = uzytkownik.LastName,
                    Age =  uzytkownik.Age,
                    BirthDate = uzytkownik.BirthDate,
                    Gender = uzytkownik.Gender,
                    Nationality = uzytkownik.Nationality,
                    Login = uzytkownik.Login,
                    Password = uzytkownik.Password,
                    Email = uzytkownik.Email,
                    Couple = uzytkownik.Couple,
                });
            }
            return NotFound();
        }
        
        

        [ValidateModel]
//        [Consumes("application/x-www-form-urlencoded")]
        //[HttpPost("create", Name = "CreateUser")]
        public async Task<IActionResult> Post([FromBody] CreateUser createUser)
        {
            var uzytkownik = new Uzytkownik {
                
                UserId = createUser.UserId,
                Name = createUser.Name,
                
                //Gender = createUser.Gender,
                //BirthDate = createUser.BirthDate,
                
            };
            await _context.AddAsync(uzytkownik);
            await _context.SaveChangesAsync();
            
            return Created(uzytkownik.UserId.ToString(),new UserViewModel
            {
                
                UserId = uzytkownik.UserId,
                IdUser = uzytkownik.IdUser,
                Name = uzytkownik.Name,
                LastName = uzytkownik.LastName,
                Age =  uzytkownik.Age,
                BirthDate = uzytkownik.BirthDate,
                Gender = uzytkownik.Gender,
                Nationality = uzytkownik.Nationality,
                Login = uzytkownik.Login,
                Password = uzytkownik.Password,
                Email = uzytkownik.Email,
                Couple = uzytkownik.Couple,
                
            }) ;
        }
        
        [ValidateModel]
        [HttpPatch("edit/{userId:min(1)}", Name = "EditUser")]
//        public async Task<IActionResult> EditUser([FromBody] EditUser editUser,[FromQuery] int userId)
        public async Task<IActionResult> EditUser([FromBody] EditUser editUser, int userId)
        {
            var uzytkownik = await _context.Uzytkownik.FirstOrDefaultAsync(x=>x.UserId == userId);
            uzytkownik.Name = editUser.Name;
            uzytkownik.Email = editUser.Email;
            uzytkownik.BirthDate = editUser.BirthDate;
            uzytkownik.Gender = editUser.Gender;
            
            await _context.SaveChangesAsync();
            return NoContent();
            return Ok(new UserViewModel
            {
                IdUser = uzytkownik.IdUser,
                Name = uzytkownik.Name,
                LastName = uzytkownik.LastName,
                Age =  uzytkownik.Age,
                BirthDate = uzytkownik.BirthDate,
                Gender = uzytkownik.Gender,
                Nationality = uzytkownik.Nationality,
                Login = uzytkownik.Login,
                Password = uzytkownik.Password,
                Email = uzytkownik.Email,
                Couple = uzytkownik.Couple,
            });
        }

    }
}