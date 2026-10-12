using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ESports_League_Roster_Api.DTOs
{
    public class TransferDto
    {
        [Required(ErrorMessage = "Must input a Team Name")]
        [StringLength(60, ErrorMessage = "Name can not be greater than 60 characters")]      
        public string TeamName{get;set;} = string.Empty; 
        public string Gamertag{get;set;} = string.Empty; 
    }
}