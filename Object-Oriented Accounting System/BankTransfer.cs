public static class BankTransfer
{
    public static void Transfer(CheckingAccount from, CheckingAccount to, decimal amount)
    {
        if (from.Withdraw(amount))
        {
            to.Deposit(amount);

            Console.WriteLine("Transfer successful.");
            return;
        }

        Console.WriteLine("Transfer failed.");
    }
}