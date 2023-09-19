internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, dear user! \n" +
    "\nThis is a console calculator. Please, use it, and I hope it meets your standards!");

        Console.WriteLine("\n");

        Console.WriteLine("Please, input the first number: ");
        double a = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("\n");

        Console.WriteLine("Please, input the second number: ");
        double b = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("\n");

        Console.WriteLine("Choose one of the following options:");
        Console.WriteLine("\ta - Addition");
        Console.WriteLine("\ts - Subtract");
        Console.WriteLine("\tm - Multiply");
        Console.WriteLine("\td - Divide");
        Console.WriteLine("Your option? ");

        switch (Console.ReadLine())
        {
            case "a":
                Console.WriteLine($"\nYour result: {a} + {b} = " + (a + b));
                break;
            case "s":
                Console.WriteLine($"\nYour result: {a} - {b} = " + (a - b));
                break;
            case "m":
                Console.WriteLine($"\nYour result: {a} * {b} = " + a * b);
                break;
            case "d":
                while (b == 0)
                {
                    Console.WriteLine("\nPlease, enter a non-null divisor: ");
                    b = Convert.ToDouble(Console.ReadLine());
                }
                Console.WriteLine($"\nYour result: {a} / {b} = " + a / b);
                break;
            default:
                break;
        }
    }
}