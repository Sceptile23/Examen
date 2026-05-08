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

    public override bool Deposit(List<BankAccount> accounts, int id, decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Deposit amount must greater than zero.");
        }

        return base.Deposit(accounts, id, amount);
    }

    public override bool WithDraw(List<BankAccount> accounts, int id, decimal amount)
    {
        if(amount <= 0)
        {
            throw new ArgumentException("Withdrwal amount must greater than zero.");
        }
        return base.WithDraw(accounts, id, amount);
    }
}