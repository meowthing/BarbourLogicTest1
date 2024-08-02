using BankingSystem.Models;


namespace BankingSystem
{
    public interface IAccountRepository
    {
        public void CreateAccount(Account account);
        public Account? GetAccount(string id);
        public bool DepositMoney(string id, decimal amount);
        public bool WithdrawMoney(string id, decimal amount);
    }
}
