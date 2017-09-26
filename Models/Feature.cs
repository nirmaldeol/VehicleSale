using System.ComponentModel.DataAnnotations;

namespace carvecho.Models
{
    public class Feature
    {
        public int Id { get; set; }
        
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
    }
}