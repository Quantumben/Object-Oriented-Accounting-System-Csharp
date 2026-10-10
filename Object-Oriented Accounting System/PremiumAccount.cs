public class PremiumAccount : CheckingAccount
{
    public PremiumAccount(int id, decimal startingBalance): base(id, startingBalance)
    {
    }

    public override decimal CalculateInterest(decimal rate)
    {
        return base.CalculateInterest(rate + 1m);
    }
}