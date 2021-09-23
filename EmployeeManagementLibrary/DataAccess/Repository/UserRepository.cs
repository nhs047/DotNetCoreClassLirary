using System.Linq;
using EmployeeManagementLibrary.Models;
using EmployeeManagementLibrary.DataAccess.Data;
using EmployeeManagementLibrary.DataAccess.Repository.IRepository;

namespace EmployeeManagementLibrary.DataAccess.Repository
{
    public class UserRepository: Repository<User>, IUserRepository
    {

        private readonly EmployeeManagementDBContext _db;
        public UserRepository(EmployeeManagementDBContext db) : base(db)
        {
            _db = db;
        }
        public void Update(User user)
        {
            var objFromDb = _db.Users.FirstOrDefault(s => s.ID == user.ID);
            if (objFromDb != null)
            {
                objFromDb.UserName = user.Password;
                objFromDb.UserName = user.UserName;
            }
        }
    }
}
