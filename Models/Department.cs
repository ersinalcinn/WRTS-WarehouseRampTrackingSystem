using System.ComponentModel.DataAnnotations;

namespace wrts.Models
{
    public class Department
    {
        [Key]
        public int DepartmentID { get; set; }

        public string DepartmentName { get; set; }

        public enum Departments
        {
            Admin,
            Security,
            RampStaff,
            Dispatcher
        }

    }
    
}
