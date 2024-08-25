using ConsoleApp1.src.helpers;

namespace ConsoleApp1.src
{
    public class App : IApp
    {
        private UserInput user_input = new();

        private string UserOperation()
        {
            string user_operation_input;

            try
            {
                string list_operators = string.Join(", ", ValidOperations.Operations().ToList());

                Console.WriteLine("Type operation to be used");
                Console.WriteLine($"[{list_operators}]");

                user_operation_input = Console.ReadLine()!;

                if (user_operation_input.IsEmptyOrNull())
                {
                    throw new ArgumentNullException();
                }
                if (!user_operation_input.IsValidOperation())
                {

                    throw new ArgumentException($"Value should be [{list_operators}] only");
                }

                return user_operation_input.ToCapitalize();

            }
            catch (Exception err)
            {
                Console.WriteLine($"Invalid Input! \n{err.Message}");
                return UserInput().UserOperator!;
            }

        }

        private static double Operand(string order)
        {
            double operand;
            string number = order;
            try
            {
                Console.WriteLine($"Enter your {order} number:");

                operand = Convert.ToDouble(Console.ReadLine());

                return operand;
            }
            catch (Exception err)
            {
                Console.WriteLine($"Please enter an integer or decimal \n{err.Message}");
                return Operand(number);
            }
        }

        private static double[] UserOperands()
        {
            double operand1, operand2;
            try
            {
                operand1 = Operand("first");

                operand2 = Operand("second");

                return [operand1, operand2];

            }
            catch (Exception err)
            {

                Console.WriteLine($"{err.Message}");
                return UserOperands();
            }
        }
        private UserInput UserInput()
        {
            string operation;
            double[] operands;

            operation = UserOperation();

            operands = UserOperands();

            user_input.UserOperator = operation;
            user_input.Operand1 = operands[0];
            user_input.Operand2 = operands[1];

            return user_input;
        }

        private static void EndProgram()
        {
            Console.WriteLine("Thank you for using simple calculator!");
            Console.WriteLine("Closing the program...");

            Environment.Exit(1);
        }

        private static void AskUserToContinue()
        {

            char another_calculation;
            App app = new();

            try
            {
                Console.WriteLine("---------------------------");

                Console.WriteLine("Do you want to make another calculation? [y/n]");


                another_calculation = Convert.ToChar(Console.Read());

                if (another_calculation.ToString().IsEmptyOrNull())
                {
                    throw new ArgumentNullException("Input cannot be empty");
                }
                if (another_calculation == 'y')
                {
                    Console.ReadLine();
                    app.StartProgram();
                }
                else if (another_calculation == 'n')
                {
                    EndProgram();
                }
                else
                {
                    Console.WriteLine("Invalid answer. Only use 'y' or 'n'");
                    AskUserToContinue();
                }
            }
            catch (Exception err)
            {

                Console.WriteLine(err.Message);
                AskUserToContinue();
            }
        }

        public void StartProgram()
        {
            UserInput input;
            double result;

            input = UserInput();

            Console.WriteLine($"Operator: {input.UserOperator!.ToCapitalize()}");
            Console.WriteLine($"First number: {input.Operand1}");
            Console.WriteLine($"Second number: {input.Operand2}");

            Operation calc = new(input.UserOperator!);

            result = calc.Calculate(input.Operand1, input.Operand2);

            Console.WriteLine($"\nResult: {result}");

            AskUserToContinue();
        }

    }
}