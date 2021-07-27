using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PeTiAPI.Dtos;
using PeTiAPI.Models;
using PeTiAPI.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PeTiAPI.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class PetSittersController : ControllerBase
    {
        private readonly IPetSitterRepo _petSitterRepository;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;
        public PetSittersController(IPetSitterRepo petSitterRepository, IMapper mapper, IWebHostEnvironment env)
        {
            _petSitterRepository = petSitterRepository;
            _mapper = mapper;
            _env = env;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PetSitterReadDTO>> GetPetSitters()
        {
            var petSitters = _petSitterRepository.Get();
            return Ok(_mapper.Map<IEnumerable<PetSitterReadDTO>>(petSitters));
        }
    

        [HttpGet("{id}")]
        public ActionResult<PetSitterReadDTO> GetPetSitter(Guid id)
        {
            var petSitter = _petSitterRepository.Get(id);
            if(petSitter != null)
            {
                return Ok(_mapper.Map<PetSitterReadDTO>(petSitter));
            }

            return NotFound();
        }

        [HttpPost]
        public ActionResult<PetSitterReadDTO> CreatePetSitter([FromBody] PetSitterCreateDTO petSitter)
        {

            var PetSitterModel = _mapper.Map<PetSitter>(petSitter);
            _petSitterRepository.Create(PetSitterModel);
            _petSitterRepository.SaveChanges();

            var newPetSitter = _mapper.Map<PetSitterReadDTO>(PetSitterModel);

            return CreatedAtAction(nameof(GetPetSitters), new { id = newPetSitter.Id }, newPetSitter);
        }


        [HttpPut("{id}")]
        public ActionResult UpdatePetSitter(Guid id, [FromBody] PetSitterUpdateDTO petSitter)
        {
            if (id != petSitter.Id)
            {
                return BadRequest();
            }
            var petSitterModelFromRepo = _petSitterRepository.Get(id);
            if (petSitterModelFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(petSitter, petSitterModelFromRepo);

            _petSitterRepository.Update(petSitterModelFromRepo);

            _petSitterRepository.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var petSitterToDelete = _petSitterRepository.Get(id);
            if (petSitterToDelete == null)
            {
                return NotFound();
            }

            _petSitterRepository.Delete(petSitterToDelete.Id);
            _petSitterRepository.SaveChanges();

            return NoContent();
        }

        [Route("SaveFile")]
        [HttpPost]
        public JsonResult SaveFile()
        {
            try
            {
                var httpRequest = Request.Form;
                var postedFile = httpRequest.Files[0];
                string filename = postedFile.FileName;
                var physicalPath = _env.ContentRootPath + "/Photos/" + filename;

                using(var stream = new FileStream(physicalPath, FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                }

                return new JsonResult(filename);
            }
            catch (Exception)
            {
                return new JsonResult("defaultPetSitter.jpg");
            }
        }
    }
}
