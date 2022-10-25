using Backend.Models;
using System.Collections.Generic;

namespace Backend.Services
{
    public interface IAnimalService
    {
        int Create(CreateAnimalModel model);
        IEnumerable<AnimalDto> GetAll();
        AnimalDto GetById(int id);
        void Update(UpdateAnimalDto dto, int id);
        void Delete(int id);
    }
}