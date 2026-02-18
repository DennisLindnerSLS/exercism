using System;

public static class SimpleCalculator
{
    public static string Calculate(int operand1, int operand2, string operation)
    {
        double result = 0;
        switch(operation){
            case "+": result = Add(operand1, operand2); break;
            case "*": result = Mult(operand1, operand2); break;
            case "/": 
                if(operand2 == 0) return "Division by zero is not allowed.";
                result = Div(operand1, operand2); 
                break;
            case "": throw new ArgumentException(); break;
            case null: throw new ArgumentNullException(); break;
            default: throw new ArgumentOutOfRangeException(); break;
        }
        return $"{operand1} {operation} {operand2} = {result}";
    }

    private static double Add(int left, int right){
        return left + right;
    }

    private static double Mult(int left, int right){
        return left * right;
    }

    private static double Div(int left, int right){
        return left / right;
    }
}
