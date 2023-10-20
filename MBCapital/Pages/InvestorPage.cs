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
    public class InvestorPage
    {
        private readonly FundService fundService;

        public InvestorPage(FundService fundService)
        {
            this.fundService = fundService;
        }

        public void Run(Investor investor)
        {
            while (true)
            {
                Console.WriteLine("============================================");
                Console.WriteLine($"** WELCOME BACK {investor.Name} **");
                Console.WriteLine("1. View Funds");
                Console.WriteLine("2. Place Order");
                Console.WriteLine("3. Deposit Money");
                Console.WriteLine("4. Withdraw Money");
                Console.WriteLine("5. My Funds");
                Console.WriteLine("6. Profile");
                Console.WriteLine("7. Exit");
                Console.WriteLine("============================================");

                string input;
                do
                {
                    Console.Write("Enter your choice? ");
                    input = Console.ReadLine();
                } while (!CheckValid.checkValidChoice(input, 1, 7));

                switch (input)
                {
                    case "1":
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        fundService.DisplayFunds();
                        Console.ResetColor();
                        break;
                    case "2":
                        try
                        {
                            string ticket;
                            string money;
                            do
                            {
                                Console.Write("Choose a ticket: ");
                                ticket = Console.ReadLine();
                            } while (!CheckValid.checkValidFund(ticket, fundService.GetFunds()));
                            do
                            {
                                Console.Write("Amount of money: ");
                                money = Console.ReadLine();
                            } while (!CheckValid.checkValidAmount(money));
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine(investor.PlaceOrder(fundService.GetFund(ticket), decimal.Parse(money)));
                            Console.ResetColor();
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                        break;
                    case "3":
                        try
                        {
                            string depositAmount;
                            decimal validDepositAmount = 0;
                            do
                            {
                                Console.Write("Amount of money: ");
                                depositAmount = Console.ReadLine();
                            } while (!decimal.TryParse(depositAmount, out validDepositAmount));
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine(investor.Deposit(validDepositAmount));
                            Console.ResetColor();
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                        break;
                    case "4":
                        try
                        {
                            string withdrawAmount;
                            decimal validWithdrawAmount = 0;
                            do
                            {
                                Console.Write("Amount of money: ");
                                withdrawAmount = Console.ReadLine();
                            } while (!decimal.TryParse(withdrawAmount, out validWithdrawAmount));
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine(investor.WithDraw(validWithdrawAmount));
                            Console.ResetColor();
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                        break;
                    case "5":
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(investor.DisplayMyFunds());
                        Console.ResetColor();
                        break;
                    case "6":
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(investor.ToString());
                        Console.ResetColor();
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
