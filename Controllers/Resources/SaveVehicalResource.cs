using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace carvecho.Controllers.Resources
{
    public class SaveVehicalResource
    {

        public int Id { get; set; }
        public int ModelId { get; set; }

        public bool IsRegistered { get; set; }
     
        [Required]
        public ContactResource Contact { get; set; }
        public ICollection<int> Features { get; set; }
        public SaveVehicalResource()
        {
            Features =  new Collection<int>();
        }

    }
}