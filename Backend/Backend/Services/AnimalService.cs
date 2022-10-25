using AutoMapper;
using Backend.Entities;
using Backend.Exceptions;
using Backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Services
{
    public class AnimalService : IAnimalService
    {
        private readonly AnimalsDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<AnimalService> _logger;

        public AnimalService(AnimalsDbContext dbContext, IMapper mapper, ILogger<AnimalService> logger)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
        }

        public void Update(UpdateAnimalDto dto, int id)
        {
            var animal = _dbContext
              .Animals
              .FirstOrDefault(r => r.Id == id);

            if (animal is null) throw new NotFoundException("Animal not found");
            animal.Name = dto.Name;
            animal.Age = dto.Age;

            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            _logger.LogWarning($"Animal with id: {id} DELETE action invoked");
            var animal = _dbContext
              .Animals
              .FirstOrDefault(r => r.Id == id);
            if (animal is null) throw new NotFoundException("Animal not found");
            _dbContext.Animals.Remove(animal);
            _dbContext.SaveChanges();
            
        }
        public AnimalDto GetById(int id)
        {
            var animal = _dbContext
               .Animals
               .Include(r => r.Specie)
               .FirstOrDefault(r => r.Id == id);
            if (animal is null) throw new NotFoundException("Animal not found");

            var result = _mapper.Map<AnimalDto>(animal);
            return result;
        }

        public IEnumerable<AnimalDto> GetAll()
        {
            var animals = _dbContext
               .Animals
               .Include(r => r.Specie)
               .ToList();

            var animalsDtos = _mapper.Map<List<AnimalDto>>(animals);
            return animalsDtos;
        }

        public int Create(CreateAnimalModel model)
        {
            var animal = _mapper.Map<Animal>(model);
            _dbContext.Animals.Add(animal);
            _dbContext.SaveChanges();
            return animal.Id;
        }
    }
}
