using System;

class PatientRegistration
{
    public void RegisterPatient()
    {
        Console.WriteLine("Patient Registered Successfully");
    }
}

class DoctorConsultation
{
    public void ConsultDoctor()
    {
        Console.WriteLine("Doctor Consultation Completed");
    }
}

class CreditCardPayment
{
    public void MakePayment(double amount)
    {
        Console.WriteLine("Payment of Rs." + amount + " paid using Credit Card");
    }
}

class WhatsAppNotification
{
    public void SendMessage()
    {
        Console.WriteLine("WhatsApp Notification Sent");
    }
}

class MedicalReportService
{
    public void GenerateReport()
    {
        Console.WriteLine("Medical Report Generated");
    }
}

class c1
{
    static void MainDisabled()
    {
        PatientRegistration p = new PatientRegistration();
        DoctorConsultation d = new DoctorConsultation();
        CreditCardPayment c = new CreditCardPayment();
        WhatsAppNotification w = new WhatsAppNotification();
        MedicalReportService m = new MedicalReportService();

        p.RegisterPatient();
        d.ConsultDoctor();
        c.MakePayment(1000);
        w.SendMessage();
        m.GenerateReport();
    }
}