using System.Threading.Tasks;
using carvecho.Core.Models;
using Microsoft.EntityFrameworkCore;
using carvecho.Core;
using System.Collections.Generic;

namespace carvecho.Persistence
{
    public class VehicalRepository :IVehicalRepository
    {
        private readonly CarVechoDbContext context;
        public VehicalRepository(CarVechoDbContext context)
        {
            this.context = context;

        }

        public async Task<Vehical> GetVehical(int id, bool includeRelated = true)
        {
            if(!includeRelated)
                return  await context.Vehicals.FindAsync(id);

            return await context.Vehicals
                           .Include(v => v.Features)
                           .ThenInclude(vf => vf.Feature)
                           .Include(v => v.Model)
                           .ThenInclude(m => m.Make)
                           .SingleOrDefaultAsync(v => v.Id == id);
           
        }


           public async Task<IEnumerable<Vehical>> GetAllVehical()
        {

            return await context.Vehicals
                           .Include(v => v.Features)
                           .ThenInclude(vf => vf.Feature)
                           .Include(v => v.Model)
                           .ThenInclude(m => m.Make)
                           .ToListAsync();
           
        }
         public void Add(Vehical vehical) 
         {
             context.Vehicals.Add(vehical);
             
         }


         public void Remove(Vehical vehical) 
         {
             context.Vehicals.Remove(vehical);
             
         }




    }
}