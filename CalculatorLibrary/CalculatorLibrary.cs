namespace CalculatorLibrary
{
    public class Calculator
    {
        public static double HeavyLifting(double a, double b, string op)
        {
            double result = double.NaN;

            switch (op)
            {
                case "a":
                    result = a + b;
                    break;
                case "s":
                    result = a - b;
                    break;
                case "m":
                    result = a * b;
                    break;
                case "d":
                    if (b != 0)
                    {
                        result = a / b;
                    }
                    break;
                default:
                    break;
            }
            return result;
        }
    }
}