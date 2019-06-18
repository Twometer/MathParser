using System;
using System.Collections.Generic;

namespace MathParser
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = "35x-01x*4+91*0+3340/2-x";
            Console.WriteLine("Input: " + input);
            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine("Tokenized:");
            var tokenizer = new Tokenizer();
            var tokenized = tokenizer.Tokenize(input);
            List(tokenized);

            Console.WriteLine();
            Console.WriteLine("Expanded:");
            var expander = new Expander();
            var expanded = expander.Expand(tokenized);
            List(expanded);

            Console.WriteLine();
            Console.WriteLine("Grouped:");
            var grouper = new Grouper();
            var grouped = grouper.Group(expanded);
            List(grouped);

            Console.WriteLine();
            Console.WriteLine("Cleaned:");
            var cleaner = new Cleaner();
            var cleaned = cleaner.Clean(grouped);
            List(cleaned);

            Console.WriteLine("");
            Console.WriteLine("");

            Format(cleaned);

            var calc = new Calculator();
            var dict = new Dictionary<string, double>() { { "x", 2 } };
            Console.WriteLine("Variables: x=2");
            Console.WriteLine("Calculated: " + calc.Calculate(cleaned, dict));
        }

        private static void List(IEnumerable<IToken> tokens)
        {
            foreach (var token in tokens)
                if (token is Token)
                    Console.WriteLine(((Token)token).Content + "\t\t" + ((Token)token).Type);
                else if (token is TokenGroup)
                    foreach (var subtoken in ((TokenGroup)token).Children)
                        Console.WriteLine("   " + subtoken.Content + "\t\t" + subtoken.Type);
        }

        private static void Format(IEnumerable<IToken> tokens)
        {
            Console.Write("Output: ");
            foreach (var token in tokens)
                if (token is Token)
                    Console.Write(((Token)token).Content);
                else if (token is TokenGroup)
                    foreach (var subtoken in ((TokenGroup)token).Children)
                        Console.Write(subtoken.Content);

            Console.WriteLine();
        }
    }
}
