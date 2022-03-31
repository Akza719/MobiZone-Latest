using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DomainLayer
{
    public class AdminLogin
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage="Username is required")]
        public string  Username { get; set; }
        [Required(ErrorMessage = "Password is required")]

        public string Password { get; set; }
    }
}
