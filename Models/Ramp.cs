using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace wrts.Models
{
    public class Ramp
    {
        [Key]

        public int RampID { get; set; }
        
        public int VehiclesID { get; set; }
        public virtual Vehicles Vehicles { get; set; }
    }
}
