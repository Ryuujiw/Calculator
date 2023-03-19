# Calculator [![.NET](https://github.com/Ryuujiw/Calculator/actions/workflows/dotnet.yml/badge.svg)](https://github.com/Ryuujiw/Calculator/actions/workflows/dotnet.yml)

This program accepts a mathematical expression in plain string and will compute the expression. 

An example of an expression is 
```
( 11.5 + 11.4 ) + 10.1
```

Details on how it works:

The program converts the accepted string into a postfix expression.
An example of a postfix expression for ```1 + 1``` is
```
1 1 +
```
This infix to postfix conversion is achieved by using the [Shunting Yard algorithm](https://en.wikipedia.org/wiki/Shunting_yard_algorithm#:~:text=In%20computer%20science%2C%20the%20shunting,abstract%20syntax%20tree%20(AST))

In brief, the shunting yard algorithm will

Iterate the expression:\
  Is letter or digit or decimal point => Append to a temporary string\
  Is left paren => Push to stack\
  Is right paren => Pop the stack and append the value to the temporary string until a left paren is found. \
                    Pop the stack again to remove the left paren\
  Else (is operator) => While current operator has lower or equal precedence than the stack's next found operator, pop stack and append the value to temporary string\
                        Push the operator to stack
  
Once the expression has been converted to a postfix conversion, the program will perform the following:

Iterate the expression:\
  Is digit => push to stack\
  Is operator => pop the stack twice to get its left and right assignments and perform the appropriate calculation:
  ```
  {left} {operator (current token)} {right}
  ```
  Push the calculated value back to the stack
  
