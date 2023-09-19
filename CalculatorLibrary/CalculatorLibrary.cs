using System.Diagnostics;
using Newtonsoft.Json;

namespace CalculatorLibrary
{
    public class Calculator
    {
        JsonWriter writer;

        public Calculator()
        {
            StreamWriter logFile = File.CreateText("calculatorlog.json");
            logFile.AutoFlush = true;
            writer = new JsonTextWriter(logFile);
            writer.Formatting = Formatting.Indented;
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
                    writer.WriteValue("Add");
                    break;
                case "s":
                    result = a - b;
                    writer.WriteValue("Subtract");
                    break;
                case "m":
                    result = a * b;
                    writer.WriteValue("Multiply");
                    break;
                case "d":
                    if (b != 0)
                    {
                        result = a / b;
                    }
                    writer.WriteValue("Divide");
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