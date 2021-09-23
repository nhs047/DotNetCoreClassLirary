using System;
using System.Collections.Generic;
using EmployeeManagementLibrary.Contracts;


namespace EmployeeManagementLibrary.ContractImplementations
{
    public class MailSender : INotificationSender
    {
        public List<string> Identifiers { get; set; }
        public string Message { get; set; }

        public MailSender(List<string> identifiers, string message)
        {
            Identifiers = identifiers;
            Message = message;
        }

        public void SendNotification()
        {
            foreach(var identifier in Identifiers)
            Console.WriteLine($"Mail send to {identifier}");
        }
    }
}
