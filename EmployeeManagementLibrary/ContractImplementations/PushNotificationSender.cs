using System;
using System.Collections.Generic;
using EmployeeManagementLibrary.Contracts;

namespace EmployeeManagementLibrary.ContractImplementations
{
    public class PushNotificationSender : INotificationSender
    {
        public List<string> Identifiers { get; set; }
        public string Message { get; set; }

        public PushNotificationSender(List<string> identifiers, string message)
        {
            Identifiers = identifiers;
            Message = message;
        }

        public void SendNotification()
        {
            foreach (var identifier in Identifiers)
            {
                Console.WriteLine($"Push Notification send to {identifier}");
            }
        }
    }
}
