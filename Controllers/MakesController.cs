using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using carvecho.Controllers.Resources;
using carvecho.Models;
using carvecho.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace carvecho.Controllers
{
    public class MakesController : Controller
    {
        private readonly CarVechoDbContext context;
        private readonly IMapper mapper;

        public MakesController(CarVechoDbContext context, IMapper mapper)
        {
            this.mapper = mapper;

            this.context = context;

        }

        [HttpGet("api/makes")]
        public async Task<IEnumerable<MakeResource>> GetMakes()
        {

            var makes = await context.Makes.Include(m => m.Models).ToListAsync();

            return mapper.Map<List<Make>, List<MakeResource>>(makes);
        }



    }
}