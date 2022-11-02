using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Entities
{
    public class Specie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Avg_length_of_life { get; set; }
        public string Occurrence { get; set; }
        public string Characteristics { get; set; }
        public virtual List<Animal> Animal { get; set; }

    }
}
