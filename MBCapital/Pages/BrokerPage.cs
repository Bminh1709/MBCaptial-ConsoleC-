using MBCapital.Entities;
using MBCapital.Helpers;
using MBCapital.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBCapital.Pages
{
    public class BrokerPage
    {
        private readonly FundService fundService;
        private readonly StockBrokerService brokerService;

        public BrokerPage(FundService fundService, StockBrokerService brokerService)
        {
            this.fundService = fundService;
            this.brokerService = brokerService;
        }

        public void Run(StockBroker broker)
        {
            while (true)
            {
                Console.WriteLine("============================================");
                Console.WriteLine($"** WELCOME BACK {broker.Name} **");
                Console.WriteLine("1. View Funds");
                Console.WriteLine("2. Manage Invester");
                Console.WriteLine("3. Notify");
                Console.WriteLine("4. Exit");
                Console.WriteLine("============================================");

                string input;
                do
                {
                    Console.Write("Enter your choice? ");
                    input = Console.ReadLine();
                } while (!CheckValid.checkValidChoice(input, 1, 4));

                switch (input)
                {
                    case "1":
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        fundService.DisplayFunds();
                        Console.ResetColor();
                        break;
                    case "2":
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        brokerService.DisplayMyInvestors(broker);
                        Console.ResetColor();
                        break;
                    case "3":
                        try
                        {
                            string ticket;
                            string trend;
                            do
                            {
                                Console.Write("Choose a ticket that changes: ");
                                ticket = Console.ReadLine();
                            } while (!CheckValid.checkValidFund(ticket, fundService.GetFunds()));
                            do
                            {
                                Console.WriteLine("Trend:");
                                Console.WriteLine("1) Grow");
                                Console.WriteLine("2) Decline");
                                Console.Write("Choose a trend (1 or 2): ");
                                trend = Console.ReadLine();
                            } while (!CheckValid.checkValidChoice(trend, 1, 2));
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Notifying:");
                            broker.MarketChange(fundService.GetFund(ticket), trend);
                            Console.ResetColor();
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Logout successfully!");
                        Console.ResetColor();
                        return;
                }
            }
        }
    }
}
