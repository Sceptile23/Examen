using System;

namespace Examen.Model;

public interface ITransaction
{
    public void Deposit(decimal amount);
    public void WithDraw(decimal amount);
}