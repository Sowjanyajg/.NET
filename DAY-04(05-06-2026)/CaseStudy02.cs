using System;


interface IReader
{
    void ReadBook();
}


interface ILibrarian
{
    void IssueBook();
    void ReturnBook();
}

class FacultyMembership
{
    public void MembershipDetails()
    {
        Console.WriteLine("Faculty Membership Activated");
    }
}


class EmailAlert
{
    public void SendEmail()
    {
        Console.WriteLine("Email Alert Sent");
    }
}


class SMSAlert
{
    public void SendSMS()
    {
        Console.WriteLine("SMS Alert Sent");
    }
}


class Library : IReader, ILibrarian
{
    public void ReadBook()
    {
        Console.WriteLine("Reader is Reading a Book");
    }

    public void IssueBook()
    {
        Console.WriteLine("Book Issued");
    }

    public void ReturnBook()
    {
        Console.WriteLine("Book Returned");
    }

    public void CalculateFine()
    {
        Console.WriteLine("Fine Calculated: Rs.50");
    }
}

class uber
{
    static void MainDisabled()
    {
        Library l = new Library();
        FacultyMembership f = new FacultyMembership();
        EmailAlert e = new EmailAlert();
        SMSAlert s = new SMSAlert();

        f.MembershipDetails();
        l.IssueBook();
        l.ReadBook();
        l.ReturnBook();
        l.CalculateFine();

        e.SendEmail();
        s.SendSMS();
    }
}