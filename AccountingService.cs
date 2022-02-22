using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class AccountingService : IAccountingService
    {
        public int GetAllInvoices() 
        {
            return 25;
        }
        public int GetPaidInvoices() 
        {
            return 18;
        }

        public int GetUnpaidInvoices() 
        {
            return 3;
        }

        public double ProfitThisYear()
        {
            return 115000;
        }
    }
}
