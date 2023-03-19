namespace Calculator
{
    public static class ShuntingYard
    {
        public static string ConvertToPostfix(string input)
        {
            string postfix = string.Empty;
            var stack = new Stack<char>();

            foreach (var c in input)
            {
                if (char.IsLetterOrDigit(c) || c == Constants.OP_DECIMAL || char.IsWhiteSpace(c))
                {
                    postfix += c;
                }
                else if (c == Constants.LEFT_PAREN)
                {
                    stack.Push(c);
                }
                else if (c == Constants.RIGHT_PAREN)
                {
                    while (stack.Count > 0 && stack.Peek() != Constants.LEFT_PAREN)
                    {
                        postfix += $" {stack.Pop()}";
                    }
                    stack.Pop();
                }
                else // OPERATOR
                {
                    while (stack.Count > 0 && Precedence(c) <= Precedence(stack.Peek()))
                    {
                        postfix += $" {stack.Pop()}";
                    }
                    stack.Push(c);
                }
            }

            while (stack.Count > 0)
            {
                postfix += $" {stack.Pop()}";
            }

            return postfix;
        }

        private static int Precedence(char c)
        {
            if (c == Constants.OP_ADD || c == Constants.OP_MINUS)
            {
                return 1;
            }
            if (c == Constants.OP_MULTIPLY || c == Constants.OP_DIVIDE)
            {
                return 2;
            }
            return -1;
        }
    }
}
