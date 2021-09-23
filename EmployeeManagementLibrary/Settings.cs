using System;
using EmployeeManagementLibrary.DataAccess.Repository.IRepository;

namespace EmployeeManagementLibrary
{
    public class Settings
    {
        private readonly IUnitOfWork _unitOfWork;

        public Settings(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool ChangeNotificationSetting(int userId, bool isMailActive, bool isSmsActive, bool isPushActive)
        {
            try
            {
                var empInfo = _unitOfWork.Employee.GetFirstOrDefult(x=> x.UserID == userId);

                empInfo.IsEmailActive = isMailActive;
                empInfo.IsPushActive = isPushActive;
                empInfo.IsSMSActive = isSmsActive;

                _unitOfWork.Employee.Update(empInfo);

                return true;

            } catch(Exception ex)
            {
                return false;
            }
        }
    }
}
