using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace wrts.Models
{
    public class Ramp
    {
        [Key]

        public int RampID { get; set; }
        public int VehiclesID { get; set; }
       
      
    }
}
