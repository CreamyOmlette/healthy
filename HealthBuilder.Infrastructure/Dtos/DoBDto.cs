using System;
using System.ComponentModel.DataAnnotations;
using HealthBuilder.Infrastructure.Dtos.Attributes;

namespace HealthBuilder.Infrastructure.Dtos
{
    public class DoBDto
    {
        [Required]
        [MyDoB(ErrorMessage = "Date of birth is invalid")]
        public DateTime DoB { get; set; }
    }
}