using System;

namespace MySuperBank
{
    class Program
    {
        public static void Main(string[] args)
        {
            var account = new BankAccount("Jonh Doe", 100000);

            Console.WriteLine($"Account {account.Number} was created for {account.Owner} with initial balance of {account.Balance}");

            //Ensure that the initial Balance must be positive

            // try
            // {
            //     var inititialBalance = new BankAccount("invalid", -44);
            // }
            // catch (System.ArgumentOutOfRangeException)
            // { 
            //    Console.WriteLine("Exception caught creating account with negative balance");
            // }


            account.MakeWithdrawal(1000, DateTime.Now, "Airtime recharge");
            account.MakeWithdrawal(3000, DateTime.Now, "Cable tv subscription");

            Console.WriteLine(account.Balance);

            //Print account history
            Console.WriteLine(account.GetAccountHistory());

        }
    }
}