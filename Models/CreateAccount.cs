using System.ComponentModel.DataAnnotations;

namespace MarketingApp.Models
{
    public class CreateAccount
    {
        public int AccountID { get; set; }
        [Required]
        [MinLength(5)]
        [MaxLength(20)]
        //[Required(ErrorMessage = "Kindly Enter Username"),MinLength(5),MaxLength(20)]
        public string Username { get; set; }
        //[Required(ErrorMessage = "Kindly Enter Mobile"), MaxLength(10)]
        [Required]
        [MaxLength(10)]
        [RegularExpression(@"^([6789]{1}[0-9]{9})*$", ErrorMessage = "Enter Valid Mobile")]
        public string Mobile { get; set; }
        //[Required(ErrorMessage = "Kindly Enter Username"),MaxLength(100)]
        [Required]
        [MaxLength(100)]
        [RegularExpression(@"^[a-zA-Z0-9.!#$%&'*+=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$", ErrorMessage = "Enter Valid EmailID")]
        public string EmailID { get; set; }
        [Required]
        [RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$", ErrorMessage = "Enter Valid  Password")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Kindly Enter ConfirmPassword"), MaxLength(8)]
        [RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$", ErrorMessage = "Enter valid Confirm Password")]

        public string ConfirmPassword { get; set; }
    }
}
