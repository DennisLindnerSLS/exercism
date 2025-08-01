using System;

static class SavingsAccount
{
    public static float InterestRate(decimal balance)
    {
        return balance < 0 ? 3.213f 
            : balance < 1000 ? 0.5f 
            : balance < 5000 ? 1.621f 
            : 2.475f;
    }

    public static decimal Interest(decimal balance)
    {
        var rate = InterestRate(balance);
        if(rate == 0 || balance == 0)
            return 0;

        return ((decimal)rate / 100.0m) * balance;
    }

    public static decimal AnnualBalanceUpdate(decimal balance)
    {
        return balance + Interest(balance);
    }

    public static int YearsBeforeDesiredBalance(decimal balance, decimal targetBalance)
    {
        int years = 1;
        decimal curBalance = balance;
        while(years < 1000){//early out so we don't run into endless loops (better protection here)
            curBalance = AnnualBalanceUpdate(curBalance);
            if(curBalance >= targetBalance)
                return years;

            years++;
        }
        return -1;
    }
}
