using MBCapital.Entities;
using MBCapital.Helpers;
using MBCapital.Pages;
using MBCapital.Services;
using System;

namespace MBCapital
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Add some sample data
            new Data();

            // Initialize Services (Singleton Patterns)
            StockBrokerService brokerService = StockBrokerService.GetInstance();
            InvestorService investorService = InvestorService.GetInstance();
            FundService fundService = FundService.GetInstance();

            Console.WriteLine("=== WELCOME TO MBCAPITAL ===");
            while (true)
            {
                Console.Write("=======> ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("HOME PAGE");
                Console.ResetColor();
                Console.WriteLine(" <========");
                Console.WriteLine("      1. StockBroker");
                Console.WriteLine("      2. Investor");
                Console.WriteLine("      3. Sign up");
                Console.WriteLine("      4. Exit");
                Console.WriteLine("============================");

                string input;
                do
                {
                    Console.Write("Enter your choice? ");
                    input = Console.ReadLine();
                } while (!CheckValid.CheckValidChoice(input, 1, 4));

                switch (input)
                {
                    case "1":
                        try
                        {
                            Console.WriteLine("=> LOGIN PAGE FOR BROKER");
                            Console.Write("Gmail: ");
                            string brokerGmail = Console.ReadLine();
                            Console.Write("Password: ");
                            string brokerPassword = Console.ReadLine();

                            StockBroker broker = brokerService.CheckAccount(brokerGmail, brokerPassword);
                            if (broker != null)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Login successfully!");
                                Console.ResetColor();
                                BrokerPage brokerUI = new BrokerPage(fundService, brokerService);
                                brokerUI.Run(broker);
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Try Again");
                                Console.ResetColor();
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("An error occurs: " + ex.Message);
                            Console.ResetColor();
                        }
                        break;
                    case "2":
                        try
                        {
                            Console.WriteLine("=> LOGIN PAGE FOR INVESTOR");
                            Console.Write("Gmail: ");
                            string gmail = Console.ReadLine();
                            Console.Write("Password: ");
                            string password = Console.ReadLine();

                            Investor investor = investorService.CheckAccount(gmail, password);
                            if (investor != null)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Login successfully!");
                                Console.ResetColor();
                                InvestorPage investorUI = new InvestorPage(fundService);
                                investorUI.Run(investor);
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Try Again");
                                Console.ResetColor();
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("An error occurs: " + ex.Message);
                            Console.ResetColor();
                        }
                        break;
                    case "3":
                        try
                        {
                            CreateAccountPage createAccountPageUI = new CreateAccountPage(investorService, brokerService);
                            createAccountPageUI.Run();
                        }
                        catch (Exception ex)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("An error occurs: " + ex.Message);
                            Console.ResetColor();
                        }
                        break;
                    default:
                        Console.WriteLine("<3 Thank you for your trust in MBCapital <3");
                        return;
                }
            }
        }
    }
}
