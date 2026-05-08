using System;

namespace Examen.Model;

public class SavingsAccount : BankAccount, ITransaction
{
    //CONSTRUCTOR 
    public SavingsAccount(int id, string ownerName, decimal balance) : base(id, ownerName, balance)
    {
        this.Id = id;
        this.OwnerName = ownerName;
        this.Balance = balance;
    }

    public override void Deposit(decimal amount)
    {
        base.Deposit(amount);
    }

    public override void WithDraw(decimal amount)
    {
        //1 RULE IS THE USER NO CAN WITDRAH MORE OF THE BALANCE
        if(this.Balance < amount)
        {
            throw new InvalidOperationException("Insufficient funds.");
        }
        this.Balance -= amount;
    }
}