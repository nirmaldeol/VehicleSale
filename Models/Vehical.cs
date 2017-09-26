using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace carvecho.Models
{
    [Table("Vehicals")]
    public class Vehical
    {
        public int Id { get; set; }
        public int ModelId { get; set; }
        public Model Model { get; set; }
        public bool IsRegistered { get; set; }

        [Required]
        [StringLength(255)]
        public string ContactName { get; set; }

        [Required]
        [StringLength(255)]
        public string ContactPhone { get; set; }
        
        [StringLength(255)]
        public string ContactEmail { get; set; }
        public DateTime LastUpdate { get; set; }
        public ICollection<VehicalFeature> Features { get; set; }

        public Vehical()
        {
            Features =  new Collection<VehicalFeature>();
        }
    }
}