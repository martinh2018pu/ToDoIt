using System.Data.Entity;
using ToDoIt.Models;

namespace ToDoIt.DataAccess
{
    public class ToDoItDbContext : DbContext
    {
        public DbSet<Note> Notes { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public ToDoItDbContext() : base("ToDoIt")
        {
        }
    }
}