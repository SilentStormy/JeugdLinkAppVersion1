﻿using System.ComponentModel.DataAnnotations;

namespace JeugdLinkApp.Models
{
    public class RegisterModel
    {
        [Required]
        [Display(Name="firstname")]
        public string Firstname { get; set; } 
        
        [Required]
        [Display(Name="lastname")]
        public string Lastname { get; set; }
        
        [Required]
        [Display(Name="email")]
        public string Email { get; set; }
        
        [Required]
        [Display(Name="password")]
        public string Password { get; set; }
        
      
    }
}
