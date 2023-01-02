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
        [Display(Name = "Vehicle Type ID")]
        public int VehicleTypeID { get; set; }
        [Display(Name = "Company Name")]
        [Required(ErrorMessage ="Company name can not be empty...")]
        public string company_name { get; set; }
        [Display(Name = "Waybill Number")]
        public int waybill_number { get; set; }
        [Required(ErrorMessage = "Driver name can not be empty...")]
        [Display(Name = "Driver Name")]
        public string driver_name { get; set; }
        [Required(ErrorMessage = "Driver surname can not be empty...")]
        [Display(Name = "Driver Surname")]
        public string driver_surname { get; set; }
        [Required(ErrorMessage = "Driver's language can not be empty...")]
        [Display(Name = "Driver Language")]
        public string driver_language { get; set; }
        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Driver's phone number can not be empty...")]
        [StringLength(25,ErrorMessage= "Please do not enter phone number over 25 characters")]
        [Phone]
        public string phone_number { get; set; }
        [Required(ErrorMessage = "Driver's citizenship number can not be empty...")]
        [Display(Name = "Citizenship Number")]
        [MaxLength(25,ErrorMessage = "Please do not enter phone number over 25 characters")]
        public string citizenship_number { get; set; }
        [Display(Name = "Arrival Time")]
        public DateTime arrival_time {  get; set; }
        [Display(Name = "Departure Time")]
        public DateTime departure_time { get; set; }
        [Display(Name = "Vehicle Status")]
        public int vehicle_status { get; set; }
        [Display(Name = "Description")]
        public string description { get; set; }


        

    }
}
