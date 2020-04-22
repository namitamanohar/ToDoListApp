using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDo.Models
{
    public class ToDoItem
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int ToDoStatusId { get; set; }

        public ToDoStatus ToDoStatus { get; set; }

        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
    }
}
