using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ESports_League_Roster_Api.Data;
using ESports_League_Roster_Api.Model;

namespace ESports_League_Roster_Api.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly AppDbContext _db; 

        public PlayerRepository(AppDbContext db)
        {
            _db = db; 
        }
        
        public IEnumerable<Player> GetAll()
        {
            return _db.Player.ToList(); 
        }

        public Player? GetById(int id)
        {
            return _db.Player.FirstOrDefault(p => p.Id == id); 
        }
        public Player Create(Player player)
        {
            _db.Player.Add(player);
            _db.SaveChanges();
            return player;
        }
        public Player Update(Player player)
        {
            _db.SaveChanges();
            return player;
        }
        public bool Delete(int id)
        {
            Player? player = _db.Player.FirstOrDefault(p => p.Id == id); 
            if(player != null)
            {
                _db.Player.Remove(player);
                _db.SaveChanges();               
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}