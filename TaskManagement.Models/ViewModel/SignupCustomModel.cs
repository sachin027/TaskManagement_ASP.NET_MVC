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
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        // [Required]
        // public string ConfirmPassword { get; set; }

        [Required]
        public string Email { get; set; }
        [Required]
        [StringLength(10)]
        [RegularExpression("^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public string PhoneNumber { get; set; }
        [Required]
        public string Role { get; set; }
        [Required]
        public Nullable<int> StateID { get; set; }
        [Required]
        public Nullable<int> CityID { get; set; }
        [Required]
        public string Address { get; set; }

    }
}