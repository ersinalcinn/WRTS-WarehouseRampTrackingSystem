using System.ComponentModel.DataAnnotations;

namespace wrts.Models
{
    public class VehicleType
    {
        public int VehicleTypeID { get; set; }
        [Required]
        [Display(Name = "Araç Türü ")]
        public string VehicleTypeName { get; set; }

    }
}
