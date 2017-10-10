namespace carvecho.Controllers.Resources
{
    public class VehicalQueryResource 
    {
        public int? MakeId { get; set; }
        public int? ModelId { get; set; }
        public string sortBy { get; set; }
        public bool IsSortAscending { get; set; }
        public int Page { get; set; }
        public byte PageSize { get; set; }


    }
}