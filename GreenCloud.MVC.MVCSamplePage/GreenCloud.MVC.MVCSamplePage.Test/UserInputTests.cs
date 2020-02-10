using System.Collections.Generic;
using GreenCloud.MVC.MVCSamplePage.Models;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Xunit;

namespace GreenCloud.MVC.MVCSamplePage.Test
{
    public class UserInputTests
    {
        private static IEnumerable<ValidationResult> ValidateUserInput(object model)
        {
            var validationContext = new ValidationContext(model);
            var validationResults = new List<ValidationResult>();
            Validator.TryValidateObject(model, validationContext, validationResults, true);
            return validationResults;
        }

        [Theory]
        [InlineData("", "Please enter positive whole number")]
        [InlineData("-54", "Please enter positive whole number")]
        [InlineData("15.8", "Please enter positive whole number")]
        [InlineData("dkrkfdf", "Please enter positive whole number")]
        [InlineData("58498485995", "Value is too long")]
        public void InvalidInputReturnsCorrectErrorMessage(string stringEntered, string expectedErrorMessage)
        {
            var userInput = new UserInput
            {
                NumberEntered = stringEntered
            };

            Assert.Contains(ValidateUserInput(userInput),
                (v => v.ErrorMessage.Contains(expectedErrorMessage)));
        }

        [Theory]
        [InlineData("9")]
        [InlineData("10")]
        [InlineData("15")]
        [InlineData("1")]
        public void ValidInputReturnsNoErrorMessages(string stringEntered)
        {
            var userInput = new UserInput
            {
                NumberEntered = stringEntered
            };

            var validationResults = ValidateUserInput(userInput);

            var errors = validationResults.Where(e => e != ValidationResult.Success);

            Assert.Empty(errors);
        }
    }
}
