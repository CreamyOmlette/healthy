using System.ComponentModel.DataAnnotations;

namespace HealthBuilder.Infrastructure.Dtos
{
    public class SpecificationDto
    {
        [Range(10,300, ErrorMessage = "Height is not valid")]
        public int? Height { get; set; }
        [Range(10,250, ErrorMessage = "Weight is not valid")]
        public int? Weight { get; set; }
    }
}