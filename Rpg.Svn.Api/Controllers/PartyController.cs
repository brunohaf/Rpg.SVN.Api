using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Rpg.Svn.Api.Exceptions;
using Rpg.Svn.Api.Interfaces;
using Rpg.Svn.Api.Models;
using Rpg.Svn.Thirdparty.Facades;

namespace Rpg.Svn.Api.Controllers
{

    [Route("api/[controller]")]
    public class PartyController : Controller
    {

        private readonly IPartyService _partyService;
        private readonly ISpellService _spellService;


        public PartyController(IPartyService partyService, ISpellService spellService)
        {
            _partyService = partyService;
            _spellService = spellService;
        }


        // GET api/party
        [HttpGet]
        public ActionResult<CharacterInfoResponse> GetCharacterInfo([FromHeader] string authkey, [FromHeader]string character)
        {
            var response = _partyService.GetCharacterInfo(character);
            return Ok(response);
           
        }

        // GET api/values/5
        [HttpGet("Spells/")]
        public async Task<IActionResult> GetSpellsAsync([FromHeader] string spellName)
        {
            return Ok(await _spellService.GetSpellbyNameAsync(spellName));
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
