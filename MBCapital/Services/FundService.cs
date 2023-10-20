using MBCapital.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MBCapital.Services
{
    public sealed class FundService
    {
        private static FundService instance;

        private List<Fund> funds = null;

        private FundService()
        {
            if (funds == null)
            {
                funds = new List<Fund>();
            }
        }
        public static FundService GetInstance()
        {
            if (instance == null)
            {
                // Avoid multithread
                lock (typeof(FundService))
                {
                    instance = new FundService();
                }
            }
            return instance;
        }
        // Add Fund to Fund List
        public void AddFund(Fund fund)
        {
            funds.Add(fund);
        }
        public Fund GetFund(string ticket)
        {
            foreach (Fund fund in funds)
            {
                if (fund.Ticket.ToLower() == ticket.ToLower())
                    return fund;
            }
            return null;
        }
        public List<Fund> GetFunds()
        {
            return funds;
        }
        public void DisplayFunds()
        {
            Console.WriteLine("*) Funds List");
            Console.WriteLine(String.Format("|{0,-38}|{1,-7}|{2,-15}|{3,-15}|", "Name", "Ticket", "Inception Date", "Management Fee"));
            foreach (var fund in funds)
            {
                Console.WriteLine(fund.ToString());
            }    
        }
    }
}
