using carvecho.Extensions;

namespace carvecho.Core.Models
{
    public class VehicalQuery : IQueryObject
    {
        public int? MakeId { get; set; }

        public int? ModelId { get; set; }
        public string sortBy { get; set; }
        public bool IsSortAscending { get; set; }
        
        public int Page { get; set; }
        public byte PageSize { get; set; }
    }
}