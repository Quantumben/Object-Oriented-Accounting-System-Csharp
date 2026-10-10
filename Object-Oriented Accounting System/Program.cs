Console.WriteLine("Welcome to the Accounting System 1.0.");

// Create accounts
CheckingAccount account1 = new CheckingAccount(100, 0m);
PremiumAccount account2 = new PremiumAccount(200, 0m);

// Print initial balances
account1.PrintBalance();
account2.PrintBalance();

// Deposit money
account1.Deposit(2000m);
account2.Deposit(6000m);

// Print balances after deposits
account1.PrintBalance();
account2.PrintBalance();

// Transfer money
BankTransfer.Transfer(account2, account1, 2000m);

// Print balances after transfer
account1.PrintBalance();
account2.PrintBalance();

// Calculate interest
decimal interest1 = account1.CalculateInterest(3m);
decimal interest2 = account2.CalculateInterest(3m);

// Print interest
Console.WriteLine($"Account1 interest: {interest1:F2}");
Console.WriteLine($"Account2 interest: {interest2:F2}");

// Print final balances
account1.PrintBalance();
account2.PrintBalance();