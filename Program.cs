using System;
using System.Diagnostics;
using System.Transactions;
using Examen.Model;
using Examen.Service;

namespace Examen;

public class Program
{
/*  1. Create account
2. Deposit
3. Withdraw
4. Search account
5. Show accounts
6. Rich accounts
7. Total money in bank
8. Exit */

    enum Menu
    {
        CreateAccount = 1,
        Deposit = 2,
        Withdraw =3,
        SearchAccount = 4,
        ShowAccounts = 5, 
        RichAccounts =  6,
        TotalMoney = 7,
        Exit = 8
    }

    public static void Main (string[] args)
    {
        int choice;

        //VARIABLES PARA CREAR UNA CUENTA
        string ownerName;
        decimal balance;
        int id, typeAccount;
        List<BankAccount> accounts = new List<BankAccount>();

        //INSTANCIAR EL SERVICIO DE LAS CUENTAS
        AccountService service = new AccountService();

        do
        {
            Console.WriteLine("Menu: 1. Create account, 2. Deposit, 3. Withdraw, 4. Search account, 5. Show accounts, 6. Rich accounts, 7. Total money in the bank, 8. Exit");
            Console.WriteLine("Write your choice: ");
            string input = Console.ReadLine() ?? string.Empty;

            if(!int.TryParse(input, out choice))
            {
                Console.WriteLine("Invalid input, Please enter a number.");
                continue;
            }
            else
            {
                switch((Menu)choice){
                    case Menu.CreateAccount:
                    Console.WriteLine("Enter account type (1. SavingsAccount, 2. CheckingAccount):");
                    int.TryParse(Console.ReadLine(), out typeAccount);

                    Console.WriteLine("Enter account ID: ");
                    int.TryParse(Console.ReadLine(), out id);
                    Console.WriteLine("Enter owner name: ");
                    ownerName = Console.ReadLine() ?? string.Empty;
                    Console.WriteLine("Enter initial balance: ");
                    decimal.TryParse(Console.ReadLine(), out balance);

                        try
                        {
                            var creation = service.CreateAccount(accounts, typeAccount, id, ownerName, balance);
                            string message = creation ? "Account created succesfully." : "Failed to create account.";
                            Console.WriteLine(message);
                        }catch(ArgumentException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        catch (InvalidOperationException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    break;
                    
                    case Menu.Deposit:
                        Console.WriteLine("Enter account ID: ");
                        int.TryParse(Console.ReadLine(), out id);

                        Console.WriteLine("Enter deposit amount: ");
                        decimal.TryParse(Console.ReadLine(), out decimal amount);

                        try
                        {
                            var deposit = service.Deposit(accounts, id, amount);
                            string message = deposit ? "Deposit successfuly." : "Failed to deposit.";
                            Console.WriteLine(message);
                        }
                        catch(ArgumentException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        catch (InvalidOperationException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    break;

                    case Menu.Withdraw:
                        Console.WriteLine("Enter account ID: ");
                        int.TryParse(Console.ReadLine(), out id);

                        Console.WriteLine("Enter withdrawal amount: ");
                        decimal.TryParse(Console.ReadLine(), out amount);

                        try
                        {
                            var withdraw = service.WithDraw(accounts, id, amount);
                            string message = withdraw ? "withdraw successfuly" :"failed to withdraw." ;
                            Console.WriteLine(message);
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }catch(InvalidOperationException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    break;
                    
                    case Menu.SearchAccount:
                        Console.WriteLine("Enter account ID: ");
                        int.TryParse(Console.ReadLine(), out id);

                        var account = service.SearchAccount(accounts, id);

                        if(account != null)
                        {
                            Console.WriteLine(account.ShowInformation());
                        }
                        else
                        {
                            Console.WriteLine("Account not found.");
                        }
                    break;

                    case Menu.ShowAccounts:
                        if (accounts.Any())
                        {
                            foreach (var accountTemp in accounts)
                            {
                                Console.WriteLine(accountTemp.ShowInformation());
                            }
                        }
                        else
                        {
                            Console.WriteLine("No accounts found.");
                        }
                    break;

                    case Menu.TotalMoney:
                        decimal totalMoney = accounts.Sum(a => a.Balance);
                        Console.WriteLine($"Total money in the bank: {totalMoney}");
                    break;

                    case Menu.Exit:
                        Console.WriteLine("Leaving the program, Goodbye!");
                    break;

                    default:
                        Console.WriteLine("Invalid choice, Please select a valid option.");
                    break;
                }
            }
        }while(choice != (int) Menu.Exit);
    }
}