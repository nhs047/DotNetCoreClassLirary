
namespace EmployeeManagementLibrary.Models.ViewModel
{
    public class Permission
    {
        public int Id { get; set; }
        public string PhoneNo { get; set; }
        public bool? IsEmailActive { get; set; }
        public bool? IsPushActive { get; set; }
        public bool? IsSMSActive { get; set; }
    }
}
