using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Dashboard
    {
        public IAccountingService _accounting;
        public IHrService _hrService;

        public Dashboard(IAccountingService accountingService, IHrService hrService) 
        {
            _accounting = accountingService;
            _hrService = hrService;
        }

        public void Show() 
        {
            Console.WriteLine("Good morning. Today's financial updates:");

            int allInvoices = _accounting.GetAllInvoices();
            int paid = _accounting.GetPaidInvoices();
            int unpaid = _accounting.GetUnpaidInvoices();

            int unknown = allInvoices - paid - unpaid;

            Console.WriteLine($"Invoices: {allInvoices}");
            Console.WriteLine($"\tPaid: {paid}");
            Console.WriteLine($"\tUnpaid: {unpaid}");
            Console.WriteLine($"\tUnknown status: {unknown}");

            Console.WriteLine("\n\nHR news for today:");
            Console.WriteLine($"\tEmployee Growth: {_hrService.EmployeeGrowthRateThisYear()}%");
            Console.WriteLine($"\tWe have {_hrService.CountTotalEmployees()} Employees");
            Console.WriteLine($"\tMedian tenure: {_hrService.GetMedianTenure()} years");
            Console.WriteLine($"\tOur Veteran: {_hrService.VeteranEmployee()}");

            var anniversaries = string.Join(", ", _hrService.EmployeeAnniversariesThisMonth());

            Console.WriteLine($"\tAnniversaries this month: {anniversaries}");
        }
    }
}
