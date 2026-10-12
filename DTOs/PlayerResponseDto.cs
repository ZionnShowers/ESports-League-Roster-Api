using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESports_League_Roster_Api.DTOs
{
    public class PlayerResponseDto
    {
        public int Id{get;set;}
        public string Gamertag{get;set;} = string.Empty; 
        public string RealName{get;set;} = string.Empty; 
        public string TeamName{get;set;} = string.Empty; 
        public string Game{get;set;} = string.Empty; 
        public string Role{get;set;} = string.Empty; 
        public int JerseyNumber{get;set;}
        public int Age{get;set;}
        public int Teammates{get;set;}
    }
}