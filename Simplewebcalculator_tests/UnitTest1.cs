using Xunit;
using SimpleCalculatorWeblinux.Controllers;
using SimpleCalculatorWeblinux.Models;
using Microsoft.AspNetCore.Mvc;

namespace Simplewebcalculator_tests
{
    public class Unit1
    {
        [Fact]
        public void AddOperation_ReturnsCorrectResult()
        {
            // Arrange
            var controller = new CalculatorController();
            var model = new CalculatorModel { Value1 = 5, Value2 = 3, Operation = "Add" };

            // Act
            var result = controller.Calculate(model) as ViewResult;
            var resultModel = result.Model as CalculatorModel;

            // Assert
            Assert.Equal(8, resultModel.Result);
        }

        [Fact]
        public void SubtractOperation_ReturnsCorrectResult()
        {
            // Arrange
            var controller = new CalculatorController();
            var model = new CalculatorModel { Value1 = 5, Value2 = 3, Operation = "Subtract" };

            // Act
            var result = controller.Calculate(model) as ViewResult;
            var resultModel = result.Model as CalculatorModel;

            // Assert
            Assert.Equal(2, resultModel.Result);
        }

        [Fact]
        public void MultiplyOperation_ReturnsCorrectResult()
        {
            // Arrange
            var controller = new CalculatorController();
            var model = new CalculatorModel { Value1 = 5, Value2 = 3, Operation = "Multiply" };

            // Act
            var result = controller.Calculate(model) as ViewResult;
            var resultModel = result.Model as CalculatorModel;

            // Assert
            Assert.Equal(15, resultModel.Result);
        }

        [Fact]
        public void DivideOperation_ReturnsCorrectResult()
        {
            // Arrange
            var controller = new CalculatorController();
            var model = new CalculatorModel { Value1 = 6, Value2 = 3, Operation = "Divide" };

            // Act
            var result = controller.Calculate(model) as ViewResult;
            var resultModel = result.Model as CalculatorModel;

            // Assert
            Assert.Equal(2, resultModel.Result);
        }

        [Fact]
        public void DivideByZero_ReturnsZero()
        {
            // Arrange
            var controller = new CalculatorController();
            var model = new CalculatorModel { Value1 = 6, Value2 = 0, Operation = "Divide" };

            // Act
            var result = controller.Calculate(model) as ViewResult;
            var resultModel = result.Model as CalculatorModel;

            // Assert
            Assert.Equal(0, resultModel.Result);
        }
    }
}

}