using MBCapital.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBCapital.Services
{
    public sealed class StockBrokerService
    {
        private static StockBrokerService instance;

        private List<StockBroker> brokers = null;

        private StockBrokerService()
        {
            if (brokers == null)
            {
                brokers = new List<StockBroker>();
            }
        }
        public static StockBrokerService GetInstance()
        {
            if (instance == null)
            {
                // Avoid multithread
                lock (typeof(StockBrokerService))
                {
                    instance = new StockBrokerService();
                }
            }
            return instance;
        }
        public void AddBroker(StockBroker broker)
        {
            brokers.Add(broker);
        }
        // Get a StockBroker
        public void DisplayBrokers()
        {
            Console.WriteLine("=== Brokers List ===");
            int count = 1;
            foreach (var broker in brokers)
            {
                Console.WriteLine(count + ") " + broker.ToString());
                count++;
            }
        }
        public List<StockBroker> GetBrokers()
        {
            return brokers;
        }
        public StockBroker GetBroker(int index)
        {
            return brokers[index];
        }
        public StockBroker CheckAccount(string gmail, string password)
        {
            foreach (var broker in brokers)
            {
                if (broker.Gmail == gmail && broker.Password == password)
                {
                    return broker;
                }
            }

            return null;
        }
        public void DisplayMyInvestors(StockBroker broker)
        {
            Console.WriteLine(broker.DisplayMyInvestors());
        }
    }
}
