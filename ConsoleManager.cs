using DebuggingAndRefactoringTask1;
using DebuggingAndRefactoringTask1.Models;
using System.Globalization;

namespace BankingSystem
{
    public class ConsoleManager
    {
        AccountRepository accountRepository = new AccountRepository();

        public void Run()
        {
            while (true)
            {
                Console.WriteLine("1. Add Account");
                Console.WriteLine("2. Deposit Money");
                Console.WriteLine("3. Withdraw Money");
                Console.WriteLine("4. Display Account Details");
                Console.WriteLine("5. Exit");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddAccount();
                        break;
                    case "2":
                        DepositMoney();
                        break;
                    case "3":
                        WithdrawMoney();
                        break;
                    case "4":
                        DisplayAccountDetails();
                        break;
                    case "5":
                        return; //did nothing originally
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

        void AddAccount()
        {
            string id = ReadAccountId();
            string name = ReadAccountName();

            Account account = new Account { Id = id, Name = name, Balance = 0 };
            accountRepository.CreateAccount(account);

            Console.WriteLine("Account added successfully.");
        }

        void DepositMoney()
        {
            string id = ReadAccountId();
            decimal amount = 0;

            PromptCheckpoint(AccountActions.Deposit, ref amount);

            if (accountRepository.DepositMoney(id, amount))
            {
                Console.WriteLine("Deposit successful.");

            }
            else
            {
                Console.WriteLine("Account not found.");
            }
        }

        void WithdrawMoney()
        {
            string id = ReadAccountId();
            decimal amount = 0;

            PromptCheckpoint(AccountActions.Withdraw, ref amount);

            try
            {
                if (accountRepository.WithdrawMoney(id, amount))
                {
                    Console.WriteLine("Deposit successful.");

                }
                else
                {
                    Console.WriteLine("Account not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message.ToString());
            }
        }

        void DisplayAccountDetails()
        {
            string id = ReadAccountId();
            Account? acc = accountRepository.GetAccount(id);
            if (acc == null)
            {
                Console.WriteLine("Account not found.");
            }
            Console.WriteLine($"Account ID: {acc.Id}");
            Console.WriteLine($"Account Holder: {acc.Name}");
            Console.WriteLine($"Balance: {acc.Balance}");
        }

        string ReadAccountId()
        {
            Console.WriteLine("Enter Account ID:");
            return Console.ReadLine();
        }

        string ReadAccountName()
        {
            Console.WriteLine("Enter Account Holder Name:");
            return Console.ReadLine(); //Read() only captures a single character's code
        }

        void PromptCheckpoint(AccountActions action, ref decimal amount)
        {
            bool actionResponse = true;
            while (actionResponse)
            {
                Console.WriteLine($"Enter Amount to {(action == AccountActions.Deposit ? "Deposit:" : "Withdraw:")}");
                amount = decimal.Parse(Console.ReadLine());

                Console.WriteLine($"You are {(action == AccountActions.Deposit ? "depositing" : "withdrawing")}" +
                    $" {amount.ToString("C", CultureInfo.CreateSpecificCulture("en-US"))} Schmeckles. " +
                    $"Is this correct? Y/N");

                actionResponse = Console.ReadLine().ToUpper() != "Y";

                // we're looking for false to break the loop. If true, repeat the deposit/withdraw sequence.
                // although this does mean the user will end up in an endless loop unless they
                // input a 0 as a deposit or withdraw action...
                if (actionResponse)
                {
                    Console.WriteLine("Please input the correct amount.");
                }
            }
        }

        enum AccountActions
        {
            Deposit,
            Withdraw
        }
    }
}
