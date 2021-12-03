using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChorseBackend.Models
{
    public class Client
    {
        public int id { get; set; }
        public string username { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string password { get; set; }
    }
}
