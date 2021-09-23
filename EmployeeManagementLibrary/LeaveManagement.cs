using System;
using EmployeeManagementLibrary.Models;
using EmployeeManagementLibrary.HelperServices;
using EmployeeManagementLibrary.DataAccess.Repository.IRepository;


namespace EmployeeManagementLibrary
{
    public class LeaveManagement
    {
        private readonly IUnitOfWork _unitOfWork;

        public LeaveManagement(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool ApplyLeave(Employee emp, DateTime StartedOn, DateTime EndOn)
        {
            var managerInfo = _unitOfWork.User.Get(emp.ManagerID);
            var managerEmployeeInfo = _unitOfWork.Employee.GetFirstOrDefult(x=> x.UserID == emp.ManagerID);
            NotificationHelper.SingleNotificationSender(managerInfo, managerEmployeeInfo, $"{emp.FirstName} {emp.LastName} has requested a leave from {StartedOn} to {EndOn}");

            return true;
        }

        public bool LeaveApproval(Employee managerInfo, int empId, DateTime StartedOn, DateTime EndOn, bool isApproved)
        {

            var employeeInfo = _unitOfWork.Employee.GetFirstOrDefult(x => x.ID == empId);
            var user = _unitOfWork.User.Get(employeeInfo.UserID);
            NotificationHelper.SingleNotificationSender(user, employeeInfo, $"Your Manager has approveed your leave from {StartedOn} to {EndOn}");
            return true;
        }
    }
}
