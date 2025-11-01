using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoListConsole
{
    public class TodoList
    {
        private static int _id = 1;
        public static int Id { get => _id; }
        public static Dictionary<int, Todo> Todos = new Dictionary<int, Todo>();
        
        public static void AddTodo(Todo description)
        {
            Todos.Add(Id, description);
            _id++;
        }

        public static void ShowTodos()
        {
            if (Todos.Count > 0)
            {
                Console.WriteLine("\nJelenlegi teendőid:");
                Console.ForegroundColor = ConsoleColor.Green;
                foreach (var todo in Todos)
                {
                    Console.WriteLine($"{todo.Key.ToString()}. {todo.Value.Description}");
                }
                Console.ForegroundColor = ConsoleColor.White;
            } else
            {
                throw new Exception("Nincs semmilyen teendőd.");
            }
            
        }

        public static void CompleteTodo(int id)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\nSikeresen kivetted ezt a teendőt a listádból: '{Todos[id].Description}'");
            Console.ForegroundColor = ConsoleColor.White;
            Todos.Remove(id);
        }

        public static void EditTodo(int id, string newTodo)
        {
            Console.WriteLine($"\nSikeresen megváltoztattad a régi teendőt('{Todos[id].Description}') erre: '{newTodo}'");
            Todos[id].Description = newTodo;
        }
    }
}
