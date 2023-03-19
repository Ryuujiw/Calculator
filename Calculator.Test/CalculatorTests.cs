using System;
using Xunit;

namespace Calculator.Test
{
    public class CalculatorTests
    {
        [Theory]
        [InlineData("1 + 1", 2)]
        [InlineData("2 * 2", 4)]
        [InlineData("1 + 2 + 3", 6)]
        [InlineData("6 / 2", 3)]
        [InlineData("11 + 23", 34)]
        [InlineData("11.1 + 23", 34.1)]
        [InlineData("1 + 1 * 3", 4)]
        public void Calculate(string expression, double expectedResult)
        {
            // Arrange
            var calculator = new Calculator();
            // Act
            var computedResult = calculator.Calculate(expression);
            // Assert
            Assert.Equal(expectedResult, computedResult);
        }

        [Theory]
        [InlineData("( 11.5 + 15.4 ) + 10.1", 37)]
        [InlineData("23 - ( 29.3 - 12.5 )", 6.2)]
        [InlineData("( 1 / 2 ) - 1 + 1", 0.5)]
        public void CalculateWithParenthesis(string expression, double expectedResult)
        {
            // Arrange
            var calculator = new Calculator();
            // Act
            var computedResult = calculator.Calculate(expression);
            // Assert
            Assert.Equal(expectedResult, computedResult, 1);
        }

        [Theory]
        [InlineData("10 - ( 2 + 3 * ( 7 - 5 ) )", 2)]
        public void CalculateWithNestedParenthesis(string expression, double expectedResult)
        {
            // Arrange
            var calculator = new Calculator();
            // Act
            var computedResult = calculator.Calculate(expression);
            // Assert
            Assert.Equal(expectedResult, computedResult);
        }

        [Fact]
        public void ShouldThrowExceptionWhenIsAnInvalidExpression()
        {
            // Arrange
            var calculator = new Calculator();
            var expression = "test";
            // Act
            // Assert
            Assert.Throws<Exception>(() => calculator.Calculate(expression));
        }
    }
}