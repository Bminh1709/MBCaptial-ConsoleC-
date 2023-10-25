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
    internal class CreateAccountPage
    {
        private readonly InvestorService investorService;
        private readonly StockBrokerService brokerService;

        public CreateAccountPage(InvestorService investorService, StockBrokerService brokerService)
        {
            this.investorService = investorService;
            this.brokerService = brokerService;
        }

        public void Run()
        {
            try
            {
                Console.WriteLine("=> REGISTER PAGE");
                Console.Write("Name: ");
                string name = Console.ReadLine();

                Console.Write("Gmail (include @): ");
                string gmail = Console.ReadLine();

                Console.Write("Password (at least 6 characters): ");
                string password = Console.ReadLine();

                Console.Write("PIN (exactly 5 characters): ");
                string pin = Console.ReadLine();

                brokerService.DisplayBrokers();
                int brokerNo = CheckValid.CheckValidBroker(brokerService.GetBrokers());

                try
                {
                    Boolean isAccountExist = false;
                    isAccountExist = investorService.IsAccountExist(gmail);
                    if (isAccountExist) // Account Existed
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("This account has been existed!");
                        Console.ResetColor();
                    }
                    else
                    {
                        Investor investor = new Investor(name, gmail, password, pin, brokerService.GetBroker(brokerNo));
                        investorService.AddInvestor(investor);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Create account successfully, please login!");
                        Console.ResetColor();
                    }
                }
                catch (ArgumentException)
                {
                    throw;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
