using System;
using System.Security.Cryptography;

namespace Examen;

public class Program
{
    enum Menu
    {
        Register = 1, 
        Search = 2, 
        Update = 3,
        Delete = 4,
        Exit = 5
    }
    public static void Main (string[] args)
    {
        int choise;
        List<User> users = new List<User>();
        UserService service = new UserService();

        do
        {
            Console.WriteLine("Write your choise: (1. Register user, 2. Search a user, 3 Update user, 4. Delete user, 5. Exit)");
            int.TryParse(Console.ReadLine(), out choise);

            switch ((Menu)choise)
            {
                case Menu.Register:
                    Console.WriteLine("Write your name: ");
                    string name = Console.ReadLine() ?? "";

                    if(string.IsNullOrWhiteSpace(name))
                    {
                        Console.WriteLine("Invalid user.");
                        continue;
                    }

                    Console.WriteLine("Write your age: ");
                    int.TryParse(Console.ReadLine(), out int age);

                    if (service.RegisterUser(users, name, age))
                    {
                        Console.WriteLine("Added user");
                    }
                    else
                    {
                        Console.WriteLine("The user exists.");
                    }
                    ;
                break;

                case Menu.Search:
                    Console.WriteLine("Write the user for search: ");
                    name = Console.ReadLine() ?? " ";
                    if(string.IsNullOrWhiteSpace(name))
                    {
                        Console.WriteLine("Invalid user.");
                        continue;
                    }

                    var user = service.SearchUser(users, name);

                    if (user != null)
                    {
                        Console.WriteLine($"Name: {user.Name}, Age: {user.Age}");
                    }
                    else
                    {
                        Console.WriteLine("User not found.");
                    }
                break;

                case Menu.Update:
                    Console.WriteLine("Write user to uptate age: ");
                    name = Console.ReadLine() ?? " ";

                    if(string.IsNullOrWhiteSpace(name))
                    {
                        Console.WriteLine("Don't write the user");
                        continue;
                    }

                    if(service.UpdateUser(users, name))
                    {
                        Console.WriteLine("updated age.");
                    }
                    else
                    {
                        Console.WriteLine("user not found or invalid age.");
                    }
                break;

                case Menu.Delete:
                    Console.WriteLine("Write user to delete in the database: ");
                    name = Console.ReadLine() ?? " ";

                    if (string.IsNullOrWhiteSpace(name))
                    {
                        Console.WriteLine("Don't write the user");
                        continue;
                    }

                    if (service.DeletedUser(users, name))
                    {
                        Console.WriteLine("Deleted user.");
                    }
                    else
                    {
                        Console.WriteLine("User not found.");
                    }
                break;

                case Menu.Exit:
                    Console.WriteLine("leaving of the system ...");
                break;

                default:
                    Console.WriteLine("Invalid data.");
                break;
            }
        }while (choise != (int) Menu.Exit);
    }
}