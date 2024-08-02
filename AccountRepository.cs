using DebuggingAndRefactoringTask1.Models;

namespace DebuggingAndRefactoringTask1
{
    internal class AccountRepository
    {
        public List<Account> accounts = new List<Account>();

        public void CreateAccount(Account account)
        {
            accounts.Add(account);
        }

        public Account? GetAccount(string id)
        {
            return accounts.FirstOrDefault(account => account.Id == id);
        }

        public bool DepositMoney(string id, decimal amount)
        {
            var accountToUpdate = GetAccount(id);
            if (accountToUpdate != null)
            {
                accountToUpdate.Balance += amount;
                return true;
            }
            return false;
        }

        public bool WithdrawMoney(string id, decimal amount)
        {
            var accountToUpdate = GetAccount(id);
            if (accountToUpdate != null)
            {
                if (accountToUpdate.Balance >= amount)
                {
                    accountToUpdate.Balance -= amount;
                    return true;
                }
                else
                {
                    throw new Exception("Insufficient Balance");

                }
            }
            return false;
        }
    }
}
