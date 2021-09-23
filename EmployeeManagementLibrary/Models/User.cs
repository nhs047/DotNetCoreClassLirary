using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementLibrary.Models
{
    public class User
    {         
        [Key]
        public int ID { get; set; }

        [MaxLength(100)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [RegularExpression("^[a-zA-Z0-9_.-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$", ErrorMessage = "Must be a valid email")]
        public string UserName { get; set; }

        public virtual ICollection<Employee> UserIds { get; set; }
        public virtual ICollection<Employee> ManagerIds { get; set; }
    }
}
