public class CheckingAccount
{
    public int Id { get; private set; }
    public decimal Balance { get; private set; }

    // Constructor
    public CheckingAccount(int id, decimal startingBalance)
    {
        Id = id;
        Balance = startingBalance;
    }

    // Deposit money
    public void Deposit(decimal amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Invalid deposit amount.");
            return;
        }

        Balance += amount;
    }

    // Withdraw money
    public bool Withdraw(decimal amount)
    {
        if (amount <= 0 || amount > Balance)
        {
            return false;
        }

        Balance -= amount;
        return true;
    }

    // Calculate and add interest
    //The virtual keyword allows a child class to replace the method's implementation using override.
    public virtual decimal CalculateInterest(decimal rate)
    {
        if (rate < 0)
        {
            return 0m;
        }

        decimal interest = Balance * rate / 100m;
        Balance += interest;

        return interest;
    }

    // Print account information
    public void PrintBalance()
    {
        Console.WriteLine($"The account with id '{Id}' has a balance of: {Balance}");
    }
}