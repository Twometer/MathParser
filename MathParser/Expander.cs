using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathParser
{
    public class Expander
    {

        public IEnumerable<Token> Expand(IEnumerable<Token> input)
        {
            var inputArray = input.ToArray();
            for(var i = 0; i < inputArray.Length; i++)
            {
                var current = inputArray[i];
                var next = i + 1 < inputArray.Length ? inputArray[i + 1] : Token.EOF;

                yield return current;

                if (current.Type == TokenType.Number && next.Type == TokenType.Variable)
                    yield return Token.Multiply;

            }
        }

    }
}
