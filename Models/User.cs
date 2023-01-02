using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace wrts.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        [MaxLength(50, ErrorMessage = "Maximum 50 karakter olmalıdır...")]
        [EmailAddress(ErrorMessage = "Geçerli bir mail adresi giriniz...")]
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Verify Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Şifreler eşleşmiyor...")]
        [Required]
        public string PasswordVerify { get; set; }
        [Required]
        [Display(Name = "Name")]
        [MaxLength(50, ErrorMessage = "Maximum 50 karakter olmalıdır...")]
        public string Name { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Maximum 50 karakter olmalıdır...")]
        [Display(Name = "Surname")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "You must provide a department")]
        [Display(Name = "Department")]
        [ForeignKey("DepartmentID")]
        public int DepartmentID { get; set; }
        public virtual Department Department { get; set; }

    }
}
