namespace carvecho.Extensions
{
    public interface IQueryObject
    {
        string sortBy { get; set; }
        bool IsSortAscending { get; set; }
        int Page { get; set; }
        byte PageSize { get; set; }
    }
}