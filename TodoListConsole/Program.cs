using System.Diagnostics;

namespace TodoListConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("\nType add, show, edit, complete, clear or exit: ");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "add":
                        Console.Write("\nMilyen teendőt akarsz hozzáadni?: ");
                        Todo userTodo = new Todo(Console.ReadLine());
                        continue;
                    case "show":
                        try
                        {
                            TodoList.ShowTodos();
                        } catch(Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            Debug.WriteLine($"A lista beolvasásakor nem talált létező elemet:" + ex.StackTrace);
                        }
                        continue;
                    case "edit":
                        try
                        {
                            TodoList.ShowTodos();
                            bool isNum = false;
                            int num = 0;
                            while (!isNum)
                            {
                                Console.Write("\nMelyiket szeretnéd módosítani?: ");
                                isNum = int.TryParse(Console.ReadLine(), out num);
                            }
                            Console.Write("Mi legyen az új tartalma?: ");
                            string newTodo = Console.ReadLine();
                            TodoList.EditTodo(num, newTodo);
                        }
                        catch (KeyNotFoundException ex)
                        {
                            Console.WriteLine("Nincs ilyen számú teendő.");
                            Debug.WriteLine("A felhasználó olyan indexet írt be amit nem létezik a listába: " + ex.StackTrace);
                        } catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            Debug.WriteLine("A lista beolvasásakor nem talált létező elemet:" + ex.StackTrace);
                        }
                        continue;
                    case "complete":
                        try
                        {
                            TodoList.ShowTodos();
                            bool isNum = false;
                            int num = 0;
                            while (!isNum)
                            {
                                Console.Write("\nMelyiket szeretnéd befejezni?: ");
                                isNum = int.TryParse(Console.ReadLine(), out num);
                            }
                            TodoList.CompleteTodo(num);
                        } catch (KeyNotFoundException ex)
                        {
                            Console.WriteLine("Nincs ilyen számú teendő.");
                            Debug.WriteLine("A felhasználó olyan indexet írt be amit nem létezik a listába: " + ex.StackTrace);
                        } catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            Debug.WriteLine("A lista beolvasásakor nem talált létező elemet:" + ex.StackTrace);
                        }
                        continue;
                    case "clear":
                        Console.Clear();
                        continue;
                    case "exit":
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Nem adtál meg semmit vagy rosszat adtál meg!");
                        continue;
                }
            }
            Console.ReadKey();
        }
    }
}
