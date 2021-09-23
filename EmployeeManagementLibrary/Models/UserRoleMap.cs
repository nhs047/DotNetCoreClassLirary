using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagementLibrary.Models
{
    public class UserRoleMap
    {
        [Key]
        public int ID { get; set; }

        public int UserID { get; set; }
        [ForeignKey("UserID")]
        public User user { get; set; }

        public int RoleID { get; set; }
        [ForeignKey("RoleID")]
        public Role role { get; set; }
    }
}
