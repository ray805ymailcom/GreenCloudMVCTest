using System.ComponentModel.DataAnnotations;

namespace GreenCloud.MVC.MVCSamplePage.Models
{
    public class UserInput
    {
        [Required(ErrorMessage = "Please enter positive whole number")]
        [RegularExpression("([0-9]+)", ErrorMessage = "Please enter positive whole number")]
        [StringLength(9, ErrorMessage = "Value is too long")]
        public string NumberEntered { get; set; } = "";
    }

}
