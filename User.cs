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
    public bool RegisterUser(List<User> users, string name, int age)
    {
        var user = new User(name, age);

        if (!users.Any(u => u.Name == user.Name))
        {
            users.Add(user);
            return true;
        }
        else
        {
            return false;
        }
    }

    public User? SearchUser(List<User> users, string name)
    {
        var user = users.FirstOrDefault(u => u.Name == name);
        return user;
    }

    public bool UpdateUser(List<User> users, string name)
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
                    return false;
                }
                else
                {
                    user.Age = tempAge;
                    return true;
                }
            }
            else
            {
                return false;
            }
        }else
        {
            return false;
        }
    }

    public bool DeletedUser(List<User> users, string name)
    {
        var user = users.FirstOrDefault(u => u.Name == name);

        if(user != null)
        {
            users.Remove(user);
            return true;
        }
        else
        {
            return false;
        }
    }
}