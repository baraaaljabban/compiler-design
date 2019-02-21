using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expression2014Console
{
    enum TokenType { NUM, LPAR, RPAR, PLUS, MULT, ERROR, EOF}

    class Token
    {
        public TokenType type;
        public String value;

        public Token()
        {

        }

        public Token(TokenType t)
        {
            type = t;
        }

        public Token(TokenType t, string v)
        {
            type = t;
            value = v;
        }

        public override string ToString()
        {
            return "type=" + type + ", value=" + value;
        }
    }
}
