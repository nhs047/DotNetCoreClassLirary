using System.Linq;
using EmployeeManagementLibrary.Models;
using EmployeeManagementLibrary.DataAccess.Data;
using EmployeeManagementLibrary.DataAccess.Repository.IRepository;

namespace EmployeeManagementLibrary.DataAccess.Repository
{
    class EmployeeRepository: Repository<Employee>, IEmployeeRepository
    {
        private readonly EmployeeManagementDBContext _db;
        public EmployeeRepository(EmployeeManagementDBContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Employee emp)
        {
            var objFromDb = _db.Employees.FirstOrDefault(s => s.ID == emp.ID);
            if (objFromDb != null)
            {
                objFromDb.FirstName = emp.FirstName;
                objFromDb.LastName = emp.LastName;
                objFromDb.PhoneNumber = emp.PhoneNumber;
            }
        }
    }
}
