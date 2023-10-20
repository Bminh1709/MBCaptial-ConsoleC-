using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MBCapital.Entities
{
    public class StockBroker
    {
        private string name;
        private string gmail;
        private string password;
        private List<Investor> myInvestors = new List<Investor>();
        private Boolean isMarketChange;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Gmail
        {
            get { return gmail; }
            set { gmail = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public Boolean IsMarketChange
        {
            get { return isMarketChange; }
            set { isMarketChange = value; }
        }

        public StockBroker(string name, string gmail, string password)
        {
            Name = name;
            Gmail = gmail;
            Password = password;
            isMarketChange = false;
        }

        public void AddToZone(Investor investor)
        {
            myInvestors.Add(investor);
        }

        public void MarketChange(Fund fund, string trend)
        {
            IsMarketChange = true;
            if (trend == "1")
                NotifyInvestors(fund.Ticket, "is growing...");
            else
                NotifyInvestors(fund.Ticket, "is declining...");
        }

        public void NotifyInvestors(string ticket, string message)
        {
            foreach (var investor in myInvestors)
            {
                investor.Update(ticket, message);
            }    
        }

        public override string ToString()
        {
            return $"Broker: {Name}, Gmail: {Gmail}";
        }

        public string DisplayMyInvestors()
        {
            string text = "*) My Investors List \n";
            text += String.Format("|{0,-10}|{1,-20}|{2,-20}|\n", "Name", "Gmail", "Joined Funds");
            int count = 1;
            foreach (var investor in myInvestors)
            {
                if (myInvestors.Count() == count)
                {
                    text += String.Format("|{0,-10}|{1,-20}|", investor.Name, investor.Gmail);
                    var joinedFunds = string.Join("-", investor.myFunds.Select(fund => fund.Ticket));
                    text += string.Format("{0,-20}|", joinedFunds);
                }
                else
                {
                    text += String.Format("|{0,-10}|{1,-20}|", investor.Name, investor.Gmail);
                    var joinedFunds = string.Join("-", investor.myFunds.Select(fund => fund.Ticket));
                    text += string.Format("{0,-20}|\n", joinedFunds);
                }
                count++;
            }
            return text;
        }
    }
}
