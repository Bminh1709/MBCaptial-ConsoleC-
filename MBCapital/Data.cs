using MBCapital.Entities;
using MBCapital.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBCapital
{
    internal class Data
    {
        public Data()
        {
            // Initialize Services (Singleton Patterns)
            StockBrokerService brokerService = StockBrokerService.GetInstance();
            InvestorService investorService = InvestorService.GetInstance();
            FundService fundService = FundService.GetInstance();

            // Initialize some stockBrokers
            StockBroker broker = new StockBroker("Thanh Thao", "t@gmail.com", "123");
            StockBroker broker2 = new StockBroker("Khanh Quynh", "khanhquynh@gmail.com", "123");

            // Add brokers to Data Storage
            brokerService.AddBroker(broker);
            brokerService.AddBroker(broker2);

            // Initialize some Investors
            investorService.AddInvestor(new Investor("Long", "long@", "123456", "12412", 20000, broker));
            investorService.AddInvestor(new Investor("Nghia", "nghia@gmail.com", "678910", "45743", 10000, broker));
            investorService.AddInvestor(new Investor("Thanh", "thanh@gmail.com", "234567", "23432", 500000, broker2));

            fundService.AddFund(new Fund("MBCapital Equity Special Access Fund", "MBSAF", new DateTime(2015, 12, 31), 0.65));
            fundService.AddFund(new Fund("MBCapital Equity Opportunity Fund", "VEOF", new DateTime(2019, 6, 30), 1.75));
            fundService.AddFund(new Fund("MBCapital Insights Balanced Fund", "VIBF", new DateTime(2010, 1, 15), 1.85));
            fundService.AddFund(new Fund("MBCapital Enhanced Fixed Income Fund", "VFF", new DateTime(2021, 12, 12), 0.67));
        }
    }
}
