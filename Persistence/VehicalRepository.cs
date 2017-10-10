using System.Threading.Tasks;
using carvecho.Core.Models;
using Microsoft.EntityFrameworkCore;
using carvecho.Core;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System;
using carvecho.Extensions;

namespace carvecho.Persistence
{
    public class VehicalRepository : IVehicalRepository
    {
        private readonly CarVechoDbContext context;
        public VehicalRepository(CarVechoDbContext context)
        {
            this.context = context;

        }

        public async Task<Vehical> GetVehical(int id, bool includeRelated = true)
        {
            if (!includeRelated)
                return await context.Vehicals.FindAsync(id);

            return await context.Vehicals
                           .Include(v => v.Features)
                           .ThenInclude(vf => vf.Feature)
                           .Include(v => v.Model)
                           .ThenInclude(m => m.Make)
                           .SingleOrDefaultAsync(v => v.Id == id);

        }



        public void Add(Vehical vehical)
        {
            context.Vehicals.Add(vehical);

        }


        public void Remove(Vehical vehical)
        {
            context.Vehicals.Remove(vehical);

        }

        public async Task<QueryResult<Vehical>> GetAllVehical(VehicalQuery queryObj)
        {
               var result =  new QueryResult<Vehical>();

            var query =   context.Vehicals
                           .Include(v => v.Features)
                           .ThenInclude(vf => vf.Feature)
                           .Include(v => v.Model)
                           .ThenInclude(m => m.Make)
                           .AsQueryable();

                
                if(queryObj.MakeId.HasValue)
                   query =  query.Where(v => v.Model.MakeId == queryObj.MakeId);
                if(queryObj.ModelId.HasValue)
                   query =  query.Where(v => v.Model.Id == queryObj.ModelId);

               
               var columnsMap =  new Dictionary<string, Expression<Func<Vehical,object>>>()
               {
                   ["make"] = v => v.Model.Make.Name,
                   ["model"] = v => v.Model.Name,
                   ["contactName"] = v => v.ContactName,
               };
               
               query = query.ApplyOrdering(queryObj, columnsMap);

               result.TotalItems = await query.CountAsync();

               query =  query.ApplyPaging(queryObj);

               result.Items = await  query.ToListAsync();
               
                 
                           
             return result;
        }

   




    }
}