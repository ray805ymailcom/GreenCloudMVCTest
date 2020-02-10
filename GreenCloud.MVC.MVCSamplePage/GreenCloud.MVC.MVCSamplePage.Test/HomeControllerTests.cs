using GreenCloud.MVC.MVCSamplePage.Controllers;
using GreenCloud.MVC.MVCSamplePage.Models;
using Xunit;

namespace GreenCloud.MVC.MVCSamplePage.Test
{
    public class HomeControllerTests
    {
        [Fact]
        public void NoErrorReturnsValidModel()
        {
            var homeController = new HomeController();

            var userInput = new UserInput
            {
                NumberEntered = "15"
            };

            _ = homeController.NumberForm(userInput);

            Assert.Equal(0,homeController.ModelState.ErrorCount);
            Assert.True(homeController.ModelState.IsValid);
        }

        [Fact]
        public void ErrorReturnsInvalidModel()
        {
            var homeController = new HomeController();

            _ = homeController.NumberForm(new UserInput());

            Assert.NotEqual(0, homeController.ModelState.ErrorCount);
            Assert.False(homeController.ModelState.IsValid);
        }
    } 
}
