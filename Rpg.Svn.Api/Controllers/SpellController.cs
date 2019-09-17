using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Rpg.Svn.Api.Interfaces;


namespace Rpg.Svn.Api.Controllers
{

    [Route("api/[controller]")]
    public class SpellController : Controller
    {
        private readonly ISpellService _spellService;

        public SpellController(ISpellService spellService)
        {
            _spellService = spellService;
        }

        [HttpGet("SpellByName/")]
        public async Task<IActionResult> GetSpellAsync([FromHeader] string spellName)
        {
            return Ok(await _spellService.GetSpellbyNameAsync(spellName));
        }

        [HttpGet("SpellList/")]
        public async Task<IActionResult> GetSpellListAsync()
        {
            return Ok(await _spellService.GetSpellListAsync());
        }
    }
}
