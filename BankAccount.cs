using System.Text;
using System;
namespace MySuperBank
{
    public class BankAccount
    {
        public string Number { get; }

        public string Owner { get; set; }

        public decimal Balance {
            get
            {
                decimal balance = 0;
                foreach(var item in allTransactions)
                {
                    balance += item.Amount;
                }

                return balance;
            }
        }

        private static int AccountNumberSeed = 1234567890;

        private List<Transaction> allTransactions = new List<Transaction>();


        //Define a contructor
        public BankAccount(string name, decimal initialBalance)
        {
            this.Owner = name;

            MakeDeposit(initialBalance, DateTime.Now, "Initial balance");

            this.Number = AccountNumberSeed.ToString();
            AccountNumberSeed++;
        }

        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            if(amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposite must be positive");
            }

            var deposite = new Transaction(amount, date, note);
            allTransactions.Add(deposite);
        }

        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
            if(amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
            }

            if(Balance - amount < 0)
            {
                throw new InvalidOperationException("Not sufficient funds for withdrawal");
            }

            var withdrawal = new Transaction(-amount, date, note);
            allTransactions.Add(withdrawal);
        }

		public string GetAccountHistory()
		{
			var report = new System.Text.StringBuilder();

			decimal balance = 0;
			report.AppendLine("Date\t\tAmount\tBalance\tNote");
			foreach (var item in allTransactions)
			{
				balance += item.Amount;
				report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t{balance}\t{item.Notes}");
			}

			return report.ToString();
		}
    }
}

