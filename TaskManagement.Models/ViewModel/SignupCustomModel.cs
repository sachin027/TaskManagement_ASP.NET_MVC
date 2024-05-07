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
        // [Required]
        public string Username { get; set; }
        // [Required]
        public string Password { get; set; }
        // [Required]
        public string ConfirmPassword { get; set; }
        // [Required]
        public string Email { get; set; }
        //[Required]
        public string PhoneNumber { get; set; }
        //[Required]
        public string Role { get; set; }
        public Nullable<int> StateID { get; set; }
        public Nullable<int> CityID { get; set; }
        //[Required]
        public string Address { get; set; }

    }
}