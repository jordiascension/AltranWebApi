using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiWithDI.Models;

namespace WebApiWithDI
{
    public class SqlServerTodoContext : DbContext
    {
        public SqlServerTodoContext(DbContextOptions<SqlServerTodoContext> options)
            : base(options)
        {
            
        }

        public DbSet<TodoItemSqlServer> TodoItemSqlServer { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodoItemSqlServer>().HasData(new TodoItemSqlServer
            {
                Id=1,
                Name="Pepe From Sql Server",
                IsComplete=true

            }, new TodoItemSqlServer
            {
                Id = 2,
                Name = "Pepe From Sql Server",
                IsComplete = true
            });
        }
    }
}
