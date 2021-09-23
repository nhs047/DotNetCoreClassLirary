using System.Linq;
using EmployeeManagementLibrary.Models;
using EmployeeManagementLibrary.DataAccess.Data;
using EmployeeManagementLibrary.DataAccess.Repository.IRepository;

namespace EmployeeManagementLibrary.DataAccess.Repository
{
    public class UserRoleMapRepository: Repository<UserRoleMap>, IUserRoleMapRepository
    {
        private readonly EmployeeManagementDBContext _db;
        public UserRoleMapRepository(EmployeeManagementDBContext db) : base(db)
        {
            _db = db;
        }
        public void Update(UserRoleMap userRoleMap)
        {
            var objFromDb = _db.UserRoleMaps.FirstOrDefault(s => s.ID == userRoleMap.ID);
            if (objFromDb != null)
            {
                objFromDb.RoleID = userRoleMap.RoleID;
                objFromDb.UserID = userRoleMap.UserID;
            }
        }
    }
}
