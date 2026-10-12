using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ESports_League_Roster_Api.DTOs;
using ESports_League_Roster_Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace ESports_League_Roster_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlayersController : ControllerBase
    {
        private readonly IPlayerServices _players;

        public PlayersController(IPlayerServices players)
        {
            _players = players; 
        }

        [HttpGet]
        public ActionResult<List<PlayerResponseDto>> GetAll()
        {
            return Ok(_players.GetAll()); 
        }

        [HttpGet("{id}")]
        public ActionResult<PlayerResponseDto> GetById(int id)
        {
            PlayerResponseDto? player = _players.GetById(id); 
            if(player is null)
            {
                return NotFound($"No player with id {id} was found");
            }
            return Ok(player); 
        }

        [HttpPost]
        public ActionResult<PlayerResponseDto> Create([FromBody] CreatePlayerDto player)
        {
            PlayerResponseDto? created = _players.Create(player);
            if(created is null)
            {
                return Conflict($"There is already a Gamer tag named {player.Gamertag} or the Team is full.");
            }

            return CreatedAtAction(nameof(GetById), new {id = created.Id}, created); 
        }

        [HttpPut("{id}")]
        public ActionResult<PlayerResponseDto> Update(int id, [FromBody] UpdatePlayerDto player)
        {
            PlayerResponseDto? exists = _players.GetById(id);
            if(exists is null)
            {
                return NotFound($"No player with id {id} was found");

            }
           return Ok(); 
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if(_players.GetById(id) is null)
            {
                return NotFound($"No member with id {id} was found");
            }
            _players.Delete(id);
            return NoContent(); 
        }//end of delete

        [HttpPatch("{id}/transfer")]
        public ActionResult<PlayerResponseDto> Patch(int id, [FromBody] TransferDto player)
        {
            PlayerResponseDto? exists = _players.GetById(id);
            if(exists is null)
            {
                return NotFound($"No player with id {id} was found");
            }
            _players.Patch(id, player);
           return Ok(exists); 
        }


        // for every unique TeamName, add 1 to TeamName for corresponding id
        
        // StudentMember member = Student.FirstOrDefault(c => c.Email == email);
    }
}