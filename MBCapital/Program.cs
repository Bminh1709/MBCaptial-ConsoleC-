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

            InvestorPage investorUI = new InvestorPage(fundService);
            BrokerPage brokerUI = new BrokerPage(fundService, brokerService);
            CreateAccountPage createAccountPageUI = new CreateAccountPage(investorService, brokerService);

            while (true)
            {
                Console.WriteLine("=========== WELCOME TO MBCAPITAL ===========");
                Console.WriteLine("=> HOME PAGE");
                Console.WriteLine("1. StockBroker");
                Console.WriteLine("2. Investor");
                Console.WriteLine("3. Create new account");
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
                                brokerUI.Run(broker);
                            }
                            else
                            {
                                Console.WriteLine("Try Again");
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
                                investorUI.Run(investor);
                            }
                            else
                            {
                                Console.WriteLine("Try Again");
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

        //public static void StockBrokerPage(StockBroker broker)
        //{
        //    FundService fundService = FundService.GetInstance();
        //    StockBrokerService stockBrokerService = StockBrokerService.GetInstance();
        //    while (true)
        //    {
        //        Console.WriteLine("============================================");
        //        Console.WriteLine($"** WELCOME BACK {broker.Name} **");
        //        Console.WriteLine("1. View Funds");
        //        Console.WriteLine("2. Manage Invester");
        //        Console.WriteLine("3. Notify");
        //        Console.WriteLine("4. Exit");
        //        Console.WriteLine("============================================");

        //        string input;
        //        do
        //        {
        //            Console.Write("Enter your choice? ");
        //            input = Console.ReadLine();
        //        } while (!CheckValid.checkValidChoice(input, 1, 4));

        //        switch (input)
        //        {
        //            case "1":
        //                Console.ForegroundColor = ConsoleColor.Yellow;
        //                fundService.DisplayFunds();
        //                Console.ResetColor();
        //                break;
        //            case "2":
        //                Console.ForegroundColor = ConsoleColor.Yellow;
        //                stockBrokerService.DisplayMyInvestors(broker);
        //                Console.ResetColor();
        //                break;
        //            case "3":
        //                string ticket;
        //                string trend;
        //                do
        //                {
        //                    Console.Write("Choose a ticket that changes: ");
        //                    ticket = Console.ReadLine();
        //                } while (!CheckValid.checkValidFund(ticket, fundService.GetFunds()));
        //                do
        //                {
        //                    Console.WriteLine("Trend:");
        //                    Console.WriteLine("1) Grow");
        //                    Console.WriteLine("2) Decline");
        //                    Console.Write("Choose a trend (1 or 2): ");
        //                    trend = Console.ReadLine();
        //                } while (!CheckValid.checkValidChoice(trend, 1, 2));
        //                Console.ForegroundColor = ConsoleColor.Red;
        //                Console.WriteLine("Notifying:");
        //                broker.MarketChange(fundService.GetFund(ticket), trend);
        //                Console.ResetColor();
        //                break;
        //            default:
        //                Console.ForegroundColor = ConsoleColor.Blue;
        //                Console.WriteLine("Logout successfully!");
        //                Console.ResetColor();
        //                return;
        //        }
        //    }
        //}

        //public static void InvestorPage(Investor investor)
        //{
        //    FundService fundService = FundService.GetInstance();
        //    while (true)
        //    {
        //        Console.WriteLine("============================================");
        //        Console.WriteLine($"** WELCOME BACK {investor.Name} **");
        //        Console.WriteLine("1. View Funds");
        //        Console.WriteLine("2. Place Order");
        //        Console.WriteLine("3. Deposit Money");
        //        Console.WriteLine("4. Withdraw Money");
        //        Console.WriteLine("5. My Funds");
        //        Console.WriteLine("6. Profile");
        //        Console.WriteLine("7. Exit");
        //        Console.WriteLine("============================================");

        //        string input;
        //        do
        //        {
        //            Console.Write("Enter your choice? ");
        //            input = Console.ReadLine();
        //        } while (!CheckValid.checkValidChoice(input, 1, 7));

        //        switch (input)
        //        {
        //            case "1":
        //                Console.ForegroundColor = ConsoleColor.Yellow;
        //                fundService.DisplayFunds();
        //                Console.ResetColor();
        //                break;
        //            case "2":
        //                string ticket;
        //                string money;
        //                do
        //                {
        //                    Console.Write("Choose a ticket: ");
        //                    ticket = Console.ReadLine();
        //                } while (!CheckValid.checkValidFund(ticket, fundService.GetFunds()));
        //                do
        //                {
        //                    Console.Write("Amount of money: ");
        //                    money = Console.ReadLine();
        //                } while (!CheckValid.checkValidAmount(money));
        //                Console.WriteLine(investor.PlaceOrder(fundService.GetFund(ticket), decimal.Parse(money)));
        //                break;
        //            case "3":
        //                string depositAmount;
        //                decimal validDepositAmount = 0;
        //                do
        //                {
        //                    Console.Write("Amount of money: ");
        //                    depositAmount = Console.ReadLine();
        //                } while (!decimal.TryParse(depositAmount, out validDepositAmount));

        //                Console.WriteLine(investor.Deposit(validDepositAmount));
        //                break;
        //            case "4":
        //                string withdrawAmount;
        //                decimal validWithdrawAmount = 0;
        //                do
        //                {
        //                    Console.Write("Amount of money: ");
        //                    withdrawAmount = Console.ReadLine();
        //                } while (!decimal.TryParse(withdrawAmount, out validWithdrawAmount));

        //                Console.WriteLine(investor.WithDraw(validWithdrawAmount));
        //                break;
        //            case "5":
        //                Console.ForegroundColor = ConsoleColor.Yellow;
        //                Console.WriteLine(investor.DisplayMyFunds());
        //                Console.ResetColor();
        //                break;
        //            case "6":
        //                Console.ForegroundColor = ConsoleColor.Blue;
        //                Console.WriteLine(investor.ToString());
        //                Console.ResetColor();
        //                break;
        //            default:
        //                Console.ForegroundColor = ConsoleColor.Blue;
        //                Console.WriteLine("Logout successfully!");
        //                Console.ResetColor();
        //                return;
        //        }
        //    }
        //}

        //public static void CreateAccount()
        //{
        //    StockBrokerService stockBrokerService = StockBrokerService.GetInstance();
        //    InvestorService investorService = InvestorService.GetInstance();

        //    try
        //    {
        //        Console.WriteLine("=> REGISTER PAGE");
        //        Console.Write("Name: ");
        //        string name = Console.ReadLine();

        //        Console.Write("Gmail (include @): ");
        //        string gmail = Console.ReadLine();

        //        Console.Write("Password (at least 6 characters): ");
        //        string password = Console.ReadLine();

        //        Console.Write("PIN (exactly 5 characters): ");
        //        string pin = Console.ReadLine();

        //        Console.Write("Balance (greater than 0): ");
        //        string balance = Console.ReadLine();

        //        stockBrokerService.DisplayBrokers();
        //        int brokerNo = CheckValid.CheckValidBroker(stockBrokerService.GetBrokers());

        //        try
        //        {
        //            Boolean checkCreateAccount = false;
        //            do
        //            {
        //                checkCreateAccount = investorService.AddInvestor(new Investor(name, gmail, password, pin, decimal.Parse(balance), stockBrokerService.GetBroker(brokerNo)));
        //            } while (!checkCreateAccount);
                        
        //            Console.ForegroundColor = ConsoleColor.Green;
        //            Console.WriteLine("Create account successfully, please login!");
        //            Console.ResetColor();
        //        }
        //        catch (ArgumentException ex)
        //        {
        //            Console.ForegroundColor = ConsoleColor.Red;
        //            Console.WriteLine("Invalid input: " + ex.Message);
        //            Console.ResetColor();
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        Console.ForegroundColor = ConsoleColor.Red;
        //        Console.WriteLine("Invalid input. Try again!");
        //        Console.ResetColor();
        //    }
        //}
    }
}
