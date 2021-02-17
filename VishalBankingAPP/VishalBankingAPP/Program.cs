using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VishalBankingAPP
{
    class Program
    {
        static void Main(string[] args)
        {
            Account accountA = new Account("Vishal Singh", 5000.0f);
            Account accountB = new Account("Prem Singh", 6000.0f);

            PrintSummary(accountA);
            bool withdrawResponse = accountA.Withdraw(4500.0f);
            WithdrawalMessageInfo(accountA, withdrawResponse);
            bool withdrawResponse2 = accountA.Withdraw(500.0f);
            WithdrawalMessageInfo(accountA, withdrawResponse2);

            bool depositResponse = accountA.Deposit(400);
            DepositMessageInfo(accountA, depositResponse);
            PrintSummary(accountA);
            PrintSummary(accountB);
            Console.ReadLine();
        }

        public static void WithdrawalMessageInfo(Account a, bool responseParameter)
        {
            if (responseParameter == false)
            {
                Console.WriteLine($"Cannot perform Widthdrawl, insufficient balance");
                return;
            }
            Console.WriteLine($"Withdrawl Successful, Current Account Balance : {a.GetBalance()}");
        }

        public static void DepositMessageInfo(Account a, bool responseParameter)
        {
            if (responseParameter == false)
            {
                Console.WriteLine($"Cannot perform Deposit, Enter sufficient amount");
                return;
            }
            Console.WriteLine($"Deposit Successful, Current Account Balance : {a.GetBalance()}");
        }

        public static void PrintSummary(Account a)
        {
            Console.WriteLine($"\n\n\n******************** Account Summary *********************");
            Console.WriteLine($"Account Number : {a.GetAccountNumber()} \nAccount Holder Name : {a.GetAccountHolderName()} \nAccount Balance : {a.GetBalance()} \nNo. of Transaction Performed : {a.GetTransactionPerformed()} ");
        }

    }
}
