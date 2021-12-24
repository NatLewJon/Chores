using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChorseBackend.Models
{
    public class Kanban
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ICollection<Columns> Columns { get; set; }
    }
}
