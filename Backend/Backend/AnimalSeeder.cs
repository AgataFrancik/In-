using Backend.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend
{
    public class AnimalSeeder
    {
        private readonly AnimalsDbContext _dbContext;
        public AnimalSeeder(AnimalsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Animals.Any())
                {
                    var animals = GetAnimals();
                    _dbContext.Animals.AddRange(animals);
                    _dbContext.SaveChanges();
                }
            }
        }
        private IEnumerable<Animal> GetAnimals()
        {
            var animals = new List<Animal>()
            {
                new Animal()
                {
                    Name = "pies",
                    Age = 12,
                    User = new User()
                    {
                        Login = "Test",
                        Password = "Test"
                    },
                    Specie = new Specie()
                    {
                        Name = "Pies",
                        Avg_length_of_life = 15,
                        Occurrence = "Everywhere",
                        Characteristics = "Popular pet"
                    },
                }
                };
            return animals;
            }
    }
}
