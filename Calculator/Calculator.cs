namespace Calculator
{
    public class Calculator
    {
        public double Calculate(string sum)
        {
            try
            {
                var postfixExpression = ShuntingYard.ConvertToPostfix(sum);
                var stack = new Stack<double>();

                foreach (var token in postfixExpression.Split(' ', StringSplitOptions.RemoveEmptyEntries))
                {
                    if (double.TryParse(token, out var value))
                    {
                        stack.Push(value);
                    }
                    else
                    {
                        if (stack.Count < 2)
                        {
                            throw new Exception(Messages.InvalidExpression);
                        }
                        var rhs = stack.Pop();
                        var lhs = stack.Pop();
                        stack.Push(Calculate(lhs, rhs, char.Parse(token)));
                    }
                }
                if (stack.Count == 0)
                {
                    throw new Exception(Messages.InvalidExpression);
                }
                return stack.Pop();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static double Calculate(double lhs, double rhs, char op)
        {
            return op switch
            {
                Constants.OP_ADD => lhs + rhs,
                Constants.OP_MINUS => lhs - rhs,
                Constants.OP_MULTIPLY => lhs * rhs,
                Constants.OP_DIVIDE => lhs / rhs,
                _ => throw new Exception(Messages.InvalidOperator + op.ToString()),
            };
        }
    }
}
