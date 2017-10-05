using carvecho.Persistence;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using carvecho.Controllers.Resources;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using carvecho.Core.Models;

namespace carvecho.Controllers
{
    public class FeaturesController : Controller
    {
        private readonly CarVechoDbContext context;
        private readonly IMapper mapper;
        public FeaturesController(CarVechoDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;

        }

   [HttpGet("/api/features")]
    public async Task<IEnumerable<KeyValuePairResource>> GetFeatures()
    {
       var features =  await context.Features.ToListAsync();

       return mapper.Map<List<Feature>, List<KeyValuePairResource>>(features);

    }

    }
}