using MathParser.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace MathParser
{
    public class Calculator
    {

        public double Calculate(IEnumerable<IToken> tokens, Dictionary<string, double> variables)
        {
            var finalTokens = new List<Token>();
            foreach(var token in tokens)
            {
                if(token is Token)
                {
                    finalTokens.Add((Token)token);
                }
                else if(token is TokenGroup)
                {
                    var group = (TokenGroup)token;
                    var calculated = CalculateGroup(group, variables);
                    finalTokens.Add(new Token(calculated.ToString(), TokenType.Number));
                }
            }

            double value = finalTokens[0].NumericValue;

            TokenType operation = TokenType.EOF;
            foreach (var token in finalTokens)
            {
                if (token.Type == TokenType.Number)
                {
                    if (operation == TokenType.Plus)
                        value += token.NumericValue;
                    else if (operation == TokenType.Minus)
                        value -= token.NumericValue;
                }
                else
                {
                    operation = token.Type;
                }
            }

            return value;
        }

        private double CalculateGroup(TokenGroup group, Dictionary<string, double> variables)
        {
            foreach(var token in group.Children)
            {
                if(token.Type == TokenType.Variable)
                {
                    if (!variables.ContainsKey(token.Content))
                        throw new KeyNotFoundException("Undefined variable " + token.Content);
                    token.Content = variables[token.Content].ToString();
                    token.Type = TokenType.Number;
                }
            }

            double value = group.Children[0].NumericValue;

            TokenType operation = TokenType.EOF;
            foreach(var token in group.Children)
            {
                if (token.Type == TokenType.Number)
                {
                    if (operation == TokenType.Multiply)
                        value *= token.NumericValue;
                    else if(operation == TokenType.Divide)
                        value /= token.NumericValue;
                }
                else
                {
                    operation = token.Type;
                }
            }

            return value;
        }

    }
}
