using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asana3.Library.Models
{
    public class Project
    {

        public int Id { get; set; }
        public string? Name { get; set; }

        public string? Description { get; set; }

        public int CompletePercent { get; set; }

        public List<ToDo> ToDos { get; set; } = new List<ToDo>();

        public override string ToString()
        {
            return $"[{Id}] {Name} - {Description} ({CompletePercent}%)";
        }

    }
}
