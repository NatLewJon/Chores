using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ChorseBackend.Models
{
    public class ClientLogin
    {
        [Required(ErrorMessage ="User name is mandatory")]
        public string username { get; set; }
        [Required(ErrorMessage = "Password is mandatory")]
        public string password { get; set; }
    }
}
