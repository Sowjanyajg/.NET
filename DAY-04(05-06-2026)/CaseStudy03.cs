using System;

// Notification Interface
interface INotification
{
    void SendMessage();
}

// WhatsApp Notification
class WhatsAppNotificatio : INotification
{
    public void SendMessage()
    {
        Console.WriteLine("WhatsApp Notification Sent");
    }
}

// Dependency Injection
class NotificationService
{
    private INotification notification;

    public NotificationService(INotification notification)
    {
        this.notification = notification;
    }

    public void Notify()
    {
        notification.SendMessage();
    }
}

// Ride Interface
interface IRide
{
    void CalculateFare();
}

// Bike Ride
class BikeRide : IRide
{
    public void CalculateFare()
    {
        Console.WriteLine("Bike Ride Fare = Rs.50");
    }
}

// Auto Ride
class AutoRide : IRide
{
    public void CalculateFare()
    {
        Console.WriteLine("Auto Ride Fare = Rs.100");
    }
}

// Luxury Ride
class LuxuryRide : IRide
{
    public void CalculateFare()
    {
        Console.WriteLine("Luxury Ride Fare = Rs.500");
    }
}

class uberOla
{
    static void Main()
    {
        BikeRide bike = new BikeRide();
        AutoRide autoRide = new AutoRide();
        LuxuryRide luxury = new LuxuryRide();

        bike.CalculateFare();
        autoRide.CalculateFare();
        luxury.CalculateFare();

        NotificationService service =
            new NotificationService(new WhatsAppNotificatio());

        service.Notify();
    }
}