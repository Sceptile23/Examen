using System;

namespace Examen.Model;

public class CheckingAccount : BankAccount, ITransaction
{
    //CONSTRUCTOR
    public CheckingAccount(int id, string ownerName, decimal balance) : base (id, ownerName, balance)
    {
        this.Id = id;
        this.OwnerName = ownerName;
        this.Balance = balance;
    }

    public override void Deposit(decimal amount)
    {
        base.Deposit(amount);
    }

    public override void WithDraw (decimal amount)
    {
        // 1. Rule is the user no can WithDraw more of -500
        if(this.Balance - amount < -500)
        {
            throw new InvalidOperationException("Overdraft limit exceeded.");
        }

        this.Balance -= amount;
    }
}