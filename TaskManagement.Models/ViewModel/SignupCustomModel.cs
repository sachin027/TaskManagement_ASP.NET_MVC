using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Models.ViewModel
{
    public class SignupCustomModel
    {
        public int UserId { get; set; }

        [Required]
        [MaxLength(8, ErrorMessage = "Maximum 8 characters allowed")]
        [MinLength(4, ErrorMessage = "Minimum 4 characters should be entered")]                                                    
        public string Username { get; set; }

        [Required]
        [MaxLength(6 , ErrorMessage ="Password length should be 6 digit")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Password is not identical")]
        public string ConfirmPassword { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z0-9_.%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email id.")]
        public string Email { get; set; }
        [Required]
        [StringLength(10)]
        [RegularExpression("^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public string PhoneNumber { get; set; }

        [Required]
        public string Role { get; set; }

        [Required(ErrorMessage ="State must be selected")]
        public Nullable<int> StateID { get; set; }

        [Required(ErrorMessage = "City must be selected")]
        public Nullable<int> CityID { get; set; }

        [Required]
        public string Address { get; set; }

    }
}