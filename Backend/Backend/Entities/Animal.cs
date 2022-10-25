using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Entities
{
    public class Animal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int SpecieId {get; set;}
        public int UserId { get; set; }

        public virtual User User { get; set; }

        public virtual Specie Specie { get; set; }
        
    }
}
