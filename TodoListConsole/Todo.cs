using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoListConsole
{
    public class Todo
    {
        private string _description;
        public string Description { get => _description; set => _description = value; }

        public Todo(string todo = "Default")
        {
            Description = todo;
            TodoList.AddTodo(this);
            Console.WriteLine($"Sikeresen hozzáadtad a teendőt a listádhoz: {Description}");
        }
    }
}
