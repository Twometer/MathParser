using MathParser.Tokens;
using System.Collections.Generic;
using System.Linq;

namespace MathParser.Steps
{
    public class Cleaner
    {

        public IEnumerable<IToken> Clean(IEnumerable<IToken> uncleaned)
        {
            var cleaned = CleanInner(uncleaned).ToArray();
            for (var i = 0; i < cleaned.Length; i++)
            {
                var current = cleaned[i];
                var next = i + 1 < cleaned.Length ? cleaned[i + 1] : Token.EOF;
                if (current is Token && next is Token)
                    continue;
                yield return current;
            }
        }

        private IEnumerable<IToken> CleanInner(IEnumerable<IToken> uncleaned)
        {
            foreach (var token in uncleaned)
            {
                if (token is Token)
                    yield return token;
                else if (token is TokenGroup)
                {
                    var array = ((TokenGroup)token).Children.ToArray();
                    if (!CheckNull(array))
                        yield return new TokenGroup(Clean(array));
                }
            }
        }

        private bool CheckNull(Token[] group)
        {
            for (var i = 0; i < group.Length; i++)
            {
                var current = group[i];
                var next = i + 1 < group.Length ? group[i + 1] : Token.EOF;

                if (current.Type == TokenType.Number && current.NumericValue == 0 && next.Type == TokenType.Multiply)
                    return true;

                if (current.Type == TokenType.Multiply && next.Type == TokenType.Number && next.NumericValue == 0)
                    return true;

            }

            return false;
        }

        private IEnumerable<Token> Clean(Token[] group)
        {
            for (var i = 0; i < group.Length; i++)
            {
                var current = group[i];
                var next = i + 1 < group.Length ? group[i + 1] : Token.EOF;

                // Reformat all numbers
                if (current.Type == TokenType.Number)
                    current.Content = current.NumericValue.ToString();

                if (current.Type == TokenType.Number && current.NumericValue == 1 && next.Type == TokenType.Multiply)
                {
                    i++;
                    continue;
                }

                yield return current;
            }
        }

    }
}
