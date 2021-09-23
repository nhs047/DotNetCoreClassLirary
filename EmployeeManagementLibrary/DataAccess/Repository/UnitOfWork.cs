using EmployeeManagementLibrary.DataAccess.Data;
using EmployeeManagementLibrary.DataAccess.Repository.IRepository;

namespace EmployeeManagementLibrary.DataAccess.Repository
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly EmployeeManagementDBContext _db;
        public IUserRepository User { get; private set; }
        public IRoleRepository Role { get; private set; }
        public IEmployeeRepository Employee { get; private set; }
        public IUserRoleMapRepository UserRoleMap { get; private set; }


        public UnitOfWork(EmployeeManagementDBContext db)
        {
            _db = db;
            User = new UserRepository(_db);
            Role = new RoleRepository(_db);
            Employee = new EmployeeRepository(_db);
            UserRoleMap = new UserRoleMapRepository(_db);
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }

    }
}
