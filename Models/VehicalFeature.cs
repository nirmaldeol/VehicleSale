namespace carvecho.Models
{
    public class VehicalFeature
    {
        public int VehicalId { get; set; }
        public int FeatureId { get; set; }

        public Vehical Vehical { get; set; }    
        public Feature Feature { get; set; }
    }
}