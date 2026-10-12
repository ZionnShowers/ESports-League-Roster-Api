using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ESports_League_Roster_Api.DTOs;

namespace ESports_League_Roster_Api.Services
{
    public interface IPlayerServices
    {
        List<PlayerResponseDto> GetAll(); 
        PlayerResponseDto? GetById(int id); 
        PlayerResponseDto? Create(CreatePlayerDto newPlayer);
        bool Update(int id, UpdatePlayerDto editPlayer);
        void Delete(int id);
        bool Patch(int id, TransferDto editPlayer);
    }
}