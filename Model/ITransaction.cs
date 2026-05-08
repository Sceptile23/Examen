using System;

namespace Examen.Model;

public interface ITransaction
{
    public bool Deposit(List<BankAccount> accounts, int id, decimal amount);
    public bool WithDraw(List<BankAccount> accounts, int id, decimal amount);
}