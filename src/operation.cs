using System;
using System.Collections.Frozen;
using ConsoleApp1.src;
using ConsoleApp1.src.helpers;

class Operation
{

    private readonly string operation;
    public Operation(string operation)
    {
        this.operation = operation;
    }

    public double Calculate(double num1, double num2)
    {
        App app = new();
        
        try
        {
            return operation switch
            {
                "Addition" => num1 + num2,
                "Subtraction" => num1 - num2,
                "Multiplication" => num1 * num2,
                "Division" => num1 / num2,
                _ => throw new ArgumentException("Invalid Operation"),
            };
        }
        catch (Exception err)
        {

            Console.WriteLine(err.Message);
            app.StartProgram();
            return -0;
        }

    }

}