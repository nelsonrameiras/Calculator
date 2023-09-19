using CalculatorLibrary;

namespace CalculatorProgram 
{
    class Program
    {
        static void Main(string[] args)
        {
            bool endApp = false;

            Console.WriteLine("Hello, dear user! \n" +
       "\nThis is a console calculator. Please, use it, and I hope it meets your standards!");

            Calculator calculator = new Calculator();
            while (!endApp)
            {
                string numIA = "";
                string numIB = "";
                double result = 0;

                Console.Write("\n\nPlease, input the first number: ");
                numIA = Console.ReadLine();

                double cleanA = 0;
                while (!double.TryParse(numIA, out cleanA))
                {
                    Console.Write("This is not a valid input. Please, enter an integer value: ");
                    numIA = Console.ReadLine();
                }

                Console.Write("\nPlease, input the second number: ");
                numIB = Console.ReadLine();

                double cleanB = 0;
                while (!double.TryParse(numIB, out cleanB))
                {
                    Console.Write("This is not valid input. Please, enter an integer value: ");
                    numIB = Console.ReadLine();
                }

                Console.WriteLine("\nChoose an operator from the following list:");
                Console.WriteLine("\ta - Add;");
                Console.WriteLine("\ts - Subtract;");
                Console.WriteLine("\tm - Multiply;");
                Console.WriteLine("\td - Divide.");
                Console.WriteLine("\n");
                Console.Write("Your option? ");

                string op = Console.ReadLine();

                try
                {
                    result = calculator.HeavyLifting(cleanA, cleanB, op);
                    if (double.IsNaN(result))
                    {
                        Console.WriteLine("This operation will result in a mathematical error.\n");
                    }
                    else Console.WriteLine("\n\nYour result: {0:0.##}\n", result);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Unfortunately, an exception occurred, whilst trying to do the math.\n - Details: " + e.Message);
                }


                Console.Write("\nPress 'c' and Enter, to close the app, or press any other key and Enter to continue: ");
                if (Console.ReadLine() == "c") endApp = true;

                Console.WriteLine("\n");
            }
            calculator.Finish();

            return;
        }
    }
}