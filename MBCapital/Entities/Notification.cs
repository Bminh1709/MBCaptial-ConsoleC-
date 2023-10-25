using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBCapital.Entities
{
    internal class Notification
    {
        private DateTime dateReceive;
        private string message;
        private string brokerName;
        public DateTime DateReceive 
        { 
            get { return dateReceive; } set {  dateReceive = value; }
        }
        public string Message
        {
            get { return message; }
            set { message = value; }
        }
        public string BrokerName
        {
            get { return brokerName; }
            set { brokerName = value; }
        }

        public Notification(DateTime dateReceive, string message, string brokerName)
        {
            DateReceive = dateReceive;
            Message = message;
            BrokerName = brokerName;
        }
    }
}
