using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class StringAnalyze
    {
        private string _expression; 

        public StringAnalyze(string expression) 
        { 
            _expression = expression;   
        }

        public StringAnalyze()
        {
            
        }

        public void SetExpression(string expression)
        {
            _expression = expression; 
        }

        public string GetResult()
        {
            string postfix = ConvertToPostfix(_expression);
            int result = EvaluatePostfix(postfix);
            return result.ToString(); 
        }

        private string ConvertToPostfix(string expression)
        {
            var output = new List<char>();
            var stack = new Stack<char>();

            foreach (var c in expression)
            {
                if (char.IsDigit(c))
                {
                    output.Add(c);
                }
                else if (c == '(')
                {
                    stack.Push(c);
                }
                else if (c == ')')
                {
                    while (stack.Count > 0 && stack.Peek() != '(')
                    {
                        output.Add(stack.Pop());
                    }

                    if (stack.Count > 0 && stack.Peek() == '(')
                    {
                        stack.Pop();
                    }
                }
                else
                {
                    while (stack.Count > 0 && GetPrecedence(c) <= GetPrecedence(stack.Peek()))
                    {
                        output.Add(stack.Pop());
                    }

                    stack.Push(c);
                }
            }

            while (stack.Count > 0)
            {
                output.Add(stack.Pop());
            }

            return new string(output.ToArray());
        }

        private int EvaluatePostfix(string postfix)
        {
            var stack = new Stack<int>();

            foreach (var c in postfix)
            {
                if (char.IsDigit(c))
                {
                    stack.Push(c - '0');
                }
                else
                {
                    int operand2 = stack.Pop();
                    int operand1 = stack.Pop();

                    switch (c)
                    {
                        case '+':
                            stack.Push(operand1 + operand2);
                            break;
                        case '-':
                            stack.Push(operand1 - operand2);
                            break;
                        case '*':
                            stack.Push(operand1 * operand2);
                            break;
                        case '/':
                            stack.Push(operand1 / operand2);
                            break;
                        default:
                            throw new ArgumentException($"Invalid operator: {c}");
                    }
                }
            }

            return stack.Pop();
        }

        private int GetPrecedence(char op)
        {
            switch (op)
            {
                case '+':
                case '-':
                    return 1;
                case '*':
                case '/':
                    return 2;
                default:
                    return 0;
            }
        }
    }
}
