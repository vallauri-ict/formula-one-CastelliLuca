using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace toDoApi.models
{
    public class toDoContext : DbContext
    {
        public toDoContext(DbContextOptions<toDoContext> options)
            : base(options)
        {
        }

        public DbSet<toDoItem> TodoItems { get; set; }
    }
}
