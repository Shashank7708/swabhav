using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters;

namespace VishalBankingAPP
{   [Serializable]
    class Account :ISerializable
    {
        static int acc_number_counter = 1000;
        private int transactionPerformed = 0;
        private string accountNumber;
        bool isWithdrawlPossible = false;
        private string accountHolderName;
        private float balance;

        const float MIN_BALANCE = 500;

        public Account(string accountHolderName, float balance)
        {

            accountNumber = "SBI" + acc_number_counter;
            this.accountHolderName = accountHolderName;
            this.balance = balance;
            acc_number_counter += 1;
        }

        public string GetAccountNumber()
        {
            return this.accountNumber;
        }

        public string GetAccountHolderName()
        {
            return this.accountHolderName;
        }

        public float GetBalance()
        {
            return this.balance;
        }

        public void SetAccountNumber(string accountNumber)
        {
            this.accountNumber = accountNumber;
        }
        public void SetAccountHolderName(string accountHolderName)
        {
            this.accountHolderName = accountHolderName;
        }
        public void SetBalance(float balance)
        {
            this.balance = balance;
        }

        public bool Withdraw(float amount)
        {
            if (balance <= MIN_BALANCE)
            {

                return isWithdrawlPossible;
            }
            isWithdrawlPossible = true;
            this.balance -= amount;
            transactionPerformed += 1;
            return isWithdrawlPossible;
        }


        public bool Deposit(float amount)
        {
            if (amount < 1)
            {

                return isWithdrawlPossible;
            }
            isWithdrawlPossible = true;
            this.balance += amount;
            transactionPerformed += 1;
            return isWithdrawlPossible;
        }

        public int GetTransactionPerformed()                                
        {
            return this.transactionPerformed;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("acc_number_counter", typeof(int));
            info.AddValue("transactionPerformed", typeof(int));
            info.AddValue("accountNumber", typeof(string));
            info.AddValue("isWithdrawlPossible", typeof(bool));
            info.AddValue("accountHolderName", typeof(string));
            info.AddValue("balance", typeof(float));

        }
        public Account(SerializationInfo info, StreamingContext context) 
        {
            acc_number_counter = (int)info.GetValue("acc_number_counter", typeof(int));
            transactionPerformed = (int)info.GetValue("transactionPerformed", typeof(int));
            acc_number_counter = (int)info.GetValue("acc_number_counter", typeof(int));
            acc_number_counter = (int)info.GetValue("acc_number_counter", typeof(int));
            acc_number_counter = (int)info.GetValue("acc_number_counter", typeof(int));
            acc_number_counter = (int)info.GetValue("acc_number_counter", typeof(int));
        }
    }
}
 = 1000;
private int transactionPerformed = 0;
private string accountNumber;
bool isWithdrawlPossible = false;
private string accountHolderName;
private float balance;