using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class HRService : IHrService
    {
        public int CountManagers()
        {
            return 12;
        }

        public int CountNewHiresThisMonth()
        {
            return 30;
        }

        public int CountTotalEmployees()
        {
            return 120;
        }

        public string[] EmployeeAnniversariesThisMonth()
        {
            return new string[] { "Maria Popa", "Sergiu Bogdanescu" };
        }

        public int EmployeeGrowthRateThisYear()
        {
            return 12;
        }

        public double GetMedianTenure()
        {
            return 7.3;
        }

        public double TurnoverRateThisYear()
        {
            return 3;
        }

        public string VeteranEmployee()
        {
            return "Solomon Petrescu";
        }
    }
}
