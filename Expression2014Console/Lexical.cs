using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expression2014Console
{
    class Lexical
    {
        private string myString;
        private int location;
        private int oldLocation;
        private string buffer;

        public Lexical(string s)
        {
            myString = s;
            location = 0;
            oldLocation = 0;
        }

        public void UngetToken()
        {
            location = oldLocation;
        }

        public Token GetNextToken()
        {
            oldLocation = location;
            Token t = q0();
            return t;
            //return q0();
        }

        private Token q0()
        {
            if(location>=myString.Length) //end of input
            {
                return q5();
            }

            if(myString[location]==' ')
            {
                location++;
                return q0();
            }

            if (myString[location] == '(')
            {
                location++;
                return q1();
            }

            if (myString[location] == ')')
            {
                location++;
                return q2();
            }

            if (myString[location] == '+')
            {
                location++;
                return q3();
            }

            if (myString[location] == '*')
            {
                location++;
                return q4();
            }

            if (myString[location] >= '0' && myString[location] <= '9')
            {
                buffer = "" + myString[location];
                location++;
                return q6();
            }


            location++;
            return q8();
        }

        private Token q5()
        {
            return new Token(TokenType.EOF);
        }

        private Token q1()
        {
            return new Token(TokenType.LPAR);
        }

        private Token q2()
        {
            return new Token(TokenType.RPAR);
        }

        private Token q3()
        {
            return new Token(TokenType.PLUS);
        }

        private Token q4()
        {
            return new Token(TokenType.MULT);
        }

        private Token q8()
        {
            return new Token(TokenType.ERROR);
        }

        private Token q6()
        {
            if (location >= myString.Length)
                return q7();

            if (myString[location] >= '0' && myString[location] <= '9')
            {
                buffer = buffer + myString[location];
                location++;
                return q6();
            }

            return q7();
        }

        private Token q7()
        {
            return new Token(TokenType.NUM, buffer);
        }

    }
}
