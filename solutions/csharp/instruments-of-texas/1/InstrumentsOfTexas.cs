using System;

public class CalculationException : Exception
{
    public CalculationException(int operand1, int operand2, string message, Exception inner) : base(message, inner)
    {
        this.Operand1 = operand1;
        this.Operand2 = operand2;
    }

    public int Operand1 { get; }
    public int Operand2 { get; }
}

public class CalculatorTestHarness
{
    private Calculator calculator;

    public CalculatorTestHarness(Calculator calculator)
    {
        this.calculator = calculator;
    }

    public string TestMultiplication(int x, int y)
    {
        try{
            Multiply(x, y);
        }catch(CalculationException ex){
           return x < 0 && y < 0  
               ? $"Multiply failed for negative operands. {ex.InnerException.Message}" 
               : $"Multiply failed for mixed or positive operands. {ex.InnerException.Message}";
        }
        return "Multiply succeeded";
    }

    public void Multiply(int x, int y)
    {
        try{
            this.calculator.Multiply(x,y);
        }catch(OverflowException ex){
            throw new CalculationException(x,y,"Result overflow", ex);
        }
    }
}


// Please do not modify the code below.
// If there is an overflow in the multiplication operation
// then a System.OverflowException is thrown.
public class Calculator
{
    public int Multiply(int x, int y)
    {
        checked
        {
            return x * y;
        }
    }
}
