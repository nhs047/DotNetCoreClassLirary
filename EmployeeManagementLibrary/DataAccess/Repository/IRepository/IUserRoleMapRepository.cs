using EmployeeManagementLibrary.Models;

namespace EmployeeManagementLibrary.DataAccess.Repository.IRepository
{
    public interface IUserRoleMapRepository: IRepository<UserRoleMap>
    {
        void Update(UserRoleMap userRoleMap);
    }
}
