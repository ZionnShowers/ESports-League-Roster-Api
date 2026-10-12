
using ESports_League_Roster_Api.DTOs;
using ESports_League_Roster_Api.Model;
using ESports_League_Roster_Api.Repositories;

namespace ESports_League_Roster_Api.Services
{
    public class PlayerServices : IPlayerServices
    {
        private readonly IPlayerRepository _repo;

        public PlayerServices(IPlayerRepository repo)
        {
            _repo = repo;
        }

        public List<PlayerResponseDto> GetAll()
        {
            IEnumerable<Player> players = _repo.GetAll(); //Gets every player info
            // Player? existing = _repo.GetById(id);
            // existing.TeamName = editPlayer.Teammates;  
            return players.Select(p => ToReadDto(p, players)).ToList();

        }

        public PlayerResponseDto? GetById(int id)
        {
            IEnumerable<Player> players = _repo.GetAll(); //Gets every player info
            Player? player = _repo.GetById(id);
            if(player is null)
            {
                return null;
            }
            return ToReadDto(player, players); 

        }

        public PlayerResponseDto? Create(CreatePlayerDto newPlayer)
        {
            IEnumerable<Player> players = _repo.GetAll(); //Gets every player info
            bool exists = players.Any(p => p.Gamertag.ToLower() == newPlayer.Gamertag.ToLower()); //Checks if gamertag is being used
            int playerCount = players.Count(p => p.TeamName == newPlayer.TeamName); //Counts how many are in a team
            // Console.WriteLine("Test");
            if (playerCount >= 6 || exists) //If player count is equal or more than 6 or Gamertag is being used
            {
                return null;
            }
            Player player = new Player(); 

            player.Gamertag = newPlayer.Gamertag; 
            player.RealName = newPlayer.RealName;
            player.TeamName = newPlayer.TeamName; 
            player.Game = newPlayer.Game;  
            player.Role = newPlayer.Role; 
            player.JerseyNumber = newPlayer.JerseyNumber; 
            player.Age = newPlayer.Age; 
            Player created = _repo.Create(player); 
            return ToReadDto(created, players); 


        }//end of Create

        public bool Update(int id, UpdatePlayerDto editPlayer)
        {
            IEnumerable<Player> players = _repo.GetAll(); //Gets every player info ??ADDEEDDDDD
            Player? existing = _repo.GetById(id);
            bool exists = players.Any(p => p.Gamertag.ToLower() == editPlayer.Gamertag.ToLower()); //Checks if gamertag is being used ??ADDDEEEDD
            if(existing is null || exists)
            {
                return false;
            }
            existing.Gamertag = editPlayer.Gamertag; 
            existing.RealName = editPlayer.RealName;
            existing.TeamName = editPlayer.TeamName; 
            existing.Game = editPlayer.Game;  
            existing.Role = editPlayer.Role; 
            existing.JerseyNumber = editPlayer.JerseyNumber; 
            existing.Age = editPlayer.Age;  
            _repo.Update(existing);
            return true; 
        }

        public void Delete(int id)
        {
            Player? player = _repo.GetById(id);
            if(player != null)
            {
                _repo.Delete(id); 
            }
        }//end of Delete


        public bool Patch(int id, TransferDto editPlayer)
        {
            IEnumerable<Player> players = _repo.GetAll(); //Gets every player info
            Player? existing = _repo.GetById(id);
            // int playerCount = players.Count(p => p.TeamName == editPlayer.TeamName); //Counts how many are in a team
            // bool exists = players.Any(p => p.Gamertag.ToLower() == editPlayer.Gamertag.ToLower()); //Checks if gamertag is being used ??ADDDEEEDD
            if(existing is null)
            {
                return false;
            }
            existing.TeamName = editPlayer.TeamName; 
            _repo.Update(existing);
            return true; 
        }




        //Helper Method
        private static PlayerResponseDto ToReadDto(Player player, IEnumerable<Player> players)
        {
            PlayerResponseDto outputDto = new PlayerResponseDto();
            outputDto.Id = player.Id;
            outputDto.Gamertag = player.Gamertag;
            outputDto.RealName = player.RealName;
            outputDto.TeamName = player.TeamName;
            outputDto.Game = player.Game;
            outputDto.Role = player.Role;
            outputDto.JerseyNumber = player.JerseyNumber;
            outputDto.Age = player.Age;
            outputDto.Teammates = players.Count(p => p.TeamName == player.TeamName);
            return outputDto;

        }

    }
}