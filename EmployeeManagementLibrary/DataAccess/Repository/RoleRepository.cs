using System.Linq;
using EmployeeManagementLibrary.Models;
using EmployeeManagementLibrary.DataAccess.Data;
using EmployeeManagementLibrary.DataAccess.Repository.IRepository;

namespace EmployeeManagementLibrary.DataAccess.Repository
{
    public class RoleRepository: Repository<Role>, IRoleRepository
    {
        private readonly EmployeeManagementDBContext _db;
        public RoleRepository(EmployeeManagementDBContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Role role)
        {
            var objFromDb = _db.Roles.FirstOrDefault(s => s.ID == role.ID);
            if (objFromDb != null)
            {
                objFromDb.Name = role.Name;
            }
        }
    }
}
