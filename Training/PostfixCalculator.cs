namespace Training
{
    public static class PostfixCalculator
    {
        public static List<string> EvaluatePostfixExpression(string expression)
        {
            List<string> results = new List<string>();

            Stack<double> stack = new Stack<double>();

            foreach (char token in expression)
            {
                if (char.IsDigit(token))
                {
                    stack.Push(double.Parse(token.ToString()));
                }
                else if (IsOperator(token))
                {
                    if (stack.Count < 2)
                    {
                        string invalidExpr = "Invalid expression: Not enough operands.";

                        results.Add(invalidExpr);
                    }

                    double operand2 = stack.Pop();
                    double operand1 = stack.Pop();
                    string result = ApplyOperator(token, operand1, operand2);

                    try
                    {
                        double c = double.Parse(result);
                        stack.Push(c);
                    }
                    catch
                    {
                        string c = "Exception. Divide by zero";
                        results.Add(c);
                    }
                }
                else
                {
                    string invalidTok = "Exception. Wrong input";
                    results.Add(invalidTok);
                    return results;
                }
            }

            if (stack.Count == 1)
            {
                string a = stack.Pop().ToString();
                results.Add(a);
            }
            else
            {
                string manyOperands = "Invalid expression: Too many operands.";
                results.Add(manyOperands);
            }
            return results;
        }

        private static bool IsOperator(char token)
        {
            return token == '+' || token == '-' || token == '*' || token == '/';
        }

        private static string ApplyOperator(char op, double a, double b)
        {
            switch (op)
            {
                case '+':
                    string res = (a + b).ToString();
                    return res;
                case '-':
                    string res2 = (a - b).ToString();
                    return res2;
                case '*':
                    string res3 = (a * b).ToString();
                    return res3;
                case '/':
                    if (b != 0)
                    {
                        string res4 = (a / b).ToString();
                        return res4;
                    }
                    else
                    {
                        string res5 = "cannot dived by zero";
                        return res5;
                    }
                default:
                    string def = "invalid expression";
                    return def;
            }
        }
    }
}
