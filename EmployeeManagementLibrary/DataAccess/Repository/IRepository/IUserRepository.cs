using EmployeeManagementLibrary.Models;

namespace EmployeeManagementLibrary.DataAccess.Repository.IRepository
{
    public interface IUserRepository: IRepository<User>
    {
        void Update(User user);
    }
}