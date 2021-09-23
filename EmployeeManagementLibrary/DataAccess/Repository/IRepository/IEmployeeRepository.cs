using EmployeeManagementLibrary.Models;

namespace EmployeeManagementLibrary.DataAccess.Repository.IRepository
{
    public interface IEmployeeRepository: IRepository<Employee>
    {
        void Update(Employee emp);
    }
}
