﻿using System;
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

        static string ConvertToPostfix(string expression)
        {
            var output = new List<string>();
            var stack = new Stack<char>();
            var number = "";

            foreach (var c in expression)
            {
                if (char.IsDigit(c))
                {
                    number += c;
                }
                else
                {
                    if (!string.IsNullOrEmpty(number))
                    {
                        output.Add(number);
                        number = "";
                    }

                    if (c == '(')
                    {
                        stack.Push(c);
                    }
                    else if (c == ')')
                    {
                        while (stack.Count > 0 && stack.Peek() != '(')
                        {
                            output.Add(stack.Pop().ToString());
                        }

                        if (stack.Count > 0 && stack.Peek() == '(')
                        {
                            stack.Pop();
                        }
                    }
                    else if (c == '+' || c == '-' || c == '*' || c == '/')
                    {
                        while (stack.Count > 0 && GetPrecedence(c) <= GetPrecedence(stack.Peek()))
                        {
                            output.Add(stack.Pop().ToString());
                        }

                        stack.Push(c);
                    }
                }
            }

            if (!string.IsNullOrEmpty(number))
            {
                output.Add(number);
            }

            while (stack.Count > 0)
            {
                output.Add(stack.Pop().ToString());
            }

            return string.Join(" ", output);
        }

        static int EvaluatePostfix(string postfix)
        {
            var stack = new Stack<int>();
            var tokens = postfix.Split(' ');

            foreach (var token in tokens)
            {
                if (int.TryParse(token, out int number))
                {
                    stack.Push(number);
                }
                else
                {
                    int operand2 = stack.Pop();
                    int operand1 = stack.Pop();

                    switch (token)
                    {
                        case "+":
                            stack.Push(operand1 + operand2);
                            break;
                        case "-":
                            stack.Push(operand1 - operand2);
                            break;
                        case "*":
                            stack.Push(operand1 * operand2);
                            break;
                        case "/":
                            stack.Push(operand1 / operand2);
                            break;
                        default:
                            throw new ArgumentException($"Invalid operator: {token}");
                    }
                }
            }

            return stack.Pop();
        }

        static int GetPrecedence(char op)
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
