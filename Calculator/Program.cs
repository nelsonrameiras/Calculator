using CalculatorLibrary;

namespace CalculatorProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args is null)
            {
                throw new ArgumentNullException(nameof(args));
            }

            bool endApp = false;

            Console.WriteLine("Hello, dear user! \n" +
       "\nThis is a console calculator. Please, use it, and I hope it meets your standards!");

            Console.WriteLine("\nThe following operators are available. Please, note their restrictions, and do not forget they're lowercase:");
            Console.WriteLine("\ta - Addition;");
            Console.WriteLine("\ts - Subtraction;");
            Console.WriteLine("\tm - Multiplication;");
            Console.WriteLine("\td - Division (b != 0);");
            Console.WriteLine("\te - Exponentiation (a^b);");
            Console.WriteLine("\tx - Eulerian Exponentiation (b*(e^a));");
            Console.WriteLine("\tr - N_th root (b_th-root(a)) (a >= 0 && b != 0);");
            Console.WriteLine("\tl - Logarithm of base b (log_b(a)) (a > 0 && b > 0 && b != 1 );");
            Console.WriteLine("\tu - Eulerian Logarithm (b*ln(a)) (a > 0).");


            Calculator calculator = new();
            while (!endApp)
            {
                string numIA, numIB;
                double result;

                Console.Write("\n\nPlease, input the first number (>= 0 for the n_th root and > 0 for the logarithms): ");
                numIA = Console.ReadLine();

                double cleanA;
                while (!double.TryParse(numIA, out cleanA))
                {
                    Console.Write("This is not a valid input. Please, enter an integer value: ");
                    numIA = Console.ReadLine();
                }

                Console.Write("\nPlease, input the second number (!= 0 for division and n_th root, and both > 0 and != 1 for the base b logarithm): ");
                numIB = Console.ReadLine();

                double cleanB;
                while (!double.TryParse(numIB, out cleanB))
                {
                    Console.Write("This is not valid input. Please, enter an integer value: ");
                    numIB = Console.ReadLine();
                }

                Console.WriteLine("\n");
                Console.Write("Please, choose an operator: ");

                string op = Console.ReadLine()!;
                op.ToLower();

                try
                {
                    result = calculator.HeavyLifting(cleanA, cleanB, op);
                    if (double.IsNaN(result))
                    {
                        Console.WriteLine("This operation will result in a mathematical error.\n");
                    }
                    else Console.WriteLine("\n\nYour result: {0:0.#####}\n", result);
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