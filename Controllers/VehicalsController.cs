using System;
using System.Threading.Tasks;
using AutoMapper;
using carvecho.Controllers.Resources;
using carvecho.Core.Models;
using carvecho.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace carvecho.Controllers
{
    [Route("/api/vehicals")]
    public class VehicalsController : Controller
    {
        private readonly IMapper mapper;

        private readonly IVehicalRepository repository;
        private readonly IUnitOfWork unitOfWork;

        public VehicalsController(
           IMapper mapper,
           IVehicalRepository repository,
           IUnitOfWork unitOfWork
          )
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;

            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateVehical([FromBody] SaveVehicalResource SaveVehicalResource)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var vehical = mapper.Map<SaveVehicalResource, Vehical>(SaveVehicalResource);
            vehical.LastUpdate = DateTime.Now;

            repository.Add(vehical);
            await unitOfWork.CompleteAsync();

            vehical = await repository.GetVehical(vehical.Id);
            var result = mapper.Map<Vehical, VehicalResource>(vehical);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVehical(int id, [FromBody] SaveVehicalResource SaveVehicalResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var vehical = await repository.GetVehical(id);
            if (vehical == null)
                return NotFound();

            mapper.Map<SaveVehicalResource, Vehical>(SaveVehicalResource, vehical);
            vehical.LastUpdate = DateTime.Now;
            await unitOfWork.CompleteAsync();

            vehical = await repository.GetVehical(vehical.Id);
            var result = mapper.Map<Vehical, VehicalResource>(vehical);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehical(int id)
        {
            var vehical = await repository.GetVehical(id, includeRelated: false);
            if (vehical == null)
                return NotFound();

            repository.Remove(vehical);
            await unitOfWork.CompleteAsync();

            return Ok(id);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehical(int id)
        {
            var vehical = await repository.GetVehical(id);
            if (vehical == null)
                return NotFound();

            var vresource = mapper.Map<Vehical, VehicalResource>(vehical);
            return Ok(vresource);
        }

       [HttpGet]
        public async Task<IEnumerable<VehicalResource>> GetAllVehical()
        {
            var vehicals = await repository.GetAllVehical();
            // if (vehical == null)
            //     return NotFound();

            return mapper.Map<IEnumerable<Vehical>, IEnumerable<VehicalResource>>(vehicals);
          
        }
    }
}