using System.Threading.Tasks;

namespace carvecho.Core
{

    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}