using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.Business.DTOs.Request
{
    public class UserRequestDTO
    {
        [Required]
        [MinLength(2)]
        [MaxLength(256)]
        public string FirstName { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(256)]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MinLength(6)]
        [MaxLength(20)]
        public string Password { get; set; }
    }
}
