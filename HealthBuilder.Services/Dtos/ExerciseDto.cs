using System.Security.Cryptography;

namespace HealthBuilder.Services.Dtos
{
    public class ExerciseDto
    {
        public string Name { get; set; }
        public int? Reps { get; set; }
        public int? Sets { get; set; }
        public int Intensity { get; set; }
        public int? Time { get; set; }
        public string Description { get; set; }
    }
}