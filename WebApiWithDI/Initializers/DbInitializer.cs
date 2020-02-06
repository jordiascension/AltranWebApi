using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiWithDI.Initializers
{
    public static class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = (TodoContext)serviceProvider.
                GetService(typeof(TodoContext));
            
                var todoItem1 = new Models.TodoItem
                {
                    Id = 1,
                    Name = "Luke",
                    IsComplete = true
                };

                context.TodoItems.Add(todoItem1);

                var todoItem2 = new Models.TodoItem
                {
                    Id = 2,
                    Name = "Pepe",
                    IsComplete = true
                };

                context.TodoItems.Add(todoItem2);

                context.SaveChanges();
            
        }
    }
}
