using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementLibrary.Models
{
    public class Employee
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public int UserID { get; set; }
        [MaxLength(100)]
        public string FirstName { get; set; }
        [MaxLength(100)]
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }

        public bool? IsEmailActive { get; set; }
        public bool? IsSMSActive { get; set; }
        public bool? IsPushActive { get; set; }

        [Required]
        public int ManagerID { get; set; }
        public virtual User UserMapper { get; set; }
        public virtual User UserMapper2 { get; set; }
    }
}
