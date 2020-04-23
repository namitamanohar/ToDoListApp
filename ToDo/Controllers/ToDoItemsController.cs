using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ToDo.Data;
using ToDo.Models;
using ToDo.Models.ViewModels;

namespace ToDo.Controllers
{
    [Authorize]
    public class ToDoItemsController : Controller
    {

        private readonly ApplicationDbContext _context;

        private readonly UserManager<ApplicationUser> _userManager;

        public ToDoItemsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {

            _context = context;
            _userManager = userManager;
        }
        // GET: ToDoItems
        public async Task<ActionResult> Index(string filterButton)
        {
            var user = await GetCurrentUserAsync();

            //var items = await _context.ToDoItem
            //  .Where(ti => ti.ApplicationUserId == user.Id)
            //  .Include(ti => ti.ToDoStatus); 
     

            //switch (filterButton)
            //{

            //    case "To Do":

            //   items = items.Where(ti => ti.ToDoStatusId == 1).ToListAsync(); 
         
            //        break; 

            //     case "Progress":
           
            //   items =items.Where(ti => ti.ToDoStatusId == 2); 
            
            //        break; 


            //}
            //return View(items).ToListAsync(); 

            if(filterButton == "To Do")
            {
                var items = await _context.ToDoItem
          .Where(ti => ti.ApplicationUserId == user.Id)
          .Where(ti => ti.ToDoStatusId == 1)
          .Include(ti => ti.ToDoStatus)
          .ToListAsync();


                return View(items);
            }
            else if(filterButton == "Progress")
            {
                var items = await _context.ToDoItem
          .Where(ti => ti.ApplicationUserId == user.Id)
          .Where(ti => ti.ToDoStatusId == 2)
          .Include(ti => ti.ToDoStatus)
          .ToListAsync();

                return View(items);
            } else if(filterButton == "Done")
            {
                var items = await _context.ToDoItem
          .Where(ti => ti.ApplicationUserId == user.Id)
            .Where(ti => ti.ToDoStatusId == 3)
          .Include(ti => ti.ToDoStatus)
          .ToListAsync();

                return View(items);
            }
            else
            {

            var items = await _context.ToDoItem
                .Where(ti => ti.ApplicationUserId == user.Id)
                .Include(ti => ti.ToDoStatus)
                .ToListAsync();

                return View(items);
            }


         
        }


        // GET: ToDoItems/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ToDoItems/Create
        public async Task<ActionResult> Create()
        {

            var ToDoStatuses = await _context.ToDoStatus
                .Select(td => new SelectListItem() { Text = td.Status, Value = td.Id.ToString() })
                .ToListAsync();

            var viewModel = new ToDoItemFormViewModel();

            viewModel.ToDoStatusOptions = ToDoStatuses;

            return View(viewModel);
        }


        // POST: ToDoItems/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ToDoItemFormViewModel toDoViewItem)
        {
            try
            {
                var toDoItem = new ToDoItem
                {
                    Title = toDoViewItem.Title,
                    ToDoStatusId = toDoViewItem.ToDoStatusId

                }; 

                var user = await GetCurrentUserAsync();
                toDoItem.ApplicationUserId = user.Id;

                _context.ToDoItem.Add(toDoItem);
                await _context.SaveChangesAsync(); 

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ToDoItems/Edit/5
        public async  Task<ActionResult> Edit(int id)
        {
            var item = await _context.ToDoItem.FirstOrDefaultAsync(ti => ti.Id == id);
            var loggedInUser = await GetCurrentUserAsync();


            var ToDoStatuses = await _context.ToDoStatus
                .Select(td => new SelectListItem() { Text = td.Status, Value = td.Id.ToString() })
                .ToListAsync();

            var viewModel = new ToDoItemFormViewModel()
            {
                Id = id,
                Title = item.Title, 
                ToDoStatusId = item.ToDoStatusId, 
                ToDoStatusOptions = ToDoStatuses, 
              
            }; 

            if (item.ApplicationUserId != loggedInUser.Id)
            {
                return NotFound();
            }

            return View(viewModel);
        }

        // POST: ToDoItems/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, ToDoItemFormViewModel toDoViewItem)
        {
            try
            {
                                
                var toDoItem = new ToDoItem()
                {
                    Id = toDoViewItem.Id,
                    Title = toDoViewItem.Title, 
                    ToDoStatusId = toDoViewItem.ToDoStatusId 
                };

                var user = await GetCurrentUserAsync();
                toDoItem.ApplicationUserId = user.Id;

                _context.ToDoItem.Update(toDoItem);
                await _context.SaveChangesAsync(); 

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ToDoItems/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var item = await _context.ToDoItem.Include(i => i.ToDoStatus).FirstOrDefaultAsync(i => i.Id == id); 
               
            return View(item);
        }

        // POST: ToDoItems/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, ToDoItem toDoItem)
        {
            try
            {

                _context.ToDoItem.Remove(toDoItem);
                await _context.SaveChangesAsync(); 

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

    }
}