using System;
using System.Collections.Generic;
using System.Text;

namespace MathParser.Tokens
{
    public class Token : IToken
    {
        public static readonly Token Minus = new Token("-", TokenType.Minus);
        public static readonly Token Plus = new Token("+", TokenType.Plus);
        public static readonly Token Divide = new Token("/", TokenType.Divide);
        public static readonly Token Multiply = new Token("*", TokenType.Multiply);
        
        public static readonly Token EOF = new Token(null, TokenType.EOF);

        public double NumericValue => double.Parse(Content);

        public string Content;

        public TokenType Type;

        public Token(string content, TokenType type)
        {
            Content = content;
            Type = type;
        }
    }

}
