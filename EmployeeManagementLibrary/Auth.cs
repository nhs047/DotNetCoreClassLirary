using EmployeeManagementLibrary.DataAccess.Repository.IRepository;
using EmployeeManagementLibrary.Models;
using System.Linq;

namespace EmployeeManagementLibrary
{
    public class Auth
    {
        private readonly IUnitOfWork _unitOfWork;

        public Auth(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public User SignIn(string username, string password)
        {
            var user = _unitOfWork.User.GetAll(c=> c.UserName == username).FirstOrDefault();
            if (user == null && user.Password != password)
            {
                return null;
            }
            user.Password = null;
            return user;
        }
    }
}
