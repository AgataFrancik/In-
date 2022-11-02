using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class CreateAnimalModel
    {
        public string Name { get; set; }
        public int Age { get; set; }

        [Required]
        public int SpecieId { get; set; }
    }
}
