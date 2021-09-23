using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementLibrary.Models
{
    public class Role
    {
        [Key]
        public int ID { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
