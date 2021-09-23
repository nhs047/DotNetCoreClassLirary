using System.Collections.Generic;

namespace EmployeeManagementLibrary.Contracts
{
    public interface INotificationSender
    {
        public List<string> Identifiers { get; set; }
        public string Message { get; set; }
        public void SendNotification();
    }
}
