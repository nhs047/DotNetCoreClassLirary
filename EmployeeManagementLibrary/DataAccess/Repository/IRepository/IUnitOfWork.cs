using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementLibrary.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork: IDisposable
    {
        IUserRepository User { get; }
        IEmployeeRepository Employee { get; }
        IRoleRepository Role { get; }
        IUserRoleMapRepository UserRoleMap { get; }
        void Save();
    }
}