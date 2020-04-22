using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ToDo.Models;

namespace ToDo.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUser { get; set; }

        public DbSet<ToDoItem> ToDoItem { get; set; }

        public DbSet<ToDoStatus> ToDoStatus { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);



            modelBuilder.Entity<ToDoStatus>().HasData(
                new ToDoStatus()
                {
                    Id = 1,
                    Status = "Todo"
                },
                new ToDoStatus()
                {
                    Id = 2,
                    Status = "In Progress"
                },
                 new ToDoStatus()
                 {
                     Id = 3,
                     Status = "Done"
                 }

                 );
        }

    }
}

