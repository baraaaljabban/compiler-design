using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL_Project_BJN
{
    class PARSER
    {
        private LEXICAL l;
        private TOKEN t;
        public PARSER(string s)
        {
            l = new LEXICAL(s);
        }

        private void error(string s)
        {
            Console.WriteLine(s);
            //   Environment.Exit(0);
        }

        public void go()
        {
            int i = 0;
            t = l.GetNextToken();
            while (t.type != TokenType.EOP)
            {
                if (t.type != TokenType.NUMLINE)
                    error("You must begin with line number");
                t = l.GetNextToken();
                while (t.type == TokenType.LITER || t.type == TokenType.PRINT || t.type == TokenType.READ || t.type == TokenType.FOR || t.type == TokenType.NEXT)
                {
                    if (t.type == TokenType.LITER)
                        idenFun();
                    else if (t.type == TokenType.PRINT)
                        printFun();
                    else if (t.type == TokenType.READ)
                        readFun();
                    else if (t.type == TokenType.FOR)
                        forFun();
                    else if (t.type == TokenType.NEXT)
                        nextFun();
                }
                if (t.type != TokenType.EOP)
                    error("You must end the program with dot.\n");
            }
            Console.WriteLine("program is corretct \n");
            go();
        }

        public void idenFun()
        {
            t = l.GetNextToken();
            if (t.type == TokenType.EQUAL)
            {
                t = l.GetNextToken();
                expFun();
            }
            if (t.type != TokenType.EOL)
                error(" ");
            t = l.GetNextToken();
        }
        public void printFun()
        {
            if (t.type != TokenType.PRINT) // ما بدي ياه
                error("error in the exprison after th word print \n");
            t = l.GetNextToken();
            expFun();
            if (t.type != TokenType.EOL)
                error("i did not find  =  \n");
            t = l.GetNextToken();
        }
        public void readFun()
        {

            t = l.GetNextToken();
            idenFun();


            t = l.GetNextToken();

        }
        public void forFun()
        {
            t = l.GetNextToken();
            if (t.type == TokenType.LITER)
            {
                t = l.GetNextToken();
                if (t.type == TokenType.EQUAL)
                {
                    t = l.GetNextToken();
                    expFun();
                    if (t.type == TokenType.TO)
                    {
                        t = l.GetNextToken();
                        expFun();
                        if (t.type == TokenType.EOL)
                        {
                            t = l.GetNextToken();
                        }
                        else error("this line did not end with ENTER /n");
                    }
                    else error("did not find the writ exprsion after  the TO token /n");
                }
                else error("did not find the the right exprion after the idinatfaier = /n ");
            }
            else error("did not find the identefaier after FOR /n \n");
        }
        public void nextFun()
        {
            t = l.GetNextToken();
            if (t.type == TokenType.NUM)
            {
                t = l.GetNextToken();
                if (t.type == TokenType.EOL)
                    t = l.GetNextToken();
                error("you did n ot finsh whith enter after netx fun");

            }

        }
        public void expFun()
        {


            if (t.type == TokenType.LITER || t.type == TokenType.NUM)
                A();
            while (t.type == TokenType.PLUES)
            {

                t = l.GetNextToken();
                expFun();

            }
            t = l.GetNextToken();


        }

        public void A()
        {
            if (t.type == TokenType.LITER || t.type == TokenType.NUM)
                B();
            while (t.type == TokenType.MULT)
            {

                t = l.GetNextToken();
                A();

            }
            t = l.GetNextToken();
        }
        public void B()
        {
            if (t.type != TokenType.NUM && t.type != TokenType.LITER)
                error("there is no number or identfier \n");
            t = l.GetNextToken();
        }


    }
}
