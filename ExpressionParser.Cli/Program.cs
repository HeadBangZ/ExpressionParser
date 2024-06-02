using ExpressionParser;
using ExpressionParser.Common;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Expression Parser.");
        Console.WriteLine();
        Console.WriteLine("Information\n");
        Console.WriteLine("\tTo exit write: 'exit'");
        Console.WriteLine();
        Console.WriteLine("\tAllowed operators: + - * / ^ ( )");
        Console.WriteLine("____________________________________________________________");

        while (true)
        {
            Console.Write(">> ");
            string? input = Console.ReadLine();

            if (input == "exit")
            {
                break;
            }

            Console.WriteLine($">> input - {input}");

            if (input != null)
            {
                Parser parser = new Parser();
                var tokens = parser.Tokenize(input);

                foreach (var token in tokens)
                {
                    Console.WriteLine($">> {token.ToString()}");
                }
            }
        }
    }
}
