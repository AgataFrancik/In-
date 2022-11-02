using AutoMapper;
using Backend.Entities;
using Backend.Models;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Controllers
{
    [Route("api/animal")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        private readonly IAnimalService _animalService;

        public AnimalController(IAnimalService animalService)
        {
            _animalService = animalService;
        }

        [HttpPost]
        public ActionResult CreateAnimal([FromBody]CreateAnimalModel model) 
        {
            var id =_animalService.Create(model);
            return Created($"api/animal/{id}", null);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
           _animalService.Delete(id);
           return NoContent();
        }
        [HttpPut("{id}")]
        public ActionResult UpdateAnimal([FromBody]UpdateAnimalDto dto, [FromRoute] int id)
        {
            _animalService.Update(dto, id);
            return Ok();
        }

        [HttpGet]
        public ActionResult<IEnumerable<AnimalDto>> GetAll()
        {
            var animalsDtos = _animalService.GetAll();
            return Ok(animalsDtos);
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Animal>> GetId([FromRoute] int id)
        {
            var animal = _animalService.GetById(id);
            return Ok(animal);
        }


        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
