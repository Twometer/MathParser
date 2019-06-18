using System.Collections.Generic;

namespace MathParser.Tokens
{
    public class Tokenizer
    {
        public IEnumerable<Token> Tokenize(string value)
        {
            var num = "";
            foreach (var chr in value)
            {
                if (char.IsDigit(chr))
                {
                    num += chr;
                }
                else
                {
                    if (num != "")
                    {
                        yield return new Token(num, TokenType.Number);
                        num = "";
                    }

                    TokenType tokenType;
                    switch (chr)
                    {
                        case '-':
                            tokenType = TokenType.Minus;
                            break;
                        case '+':
                            tokenType = TokenType.Plus;
                            break;
                        case '*':
                            tokenType = TokenType.Multiply;
                            break;
                        case '/':
                            tokenType = TokenType.Divide;
                            break;
                        case '(':
                            tokenType = TokenType.ParenOpen;
                            break;
                        case ')':
                            tokenType = TokenType.ParenClose;
                            break;
                        case '=':
                            tokenType = TokenType.Equals;
                            break;
                        default:
                            tokenType = TokenType.Variable;
                            break;
                    }
                    yield return new Token(chr.ToString(), tokenType);
                }
            }

            if (num != "")
            {
                yield return new Token(num, TokenType.Number);
            }
        }

    }
}
