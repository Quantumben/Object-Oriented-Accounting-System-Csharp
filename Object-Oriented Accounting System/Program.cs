Console.WriteLine("Welcome to the Accounting System 2.0!");

// Create our two bank accounts
CheckingAccount account1 = new CheckingAccount(100, 0m);
PremiumAccount account2 = new PremiumAccount(200, 0m);

// Control whether the application keeps running
bool isRunning = true;

while (isRunning)
{
    Console.WriteLine();
    Console.WriteLine("========== MAIN MENU ==========");
    Console.WriteLine("1. Check Account Balances");
    Console.WriteLine("2. Deposit Money");
    Console.WriteLine("3. Withdraw Money");
    Console.WriteLine("4. Transfer Money");
    Console.WriteLine("5. Calculate Interest");
    Console.WriteLine("6. Exit");
    Console.WriteLine("===============================");

    Console.Write("Enter your choice: ");
    string? choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            account1.PrintBalance();
            account2.PrintBalance();
            break;

        case "2":
            Console.Write("Enter account ID (100 or 200): ");
            string? depositId = Console.ReadLine();

            Console.Write("Enter deposit amount: ");
            string? depositInput = Console.ReadLine();

            if (!decimal.TryParse(depositInput, out decimal depositAmount)
                || depositAmount <= 0)
            {
                Console.WriteLine("Invalid deposit amount.");
                break;
            }

            if (depositId == "100")
            {
                account1.Deposit(depositAmount);
                Console.WriteLine("Deposit completed.");
                break;
            }

            if (depositId == "200")
            {
                account2.Deposit(depositAmount);
                Console.WriteLine("Deposit completed.");
                break;
            }

            Console.WriteLine("Account not found.");
            break;

        case "3":
            Console.Write("Enter account ID (100 or 200): ");
            string? withdrawId = Console.ReadLine();

            Console.Write("Enter withdrawal amount: ");
            string? withdrawInput = Console.ReadLine();

            if (!decimal.TryParse(withdrawInput, out decimal withdrawAmount))
            {
                Console.WriteLine("Invalid amount.");
                break;
            }

            CheckingAccount? withdrawAccount = null;

            if (withdrawId == "100")
            {
                withdrawAccount = account1;
            }

            if (withdrawId == "200")
            {
                withdrawAccount = account2;
            }

            if (withdrawAccount == null)
            {
                Console.WriteLine("Account not found.");
                break;
            }

            if (withdrawAccount.Withdraw(withdrawAmount))
            {
                Console.WriteLine("Withdrawal completed.");
                break;
            }

            Console.WriteLine("Withdrawal failed.");
            break;

        case "4":
            Console.Write("Enter sender account ID (100 or 200): ");
            string? senderId = Console.ReadLine();

            Console.Write("Enter receiver account ID (100 or 200): ");
            string? receiverId = Console.ReadLine();

            Console.Write("Enter transfer amount: ");
            string? transferInput = Console.ReadLine();

            if (!decimal.TryParse(transferInput, out decimal transferAmount)
                || transferAmount <= 0)
            {
                Console.WriteLine("Invalid transfer amount.");
                break;
            }

            if (senderId == receiverId)
            {
                Console.WriteLine("Choose two different accounts.");
                break;
            }

            if (senderId == "100" && receiverId == "200")
            {
                BankTransfer.Transfer(account1, account2, transferAmount);
                break;
            }

            if (senderId == "200" && receiverId == "100")
            {
                BankTransfer.Transfer(account2, account1, transferAmount);
                break;
            }

            Console.WriteLine("Invalid account IDs.");
            break;

        case "5":
            Console.Write("Enter interest rate (%): ");
            string? rateInput = Console.ReadLine();

            if (!decimal.TryParse(rateInput, out decimal rate)
                || rate < 0)
            {
                Console.WriteLine("Invalid interest rate.");
                break;
            }

            decimal interest1 = account1.CalculateInterest(rate);
            decimal interest2 = account2.CalculateInterest(rate);

            Console.WriteLine($"Checking interest: {interest1:F2}");
            Console.WriteLine($"Premium interest: {interest2:F2}");
            break;

        case "6":
            Console.WriteLine("Thank you for using the Accounting System.");
            isRunning = false;
            break;

        default:
            Console.WriteLine("Invalid choice. Please try again.");
            break;
    }
}