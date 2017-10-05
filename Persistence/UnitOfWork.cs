using System.Threading.Tasks;
using carvecho.Core;
namespace carvecho.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CarVechoDbContext context;
        public UnitOfWork(CarVechoDbContext context)
        {
            this.context = context;

        }

        public  async Task CompleteAsync()
        {
            await context.SaveChangesAsync();
        }

    }
}