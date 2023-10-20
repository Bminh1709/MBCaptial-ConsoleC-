using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBCapital.Entities
{
    public class Fund
    {
        private string name;
        private string ticket;
        private DateTime inceptionDate;
        private double managementFee;
        private decimal amount;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Ticket
        {
            get { return ticket; }
            set { ticket = value; }
        }
        public DateTime InceptionDate
        {
            get { return inceptionDate; }
            set { inceptionDate = value; }
        }
        public double ManagementFee
        {
            get { return managementFee; }
            set { managementFee = value; }
        }
        public decimal Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        public Fund(string name, string ticket, DateTime inceptionDate, double managementFee)
        {
            Name = name;
            Ticket = ticket;
            InceptionDate = inceptionDate;
            ManagementFee = managementFee;
            Amount = 0;
        }

        public override string ToString()
        {
            return String.Format("|{0,-38}|{1,-7}|{2,-15}|{3,-15}|", Name, Ticket, InceptionDate.ToString("d"), ManagementFee + "%");
        }
    }
}
