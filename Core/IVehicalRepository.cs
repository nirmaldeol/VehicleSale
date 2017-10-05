using System.Collections.Generic;
using System.Threading.Tasks;
using carvecho.Core.Models;

namespace carvecho.Core
{
    public interface IVehicalRepository
    {
         Task<IEnumerable<Vehical>> GetAllVehical();
         Task<Vehical> GetVehical(int id, bool includeRelated = true);
          void Add(Vehical vehical);
          void Remove(Vehical vehical) ;

         
    }
}