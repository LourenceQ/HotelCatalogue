using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelCatalogue.Model
{
    public class LoginUserDTO
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [StringLength(15, ErrorMessage = "Your Password is limited to {2} to {1} characteres", MinimumLength = 6)]
        public string Password { get; set; }
    }

    public class UserDTO : LoginUserDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        
    }
}
