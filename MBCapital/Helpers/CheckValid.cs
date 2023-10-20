using MBCapital.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace MBCapital.Helpers
{
    public static class CheckValid
    {
        public static Boolean checkValidChoice(string input, int min, int max)
        {
            if (int.TryParse(input, out int command))
            {
                if (command >= min && command <= max)
                    return true;
                else
                    return false;
            }
            else
            {
                return false;
            }
        }

        public static int CheckValidBroker(List<StockBroker> stockBrokers)
        {
            int length = stockBrokers.Count;

            int selectedIndex = 0;
            bool isValidInput = false;

            while (!isValidInput)
            {
                Console.Write("Choose a Stockbroker that you trust: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out selectedIndex) && selectedIndex >= 1 && selectedIndex <= length)
                {
                    isValidInput = true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid number. Please enter a valid number of stockbroker.");
                    Console.ResetColor();
                }
            }

            return selectedIndex - 1;
        }

        public static Boolean checkValidAmount(string input)
        {
            if (decimal.TryParse(input, out decimal money))
            {
                if (money <= 0)
                    return false;
                else
                    return true;
            }
            else
            {
                return false;
            }
        }

        public static Boolean checkValidFund(string ticket, List<Fund> funds)
        {
            foreach (var item in funds)
            {
                if (item.Ticket.ToLower() == ticket.ToLower())
                {
                    return true;
                }    
            }
            return false;
        }

    }

}
