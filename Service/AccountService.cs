using System;
using Examen.Model;

namespace Examen.Service;

public class AccountService
{
    public List<BankAccount> Accounts {get; set;} = new List<BankAccount>();

    public bool CreateAccount(List<BankAccount> accounts, int tipo,int id, string ownerName, decimal balance)
    {
        if (accounts.Any(a => a.Id == id))
        {
            throw new ArgumentException("id already exists.");
        }

        switch (tipo)
        {
            case 1:
            {
                var account = new SavingsAccount(id, ownerName, balance);
                accounts.Add(account);
                return true;
            }
            case 2:
            {
                var account = new CheckingAccount(id, ownerName, balance);
                accounts.Add(account);
                return true;
            }
            default:
                throw new InvalidOperationException("Invalid account type.");
        }
    }

    public bool Deposit(List<BankAccount> accounts, int id, decimal amount)
    {
        if(amount <= 0)
        {
            throw new ArgumentException("Deposit amount must greater than zero.");
        }

        var account = accounts.FirstOrDefault(a => a.Id == id);

        if (account != null)
        {
            account.Deposit(amount);
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool WithDraw(List<BankAccount> accounts, int id, decimal amount)
    {
        if(amount <= 0)
        {
            throw new ArgumentException("Withdraw amount must greater than zero.");
        }

        var account = accounts.FirstOrDefault(a => a.Id == id);

        if (account != null)
        {
            account.WithDraw(amount);
            return true;
        }else
        {
            return false;
        }
    }

    public BankAccount? SearchAccount(List<BankAccount> accounts, int id)
    {
        var account = accounts.FirstOrDefault(a => a.Id == id);
        return account;
    }
}