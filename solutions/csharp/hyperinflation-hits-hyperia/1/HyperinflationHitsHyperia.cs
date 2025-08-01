using System;

public static class CentralBank
{
    public static string DisplayDenomination(long @base, long multiplier)
    {
        try{
            long result = checked(@base * multiplier);
            return result.ToString();
        }catch(OverflowException ex){
            return "*** Too Big ***";
        }
    }

    public static string DisplayGDP(float @base, float multiplier)
    {
        double result = checked(@base * multiplier);
        return Double.IsInfinity(result) ? 
            "*** Too Big ***" : 
        result.ToString();
    }

    public static string DisplayChiefEconomistSalary(decimal salaryBase, decimal multiplier)
    {
        try{
            decimal result = checked(salaryBase * multiplier);
            return result.ToString();
        }catch(OverflowException ex){
            return "*** Much Too Big ***";
        }
    }
}
