using ExpressionParser;
using ExpressionParser.Common;
using ExpressionParser.Interfaces;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Expression Parser.");
        Console.WriteLine();
        Console.WriteLine("Information\n");
        Console.WriteLine("\tTo exit write: 'exit'");
        Console.WriteLine();
        Console.WriteLine("\tAllowed operators: + - * / ^ ! ( )");
        Console.WriteLine("____________________________________________________________");

        Lexer lexer = new Lexer();
        Parser parser = new Parser();

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
                var tokens = lexer.Tokenize(input);

                foreach (var token in tokens)
                {
                    Console.WriteLine($">> {token}");
                }

                Console.WriteLine();

                var node = parser.Parse(tokens);

                PrintTree(node);
            }
        }
    }

    public static void PrintTree(INode node, string indent = "", bool isLeft = true)
    {
        if (node == null)
        {
            return;
        }

        Console.WriteLine(indent + (isLeft ? "├── " : "└── ") + node.Data);
        PrintTree(node.Left, indent + (isLeft ? "│   " : "    "), true);
        PrintTree(node.Right, indent + (isLeft ? "│   " : "    "), false);
    }
}

