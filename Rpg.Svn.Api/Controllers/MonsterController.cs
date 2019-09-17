using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Rpg.Svn.Api.Interfaces;


namespace Rpg.Svn.Api.Controllers
{

    [Route("api/[controller]")]
    public class MonsterController : Controller
    {
        private readonly IMonsterService _monsterService;

        public MonsterController(IMonsterService monsterService)
        {
            _monsterService = monsterService;
        }

        [HttpGet("MonsterByName/")]
        public async Task<IActionResult> GetSpellAsync([FromHeader] string monsterName)
        {
            return Ok(await _monsterService.GetMonsterbyNameAsync(monsterName));
        }
    }
}
