using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace SOLID.DI
{
    public interface INotification 
    {
        void Send();
    }
    public class Email : INotification
    {
        public string Correo { get; set; }
        

        public void Send()
        {
            Console.WriteLine("Send Notification");
        }
    }
    public class NotificationService
    {
        public void SendNotification(INotification notification)
        {
            notification.Send();
        }
    }
}
