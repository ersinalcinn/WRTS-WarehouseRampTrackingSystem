using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace wrts.Models
{
    public class RampStates
    {
        public int RampStatesID { get; set; }
        [Required]
        [MaxLength(50)]
        [DisplayName("Ramp States  :")]
        public string RampStateName { get; set; }
    }
}
