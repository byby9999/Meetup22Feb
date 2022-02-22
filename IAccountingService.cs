namespace ConsoleApp1
{
    public interface IAccountingService
    {
        int GetAllInvoices();
        int GetUnpaidInvoices();
        int GetPaidInvoices();

        double ProfitThisYear();
    }
}