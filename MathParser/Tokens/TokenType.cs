using System;
using System.Collections.Generic;
using System.Text;

namespace MathParser.Tokens
{
    public enum TokenType
    {
        Number,
        Variable,
        Plus,
        Minus,
        Multiply,
        Divide,
        ParenOpen,
        ParenClose,
        EOF
    }
}
