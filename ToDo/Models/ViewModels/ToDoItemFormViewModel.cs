using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDo.Models.ViewModels
{
    public class ToDoItemFormViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int ToDoStatusId { get; set; }

        public List<SelectListItem> ToDoStatusOptions { get; set; }

        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }


    }
}
