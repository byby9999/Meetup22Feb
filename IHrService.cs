namespace ConsoleApp1
{
    public interface IHrService
    {
        public int CountNewHiresThisMonth();
        int CountTotalEmployees();

        int EmployeeGrowthRateThisYear();

        double TurnoverRateThisYear();

        int CountManagers();

        double GetMedianTenure();

        public string[] EmployeeAnniversariesThisMonth();

        public string VeteranEmployee();

    }
}