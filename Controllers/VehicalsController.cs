using System;
using System.Threading.Tasks;
using AutoMapper;
using carvecho.Controllers.Resources;
using carvecho.Models;
using carvecho.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace carvecho.Controllers
{
    [Route("/api/vehicals")]
    public class VehicalsController : Controller
    {
        private readonly IMapper mapper;
        private readonly CarVechoDbContext context;
        public VehicalsController(IMapper mapper, CarVechoDbContext context)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpPost]
        public  async Task<IActionResult> CreateVehicals([FromBody] VehicalResource vehicalResource)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            var vehical = mapper.Map<VehicalResource, Vehical>(vehicalResource);
             vehical.LastUpdate = DateTime.Now;
              context.Vehicals.Add(vehical);
              await context.SaveChangesAsync();
              var result = mapper.Map<Vehical, VehicalResource>(vehical);
              
            return Ok(result);
        }
    }
}