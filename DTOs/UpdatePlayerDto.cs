using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ESports_League_Roster_Api.DTOs
{
    public class UpdatePlayerDto
    {
        [Required(ErrorMessage = "Must input a unique Gamer Tag")]
        [StringLength(30, ErrorMessage = "Name can not be greater than 30 characters")]
        public string Gamertag{get;set;} = string.Empty; 

        [Required(ErrorMessage = "Must input a Real Name")]
        [StringLength(100, ErrorMessage = "Name can not be greater than 100 characters")]  
        public string RealName{get;set;} = string.Empty; 
        
        [Required(ErrorMessage = "Must input a Team Name")]
        [StringLength(60, ErrorMessage = "Name can not be greater than 60 characters")]      
        public string TeamName{get;set;} = string.Empty; 
        
        [Required(ErrorMessage = "Must input a Game")]
        [StringLength(50, ErrorMessage = "Name can not be greater than 50 characters")]      
        public string Game{get;set;} = string.Empty; 
        
        [Required(ErrorMessage = "Must input a Role")]
        [StringLength(30, ErrorMessage = "Name can not be greater than 30 characters")]    
        public string Role{get;set;} = string.Empty; 
        
        [Required(ErrorMessage = "Must input a Jersey Number")]
        [Range(1, 99, ErrorMessage = "Jersey number must be from 1 to 99")]  
        public int JerseyNumber{get;set;}
        
        [Required(ErrorMessage = "Must input an Age")]
        [Range(16, int.MaxValue, ErrorMessage = "Age must be at least 16")]
        public int Age{get;set;} 
    }
}