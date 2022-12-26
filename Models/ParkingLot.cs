using System.ComponentModel.DataAnnotations;

namespace wrts.Models
{
    public class ParkingLot
    {
        public int ParkingLotID { get; set; }
        [Required]
        [MaxLength(50)]
        [Display(Name = "Parking Lot Name   :")]
        public string ParkingLotName { get; set; }
        
        [Display(Name = "Vehicle Type  :")]
        public int vehicleID { get; set; }
    }
}
