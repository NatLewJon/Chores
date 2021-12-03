using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChorseBackend.Models;

namespace ChorseBackend.Models
{
    public class Chores
    {
        public int id { get; set; }
        public Client assignee { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int status { get; set; }
        public DateTime timestamp { get; set; }
        public int kanban_id { get; set; } 

       
    }
}
