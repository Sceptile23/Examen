using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime;

namespace Examen.Model;

public class BankAccount : ITransaction
{
    [Key]
    public int Id {get; set;}
    [Required (ErrorMessage = "OwnerName is required.")]
    public string OwnerName {get; set;} = string.Empty;
    public decimal Balance {get; set;} = 0m;

    public BankAccount(int id, string ownerName, decimal balance)
    {
        this.Id = id;
        this.OwnerName = ownerName;
        this.Balance = balance;
    }

    public virtual void Deposit(decimal amount)
    {
        this.Balance += amount;
    }

    public virtual void WithDraw(decimal amount)
    {
        this.Balance -= amount;
    }

    public virtual string ShowInformation()
    {
        return $"ID: {this.Id}, Owner name: {this.OwnerName}, Balance: {this.Balance}";
    }
}