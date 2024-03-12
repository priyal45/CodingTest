using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Program1
    {
        public static bool CheckParentheses(string code)
        {
            Stack<char> stack = new Stack<char>();

            foreach (char c in code)
            {
                if (c == '(')
                {
                    stack.Push(c);
                }
                else if (c == ')')
                {
                    if (stack.Count == 0 || stack.Pop() != '(')
                    {
                        return false;
                    }
                }
            }

            return stack.Count == 0;
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Enter the LISP code:");
            string code = Console.ReadLine();

            bool isValid = CheckParentheses(code);
            Console.WriteLine("Parentheses are properly closed and nested: " + isValid);
        }
    }
}
