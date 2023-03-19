string userInput;
Console.WriteLine("Enter an expression, x to exit - ");
userInput = Console.ReadLine();

while (userInput != "x")
{
    var calculator = new Calculator.Calculator();
    double computedResult = 0D;
    try
    {
        computedResult = calculator.Calculate(userInput);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        Console.WriteLine("Enter an expression, x to exit - ");
        userInput = Console.ReadLine();
        continue;
    }
    Console.WriteLine("You entered: '{0}'", userInput);
    Console.WriteLine("Result: '{0}'", computedResult);

    Console.WriteLine("Enter an expression, x to exit - ");
    userInput = Console.ReadLine();
}