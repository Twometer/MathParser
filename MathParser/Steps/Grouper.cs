using MathParser.Tokens;
using System.Collections.Generic;

namespace MathParser.Steps
{
    public class Grouper
    {

        public IEnumerable<IToken> Group(IEnumerable<Token> tokens)
        {
            var tokenGroup = new TokenGroup();
            foreach (var token in tokens)
            {
                if (token.Type == TokenType.Plus || token.Type == TokenType.Minus)
                {
                    yield return tokenGroup;
                    tokenGroup = new TokenGroup();
                    yield return token;
                }
                else
                    tokenGroup.Add(token);
            }
            if (!tokenGroup.Empty)
                yield return tokenGroup;
        }

    }
}
