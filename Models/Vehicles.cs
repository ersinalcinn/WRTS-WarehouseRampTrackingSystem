using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace wrts.Models
{
    public class Vehicles
    {
        [Key]
        [AllowNull]
        public Nullable<int> VehicleID { get; set; }
        
        public int VehicleTypeID { get; set; }
        [Required(ErrorMessage ="Company name can not be empty...")]
        public string company_name { get; set; } 
        public int waybill_number { get; set; }
        [Required(ErrorMessage = "Driver name can not be empty...")]
        public string driver_name { get; set; }
        [Required(ErrorMessage = "Driver surname can not be empty...")]
        public string driver_surname { get; set; }
        [Required(ErrorMessage = "Driver's language can not be empty...")]
        public string driver_language { get; set; }
        [Required(ErrorMessage = "Driver's phone number can not be empty...")]
        [StringLength(25,ErrorMessage= "Please do not enter phone number over 25 characters")]
        [Phone]
        public string phone_number { get; set; }
        [Required(ErrorMessage = "Driver's citizenship number can not be empty...")]
        [MaxLength(25,ErrorMessage = "Please do not enter phone number over 25 characters")]
        public string citizenship_number { get; set; }
        public DateTime arrival_time {  get; set; }
        public DateTime departure_time { get; set; }
        [Required(ErrorMessage = "Vehicle status can not be empty...")]
        public int vehicle_status { get; set; }
        
        public string description { get; set; }


        

    }
}
