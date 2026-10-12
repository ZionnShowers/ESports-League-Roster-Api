using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ESports_League_Roster_Api.Model;

namespace ESports_League_Roster_Api.Repositories
{
    public interface IPlayerRepository //DONT ADD OR CHANGE
    {
        IEnumerable<Player> GetAll();
        Player? GetById(int id);
        Player Create(Player player);
        Player Update(Player player);
        bool Delete(int id);
}
}