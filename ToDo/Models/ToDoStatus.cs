using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToDo.Models
{
    public class ToDoStatus
    {
        public int Id { get; set; }

        [Required]
        public string Status { get; set; }
    }
}
