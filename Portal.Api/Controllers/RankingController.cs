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
    [Route( "api/v{version:apiVersion}/ranking" )]

    public class RankingController : Controller
    {
        private readonly PortalDbContext _context;

        public RankingController(PortalDbContext context)
        {
            _context = context;
        }

        [HttpGet("{rankingId:min(1)}", Name = "GetUser")]
        public async Task<IActionResult> GetUser(int rankingId)
        {
            var ranking = await _context.Ranking.FirstOrDefaultAsync(x=>x.RankingId== rankingId);

            if (ranking != null)
            {
                return Ok(new UserViewModel
                {
                    UserId = ranking.IdUser,
                    IdUser = ranking.RankingId,
                    
                    
                });
            }
            return NotFound();
        }
            
            
    }
}