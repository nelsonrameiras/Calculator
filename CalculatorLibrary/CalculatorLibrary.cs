using Newtonsoft.Json;

namespace CalculatorLibrary
{
    public class Calculator
    {
        readonly JsonWriter writer;

        public Calculator()
        {
            StreamWriter logFile = File.CreateText("calculatorlog.json");
            logFile.AutoFlush = true;
            writer = new JsonTextWriter(logFile)
            {
                Formatting = Formatting.Indented
            };
            writer.WriteStartObject();
            writer.WritePropertyName("Operations");
            writer.WriteStartArray();
        }

        public double HeavyLifting(double a, double b, string op)
        {
            double result = double.NaN;
            writer.WriteStartObject();
            writer.WritePropertyName("Operand1");
            writer.WriteValue(a);
            writer.WritePropertyName("Operand2");
            writer.WriteValue(b);
            writer.WritePropertyName("Operation");

            switch (op)
            {
                case "a":
                    result = a + b;
                    writer.WriteValue("Addition");
                    break;
                case "s":
                    result = a - b;
                    writer.WriteValue("Subtraction");
                    break;
                case "m":
                    result = a * b;
                    writer.WriteValue("Multiplication");
                    break;
                case "d":
                    if (b != 0)
                    {
                        result = a / b;
                    }
                    writer.WriteValue("Division");
                    break;
                case "r":
                    if (a >= 0 && b != 0)
                    {
                        result = Math.Pow(a, 1 / b);
                    }
                    writer.WriteValue("N_th root");
                    break;
                case "e":
                    result = Math.Pow(a, b);
                    writer.WriteValue("Exponentiation");
                    break;
                case "x":
                    result = b * Math.Exp(a);
                    writer.WriteValue("Eulerian Exponentiation");
                    break;
                case "l":
                    result = Math.Log(a, b);
                    writer.WriteValue("Logarithm of base b");
                    break;
                case "u":
                    result = b * Math.Log(a);
                    writer.WriteValue("Eulerian Logarithm");
                    break;
                default:
                    break;
            }
            writer.WritePropertyName("Result");
            writer.WriteValue(result);
            writer.WriteEndObject();

            return result;
        }
        public void Finish()
        {
            writer.WriteEndArray();
            writer.WriteEndObject();
            writer.Close();
        }
    }
}