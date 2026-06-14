using System;
using System.Collections.Generic;

// Abstract Base Class
abstract class Person
{
    public int Id;
    public string Name;

    public Person(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public void GetDetails()
    {
        Console.WriteLine("Id: " + Id);
        Console.WriteLine("Name: " + Name);
    }

    public abstract void PerformDuty();
}


class Doctor : Person
{
    public Doctor(int id, string name) : base(id, name)
    {
    }

    public override void PerformDuty()
    {
        Console.WriteLine("Doctor " + Name + " is treating patients.");
    }
}


class Nurse : Person
{
    public Nurse(int id, string name) : base(id, name)
    {
    }

    public override void PerformDuty()
    {
        Console.WriteLine("Nurse " + Name + " is assisting doctors.");
    }
}

class Patient : Person
{
    public Patient(int id, string name) : base(id, name)
    {
    }

    public override void PerformDuty()
    {
        Console.WriteLine("Patient " + Name + " is receiving treatment.");
    }
}

class Program
{
    static void MainDisabled()
    {
        List<Person> people = new List<Person>();

        people.Add(new Doctor(1, "Krishna"));
        people.Add(new Nurse(2, "Ravi"));
        people.Add(new Patient(3, "Anu"));

        foreach (Person p in people)
        {
            p.GetDetails();
            p.PerformDuty();
            Console.WriteLine();
        }
    }
}