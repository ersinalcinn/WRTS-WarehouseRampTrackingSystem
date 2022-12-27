using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace wrts.Models
{
    public class ParkingSpot
    {
        public int ParkingSpotID { get; set; }
        [Required]
        [MaxLength(25)]
        [DisplayName("Park Status  :")]
        public string ParkStatus { get; set; }
        [DisplayName("Vehicle Identities  :")]

        public int VehicleID { get; set; }
        [DisplayName("Park Lot Name  :")]
        public int ParkingLotID { get; set; }



    }
}
