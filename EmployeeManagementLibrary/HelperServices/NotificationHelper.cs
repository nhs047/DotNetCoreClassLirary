using System.Collections;
using System.Collections.Generic;
using EmployeeManagementLibrary.Models;
using EmployeeManagementLibrary.Models.ViewModel;
using EmployeeManagementLibrary.ContractImplementations;

namespace EmployeeManagementLibrary.HelperServices
{
    public class NotificationHelper
    {

        public static void SingleNotificationSender(dynamic ownInfo, Employee emp, string message)
        {
            SendNotificaton(
                   new Hashtable {
                        { ownInfo.ID, ownInfo.UserName}
                   },
                   new List<Permission> {
                        new Permission {
                            Id= ownInfo.ID,
                            IsEmailActive = emp.IsEmailActive,
                            IsPushActive = emp.IsPushActive,
                            IsSMSActive = emp.IsSMSActive
                        }
                   },
                   message);
        }

        public static bool SendNotificaton(Hashtable hash, List<Permission> permissions, string message)
        {
            List<string> notifiedEmails = new List<string>();
            List<string> notifiedSMS = new List<string>();
            List<string> notifiedPush = new List<string>();

            foreach (var permission in permissions)
            {
                if (permission.IsEmailActive == true)
                {
                    notifiedEmails.Add(hash[permission.Id].ToString());
                }
                if (permission.IsPushActive == true)
                {
                    notifiedPush.Add(hash[permission.Id].ToString());

                }
                if (permission.IsSMSActive == true)
                {
                    notifiedSMS.Add(permission.PhoneNo);
                }
            }

            if (notifiedEmails.Count > 0)
            {
                MailSender _mailSender = new MailSender(notifiedEmails, message);
                _mailSender.SendNotification();
            }
            if (notifiedPush.Count > 0)
            {
                PushNotificationSender _pushSender = new PushNotificationSender(notifiedPush, message);
                _pushSender.SendNotification();
            }

            if (notifiedSMS.Count > 0)
            {
                SMSSender _smsSender = new SMSSender(notifiedSMS, message);
                _smsSender.SendNotification();
            }
            return true;
        }
    }
}
