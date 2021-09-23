using System;
using System.Collections.Generic;
using EmployeeManagementLibrary.Contracts;

namespace EmployeeManagementLibrary.ContractImplementations
{
    public class SMSSender : INotificationSender
    {
        public List<string> Identifiers { get; set; }
        public string Message { get; set; }

        public SMSSender(List<string> identifiers, string message)
        {
            Identifiers = identifiers;
            Message = message;
        }

        public void SendNotification()
        {
            foreach (var identifier in Identifiers)
            {
                Console.WriteLine($"SMS send to {identifier}");
            }
        }
    }
}
