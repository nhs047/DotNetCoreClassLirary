using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using EmployeeManagementLibrary.Models;
using EmployeeManagementLibrary.Utilities;
using EmployeeManagementLibrary.HelperServices;
using EmployeeManagementLibrary.Models.ViewModel;
using EmployeeManagementLibrary.DataAccess.Repository.IRepository;

namespace EmployeeManagementLibrary
{
    public class Profile
    {
        public readonly IUnitOfWork _unitofWork;
   

        public Profile(IUnitOfWork unitofWork)
        {
            _unitofWork = unitofWork;
        }

        public Employee GetOwnProfile(int id)
        {
            var employee = _unitofWork.Employee.GetFirstOrDefult(c => c.UserID == id);
            return employee;
        }

        public bool UpdateProfile(Employee emp)
        {
            try
            {
                _unitofWork.Employee.Update(emp);
                _unitofWork.Save();
                
                var ownAndManagerInfo = _unitofWork.User.GetAll(x=> x.ID == emp.ManagerID || x.ID == emp.UserID).ToList();
                var ownInfo = ownAndManagerInfo.Find(x=>x.ID == emp.UserID);
                var mamnagerInfo = ownAndManagerInfo.Find(x => x.ID == emp.UserID);
                NotificationHelper.SingleNotificationSender(ownInfo, emp, "your Profile has updated successfully!");
                OtherNotificationSender(mamnagerInfo, emp);
                return true;
            } catch(Exception ex)
            {
                return false;
            }
        }

        public void OtherNotificationSender(User user,Employee emp)
        {
            var roleTableIds = _unitofWork.Role.GetAll(c => c.Name == EmployeeManagementConstants.HRManger).Select(x => x.ID);

            var hrManagerInfo = _unitofWork.UserRoleMap.GetAll(x => roleTableIds.Contains(x.RoleID), includeProperties: "User").Select(x => new { id = x.user.ID, mail = x.user.UserName });

            Hashtable hrManagerHash = new Hashtable();

            foreach (var hrManager in hrManagerInfo)
            {
                hrManagerHash.Add(hrManager.id, hrManager.mail);
            }

            hrManagerHash.Add(user.ID, user.UserName);

            List<int> keys = hrManagerHash.Keys.Cast<int>().ToList();

            var permissions = _unitofWork.Employee.GetAll(x => keys.Contains(x.UserID)).Select(x =>
                new Permission { Id = x.UserID, PhoneNo = x.PhoneNumber, IsEmailActive = x.IsEmailActive, IsPushActive = x.IsPushActive, IsSMSActive = x.IsSMSActive }
            ).ToList();
            NotificationHelper.SendNotificaton(hrManagerHash, permissions, $"{emp.FirstName} {emp.LastName} has changed his profile!");
        }

      
    }
}


