
using System;

public class Program
{
    public static void Main()
    {
        Account acc1 = new SavingsAccount(101, "Sowjanya", 5000);
        Account acc2 = new CurrentAccount(102, "Rahul", 3000);

        acc1.Deposit(1000);
        acc1.Withdraw(2000);
        acc1.CalculateInterest();
        acc1.DisplayDetails();

        Console.WriteLine("--------------------");

        acc2.Deposit(500);
        acc2.Withdraw(3500);
        acc2.CalculateInterest();
        acc2.DisplayDetails();
    }
}

public abstract class Account
{
   
    public int AccountNumber { get; set; }
    public string CustomerName { get; set; }
    private double balance;

   
    public double Balance
    {
        get { return balance; }
    }

    
    public Account(int accNo, string name, double initialBalance)
    {
        AccountNumber = accNo;
        CustomerName = name;
        balance = initialBalance;
    }

    
    public void Deposit(double amount)
    {
        if (amount > 0)
        {
            balance += amount;
            Console.WriteLine($"Deposited: {amount}");
        }
    }

   
    public virtual void Withdraw(double amount)
    {
        if (amount <= balance)
        {
            balance -= amount;
            Console.WriteLine($"Withdrawn: {amount}");
        }
        else
        {
            Console.WriteLine("Insufficient balance.");
        }
    }

  
    public virtual void DisplayDetails()
    {
        Console.WriteLine($"Account No: {AccountNumber}");
        Console.WriteLine($"Customer Name: {CustomerName}");
        Console.WriteLine($"Balance: {Balance}");
    }


    public abstract void CalculateInterest();
}
class SavingsAccount : Account
{
    private double interestRate = 0.05; 

    public SavingsAccount(int accNo, string name, double balance)
        : base(accNo, name, balance) { }

    
    public override void Withdraw(double amount)
    {
        if (amount <= Balance)
        {
            base.Withdraw(amount);
        }
        else
        {
            Console.WriteLine("Savings Account: Insufficient funds.");
        }
    }

 
    public override void CalculateInterest()
    {
        double interest = Balance * interestRate;
        Console.WriteLine($"Interest Earned: {interest}");
    }
}
class CurrentAccount : Account
{
    private double overdraftLimit = 1000;

    public CurrentAccount(int accNo, string name, double balance)
        : base(accNo, name, balance) { }

       public override void Withdraw(double amount)
    {
        if (amount <= Balance + overdraftLimit)
        {
            Console.WriteLine($"Withdrawn: {amount}");
        }
        else
        {
            Console.WriteLine("Overdraft limit exceeded.");
        }
    }

    // No interest for current account
    public override void CalculateInterest()
    {
        Console.WriteLine("No interest for Current Account.");
    }
}
