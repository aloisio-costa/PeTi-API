using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class ServiceRequestsController : ControllerBase
    {
        private readonly IServiceRequestRepo _serviceRequestRepository;
        private readonly IWebHostEnvironment _env;
        public ServiceRequestsController(IServiceRequestRepo serviceRequestRepository, IWebHostEnvironment env)
        {
            _serviceRequestRepository = serviceRequestRepository;
            _env = env;
        }

        [HttpGet]
        public async Task<IEnumerable<ServiceRequest>> GetServiceRequests()
        {
            return await _serviceRequestRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceRequest>> GetServiceRequest(Guid id)
        {
            return await _serviceRequestRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceRequest>> CreateServiceRequest([FromBody] ServiceRequest serviceRequest)
        {
            var newServiceRequest = await _serviceRequestRepository.Create(serviceRequest);
            return CreatedAtAction(nameof(GetServiceRequest), new { id = newServiceRequest.Id }, newServiceRequest);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpadateServiceRequest(Guid id, [FromBody] ServiceRequest serviceRequest)
        {
            if (id != serviceRequest.Id)
            {
                return BadRequest();
            }

            await _serviceRequestRepository.Update(serviceRequest);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteServiceRequest(Guid id)
        {
            var serviceRequestToDelete = await _serviceRequestRepository.Get(id);
            if (serviceRequestToDelete == null)
                return NotFound();

            await _serviceRequestRepository.Delete(serviceRequestToDelete.Id);
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

                using (var stream = new FileStream(physicalPath, FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                }

                return new JsonResult(filename);
            }
            catch (Exception)
            {
                return new JsonResult("defaultServiceRequest.jpg");
            }
        }
    }
}

