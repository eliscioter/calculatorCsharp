
using ConsoleApp1.src;
using ConsoleApp1.src.helpers;

namespace ConsoleApp1
{
    class Calculator
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Simple Calculator");
            App app = new();
            app.StartProgram();
        }
    }
}