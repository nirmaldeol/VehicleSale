using System.Collections.Generic;
using System.Threading.Tasks;
using carvecho.Core.Models;

namespace carvecho.Core
{
    public interface IVehicalRepository
    {
         Task<QueryResult<Vehical>> GetAllVehical(VehicalQuery filter);
         Task<Vehical> GetVehical(int id, bool includeRelated = true);
          void Add(Vehical vehical);
          void Remove(Vehical vehical) ;

         
    }
}