using EmployeeManagementLibrary.Models;

namespace EmployeeManagementLibrary.DataAccess.Repository.IRepository
{
    public interface IRoleRepository: IRepository<Role>
    {
        void Update(Role role);
    }
}
