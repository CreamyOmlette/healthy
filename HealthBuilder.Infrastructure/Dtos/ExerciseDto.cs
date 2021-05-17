using System.Security.Cryptography;

namespace HealthBuilder.Infrastructure.Dtos
{
    public class ExerciseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Reps { get; set; }
        public int? Sets { get; set; }
        public int Intensity { get; set; }
        public int? Time { get; set; }
        public string Description { get; set; }
    }
}