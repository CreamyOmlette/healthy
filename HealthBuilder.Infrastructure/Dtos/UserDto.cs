using System;
using System.ComponentModel.DataAnnotations;
using HealthBuilder.Infrastructure.Dtos.Attributes;

namespace HealthBuilder.Infrastructure.Dtos
{
    public class UserDto
    {
        public int? Id { get; set; }
        
        public string Username { get; set; }
        
        public int Height { get; set; }
        
        public int Weight { get; set; }
        
        public DateTime DoB { get; set; }
    }
    
}