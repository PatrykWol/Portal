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

        public class PreferencjeController : Controller
        {
            private readonly PortalDbContext _context;

            public PreferencjeController(PortalDbContext context)
            {
                _context = context;
            }

            [HttpDelete("{idUser}", Name = "DeleteDane")]
            public async Task<IActionResult> DeleteDane(int idUser)
            {
                var preferencje = await _context.Preferencje.FirstOrDefaultAsync(x=>x.IdPreferencje == idUser);
                if(preferencje != null)
                {
                    _context.Preferencje.Remove(preferencje);
                await _context.SaveChangesAsync();
                return Ok();
                }

                return NotFound();
            }

            
            
    }
}