using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathParser
{
    public class TokenGroup : IToken
    {

        public List<Token> Children;

        public TokenGroup() => Children = new List<Token>();

        public TokenGroup(IEnumerable<Token> children) => Children = children.ToList();

        public bool Empty => Children.Count == 0;

        public void Add(Token token) => Children.Add(token);

    }
}
