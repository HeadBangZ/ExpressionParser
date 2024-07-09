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
        Evaluator evaluator = Evaluator.Instance;

        while (true)
        {
            Console.Write(">> ");
            string? input = Console.ReadLine();

            if (input == "exit")
            {
                break;
            }
            Console.WriteLine();
            Console.WriteLine($">> Input: {input}");

            if (input != null)
            {
                var tokens = lexer.Tokenize(input);
                var node = parser.Parse(tokens);
                var result = evaluator.Evaluate(node);

                Console.WriteLine();
                Console.WriteLine($">> Reult: {result}");

                Console.WriteLine();
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

