using System;
using System.Collections.Generic;
using System.Text;

namespace MathParser
{
    public enum TokenType
    {
        Number,
        Variable,
        Plus,
        Minus,
        Multiply,
        Divide,
        Equals,
        ParenOpen,
        ParenClose,
        EOF
    }
}
