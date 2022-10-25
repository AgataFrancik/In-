using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class AnimalDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public string SpecieName { get; set; }
        public int Avg_length_of_life { get; set; }
        public string Occurrence { get; set; }
        public string Characteristics { get; set; }
    }
}
