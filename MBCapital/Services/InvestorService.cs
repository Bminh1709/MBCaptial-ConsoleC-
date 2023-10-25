using MBCapital.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBCapital.Services
{
    public sealed class InvestorService
    {
        private static InvestorService instance;

        private List<Investor> investors = null;

        private InvestorService()
        {
            if (investors == null)
            {
                investors = new List<Investor>();
            }
        }
        public static InvestorService GetInstance()
        {
            if (instance == null)
            {
                // Avoid multithread
                lock (typeof(InvestorService))
                {
                    instance = new InvestorService();
                }
            }
            return instance;
        }
        // Check Account
        public Investor CheckAccount(string gmail, string password)
        {
            foreach (var investor in investors)
            {
                if (investor.Gmail == gmail && investor.Password == password)
                {
                    return investor;
                }
            }

            return null;
        }

        public Boolean IsAccountExist(string gmail)
        {
            foreach (var item in investors)
            {
                if (gmail == item.Gmail)
                    return true;
            }
            return false;
        }

        public void AddInvestor(Investor investor)
        {
            investors.Add(investor);
        }
    }
}
