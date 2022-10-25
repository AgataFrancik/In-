using AutoMapper;
using Backend.Entities;
using Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend
{
    public class AnimalsMappingProfile : Profile
    {
        public AnimalsMappingProfile()
        {
            CreateMap<Animal, AnimalDto>()
                .ForMember(m => m.SpecieName, c => c.MapFrom(s => s.Specie.Name))
                 .ForMember(m => m.Avg_length_of_life, c => c.MapFrom(s => s.Specie.Avg_length_of_life))
                  .ForMember(m => m.Occurrence, c => c.MapFrom(s => s.Specie.Occurrence))
                   .ForMember(m => m.Characteristics, c => c.MapFrom(s => s.Specie.Characteristics));
            CreateMap<Specie, SpecieDto>();
            CreateMap<CreateAnimalModel, Animal>()
                .ForMember(r => r.Specie, c => c.MapFrom(dto => new Specie()
                {
                    Avg_length_of_life = dto.Avg_length_of_life,
                    Characteristics = dto.Characteristics,
                    Occurrence = dto.Occurrence,
                    Name = dto.SpecieName
                }));
            
        }
    }
}
