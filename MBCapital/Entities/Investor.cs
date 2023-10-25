using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MBCapital.Entities
{
    public class Investor : Observer
    {
        private string name;
        private string gmail;
        private string password;
        private string pin;
        private decimal balance = 5;
        public StockBroker myStockBroker;
        public List<Fund> myFunds;
        private List<Notification> myNotifications;

        public string Name
        {
            get { return name; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    name = value;
                else
                    throw new ArgumentException("Name cannot be empty.");
            }
        }
        public string Gmail
        {
            get { return gmail; }
            set
            {
                if (!string.IsNullOrEmpty(value) && value.Contains("@"))
                    gmail = value;
                else
                    throw new ArgumentException("Invalid Gmail address.");
            }
        }
        public string Password
        {
            get { return password; }
            set 
            {
                if (!string.IsNullOrEmpty(value) && value.Length >= 6)
                    password = value;
                else
                    throw new ArgumentException("Password must be at least 6 characters long.");
            }
        }
        public string Pin
        {
            get { return pin; }
            set 
            {
                if (!string.IsNullOrEmpty(value) && value.Length == 5)
                    pin = value;
                else
                    throw new ArgumentException("PIN must be exactly 5 characters long.");
            }
        }
        public decimal Balance
        {
            get { return balance; }
            set
            {
                if (value >= 0)
                {
                    balance = value;
                } 
                else
                {
                    throw new ArgumentException("Balance cannot be negative.");
                }
            }
        }

        public string Deposit(decimal money)
        {
            if (money <= 0)
            {
                return "Deposit must be bigger than zero!";
            }
            else
            {
                Balance += money;
                return "Deposited $" + money + " Successfully. New balance: $" + Balance;
            }

        }
        public string WithDraw(decimal money)
        {
            if (money > 0 && money <= Balance)
            {
                Balance -= money;
                return "Withdrawn $" + money + " Successfully. New balance: $" + Balance;
            }
            else if (money <= 0)
            {
                return "The amount of money should be positive!";
            }    
            else
            {
                return "Please, you do not have enough money to withdraw!";
            }
        }
        public Investor(string name, string gmail, string password, string pin, decimal balance, StockBroker stockBroker)
        {
            Name = name;
            Gmail = gmail;
            Password = password;
            Pin = pin;
            Balance = balance;
            myStockBroker = stockBroker;
            myStockBroker.AddToZone(this);
            myFunds = new List<Fund>();
            myNotifications = new List<Notification>();
        }
        public Investor(string name, string gmail, string password, string pin, StockBroker stockBroker)
        {
            Name = name;
            Gmail = gmail;
            Password = password;
            Pin = pin;
            myStockBroker = stockBroker;
            myStockBroker.AddToZone(this);
            myFunds = new List<Fund>();
            myNotifications = new List<Notification>();
        }

        public string PlaceOrder(Fund fund, decimal money)
        {
            if (money > Balance)
            {
                return "You do not have enough money, deposit more money.";
            }

            Fund foundFund = myFunds.Find(f => f == fund);

            if (foundFund == null)
            {
                Fund myFund = fund;
                myFund.Amount = money;
                Balance -= money;
                myFunds.Add(myFund);

                return $"You have deposited ${money} into {fund.Ticket}. Congratulations!";
            }    
            else
            {
                Balance -= money;
                foundFund.Amount += money;
                return $"The money has been accumulated. {fund.Ticket}: ${money}";
            }    
        }
        
        public string DisplayMyFunds()
        {
            if (myFunds.Count < 1)
            {
                return "You haven't own any funds";
            }
            int count = 1;
            string text;
            text = "*) My Funds List \n";
            text += String.Format("|{0,-38}|{1,-7}|{2,-15}|{3,-15}|\n", "Name", "Ticket", "Management Fee", "Amount");
            foreach (Fund f in myFunds)
            {
                if (myFunds.Count() == count)
                {
                    text += String.Format("|{0,-38}|{1,-7}|{2,-15}|{3,-15}|", f.Name, f.Ticket, f.ManagementFee + "%", "$" + f.Amount);
                }
                else
                {
                    text += String.Format("|{0,-38}|{1,-7}|{2,-15}|{3,-15}|\n", f.Name, f.Ticket, f.ManagementFee + "%", "$" + f.Amount);
                }
                count++;
            }
            return text;
        }

        public string DisplayMyNotifications()
        {
            if (myNotifications.Count < 1)
            {
                return "Empty";
            }
            int count = 1;
            string text;
            text = "*) My Notifications \n";
            text += String.Format("|{0,-28}|{1,-20}|{2,-20}|\n", "Date", "Message", "From");
            foreach (var item in myNotifications)
            {
                if (myNotifications.Count() == count)
                {
                    text += String.Format("|{0,-28}|{1,-20}|{2,-20}|", item.DateReceive, item.Message, item.BrokerName);
                }
                else
                {
                    text += String.Format("|{0,-28}|{1,-20}|{2,-20}|\n", item.DateReceive, item.Message, item.BrokerName);
                }
                count++;
            }
            return text;
        }

        public override string ToString()
        {
            return "=> Detail information\n" +
                $"Name: {Name}, \n" +
                $"Gmail: {Gmail}, \n" +
                $"Pin: {Pin}, \n" +
                $"Balance: ${Balance} \n" +
                $"=> Broker information \n" +
                $"Name: {myStockBroker.Name}, \n" +
                $"Gmail: {myStockBroker.Gmail}";
        }
        public override void Update(string ticket, string message)
        {
            Console.WriteLine($"{Name} got the news that {ticket} {message}");
            myNotifications.Add(new Notification(DateTime.Now, $"{ ticket } { message}", myStockBroker.Name));
        }
    }
}
