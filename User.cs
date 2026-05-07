using System;
using System.ComponentModel.DataAnnotations;

namespace Examen;

public class User
{
    //PROPIEDADES
    //[Required (ErrorMessage = "Se necesita que se agregue el nombre.")]
    public string Name {get; set;} = string.Empty;
    public int Age {get; set;}

    //CONSTRUCTOR
    public User (string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }
}

public class UserService
{
    public void RegisterUser(List<User> users, string name, int age)
    {
        var user = new User(name, age);
        if (!users.Any(u => u.Name == user.Name))
        {
            users.Add(user);
            Console.WriteLine("Added user");
        }
        else
        {
            Console.WriteLine("The usser exists.");
        }
    }

    public void SearchUser(List<User> users, string name)
    {
        if (users.Any())
        {
            var user = users.FirstOrDefault(u => u.Name == name);

            if(user != null)
            {
                Console.WriteLine($"Name: {user.Name}, Age: {user.Age}.");
            }
            else
            {
                Console.WriteLine("the user exists.");
            }
        }
        else
        {
            Console.WriteLine("Data found");
        }
    }

    public void UpdateUser(List<User> users, string name)
    {
        var user = users.FirstOrDefault(u => u.Name == name);

        if(user != null)
        {
            Console.WriteLine("Write the age of the user: ");
            string temp = Console.ReadLine() ?? " ";
            
            if(int.TryParse(temp, out int tempAge))
            {
                if(tempAge <= 0)
                {
                    Console.WriteLine("Invalid age.");
                }
                else
                {
                    user.Age = tempAge;
                    Console.WriteLine("updated age.");
                }
            }
            else
            {
                Console.WriteLine("user not found");
            }
        }
    }

    public void DeletedUser(List<User> users, string name)
    {
        var user = users.FirstOrDefault(u => u.Name == name);

        if(user != null)
        {
            users.Remove(user);
            Console.WriteLine("Deleted user.");
        }
        else
        {
            Console.WriteLine("User not found.");
        }
    }
}