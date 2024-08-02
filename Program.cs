namespace BankingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleManager dashboard = new ConsoleManager(new AccountRepository());
            dashboard.Run();
        }
    }
}
