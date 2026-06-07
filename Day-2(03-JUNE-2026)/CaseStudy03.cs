using System;

// Abstract Class
abstract class Product
{
    public int ProductId;
    public string ProductName;
    protected double Price;

    public Product(int id, string name, double price)
    {
        ProductId = id;
        ProductName = name;
        Price = price;
    }

    public void DisplayProduct()
    {
        Console.WriteLine(ProductName);
        Console.WriteLine("Original Price : " + Price);
    }

    public abstract void CalculateDiscount();
}


class Electronics : Product
{
    public Electronics(int id, string name, double price)
        : base(id, name, price)
    {
    }

    public override void CalculateDiscount()
    {
        double finalPrice = Price - (Price * 10 / 100);

        Console.WriteLine("Discount : 10%");
        Console.WriteLine("Final Price : " + finalPrice);
    }
}


class Clothing : Product
{
    public Clothing(int id, string name, double price)
        : base(id, name, price)
    {
    }

    public override void CalculateDiscount()
    {
        double finalPrice = Price - (Price * 20 / 100);

        Console.WriteLine("Discount : 20%");
        Console.WriteLine("Final Price : " + finalPrice);
    }
}

class Grocery : Product
{
    public Grocery(int id, string name, double price)
        : base(id, name, price)
    {
    }

    public override void CalculateDiscount()
    {
        double finalPrice = Price - (Price * 5 / 100);

        Console.WriteLine("Discount : 5%");
        Console.WriteLine("Final Price : " + finalPrice);
    }
}

class case3
{
    static void MainDisabled()
    {
        Product p1 = new Electronics(1, "Laptop", 50000);
        Product p2 = new Clothing(2, "T-Shirt", 1000);

        p1.DisplayProduct();
        p1.CalculateDiscount();

        Console.WriteLine();

        p2.DisplayProduct();
        p2.CalculateDiscount();
    }
}