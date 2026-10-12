using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ESports_League_Roster_Api.Model;
using Microsoft.EntityFrameworkCore;

namespace ESports_League_Roster_Api.Data;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Player> Player { get; set; }
}