using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoBack.Database.Models;

namespace ToDoBack.Database
{
    public class ToDosDbContext:DbContext
    {
       
        public ToDosDbContext(DbContextOptions<ToDosDbContext> options):base(options)
        {

        }

        public DbSet<ToDos> ToDos { get; set; }
    }
}
