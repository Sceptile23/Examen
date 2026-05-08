using System;
using System.ComponentModel.DataAnnotations;

namespace Examen.Model;

public class BankAccount : ITransaction
{
    [Key]
    public int Id {get; set;}
    [Required (ErrorMessage = "OwnerName is required.")]
    public string OwnerName {get; set;} = string.Empty;
    public decimal Balance {get; set;}

    public BankAccount(int id, string ownerName, decimal balance)
    {
        this.Id = id;
        this.OwnerName = ownerName;
        this.Balance = balance;
    }

    public virtual bool Deposit(List<BankAccount> accounts, int id, decimal amount)
    {
        var account = accounts.FirstOrDefault(a => a.Id == id);
        if (account != null)
        {
            account.Balance += amount;
            return true;
        }
        else
        {
            return false;
        }
    }

    public virtual bool WithDraw(List<BankAccount> accounts, int id, decimal amount)
    {
        var account = accounts.FirstOrDefault(a => a.Id == id);
        
        if (account != null)
        {
            if(account.Balance <= amount)
            {
                throw new InvalidOperationException("Insufficient founds.");
            }
            account.Balance -= amount;
            return true;
        }
        else
        {
            return false;
        }
    }

    public virtual BankAccount? ShowInformation(List<BankAccount> accounts, int id)
    {
        var account = accounts.FirstOrDefault(a => a.Id == id);
        return account;
    }
}