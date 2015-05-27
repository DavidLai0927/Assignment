using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;


namespace Calculator
{
    class Program
    {
        
        static void Main(string[] args)
        {
            
            Console.WriteLine("C# Simple Console Calculator");
            Console.WriteLine("Type \"Quit\" to quit");
            myCal cal = new myCal();
            Console.Write("> ");
            while (true)
            {
                char input = Convert.ToChar(Console.Read());
                cal.read(input);
            }
        }
        
    }

    class myCal
    {
        Stack<char> myOp = new Stack<char>();
        Stack<double> myNum = new Stack<double>();
        double l, r, temp = 0 , decTemp = 1 , dec = 0;
        char buffer = 'n';
        public void read(char input)
        {
            try
            {
                if (buffer != 'n')
                {
                    if (input != '.' && ((Convert.ToInt32(input) - '0') < 0 || (Convert.ToInt32(input) - '0') > 9))
                    {
                        temp += dec;
                        myNum.Push(temp);
                        dec = 0;
                        temp = 0;
                        decTemp = 1;
                        buffer = 'n';
                    }
                    else if (buffer == '.')
                    {
                        decTemp /= 10;
                        dec += (Convert.ToInt32(input) - '0') * decTemp;
                    }
                    else if (input != '.')
                    {
                        temp = temp * 10 + (Convert.ToInt32(input) - '0');
                    }
                   
                }
                if (input == '+' || input == '-')
                {
                    while (myOp.Count() != 0 && myOp.Peek() != '(')
                    {
                        r = myNum.Pop(); l = myNum.Pop();
                        switch (myOp.Pop())
                        {
                            case '+':
                                myNum.Push(l + r);
                                break;
                            case '-':
                                myNum.Push(l - r);
                                break;
                            case '*':
                                myNum.Push(l * r);
                                break;
                            case '/':
                                myNum.Push(l / r);
                                break;
                        }
                    }
                    myOp.Push(input);
                }
                else if (input == '*' || input == '/' || input == '(')
                {
                    myOp.Push(input);
                }
                else if (input == ')') 
                {
                    while (myOp.Peek() != '(')
                    {
                        if (myOp.Count()==0)
                        {
                            throw new Exception("");
                        }
                        r = myNum.Pop(); l = myNum.Pop();
                        switch (myOp.Pop())
                        {
                            case '+':
                                myNum.Push(l + r);
                                break;
                            case '-':
                                myNum.Push(l - r);
                                break;
                            case '*':
                                myNum.Push(l * r);
                                break;
                            case '/':
                                myNum.Push(l / r);
                                break;
                        }
                    }
                    myOp.Pop();//'('
                }
                else if (input == '\n') // windows CR = /r/n 
                {
                    read('+');
                    myOp.Pop();
                    if (myOp.Count != 0 )
                        throw new Exception("");
                    if (myNum.Count != 0)
                    {
                        Console.WriteLine("\nAnswer = " + myNum.Peek());
                        Console.WriteLine();
                        Console.Write("> ");
                    }
                    //while (myNum.Count != 0)
                    //{
                    //    Console.Write("myNUM : " + myNum.Pop() + " ");
                    //}

                    myOp.Clear();
                    myNum.Clear();
                    
                }
                else if (input == '\t' || input == ' ' || input == '\r')
                {
                }
                else if (input == '.' || ((Convert.ToInt32(input) - '0') >= 0 && (Convert.ToInt32(input) - '0') <= 9))
                {
                    if (buffer == 'n')
                        temp = (Convert.ToInt32(input) - '0');
                    if (buffer != '.')
                        buffer = input;

                }
                else if (input == 'q' || input == 'Q')
                {
                    System.Environment.Exit(0);
                }
                else
                {
                    throw new Exception("");
                }
     
                
                    
            }
            catch (Exception e)
            {
                Console.WriteLine("\nsyntax error\n");
                myOp.Clear();
                myNum.Clear();
                Console.ReadLine();
                Console.Write("> ");
            }
        }
       
      }

}
