using System;

class Product
{
    private string name;
    private decimal price;
    private int stock;

    public Product(string name, decimal price, int stock)
    {
        Name = name;
        Price = price;

        if (stock < 0)
            throw new ArgumentException("Stock cannot be negative.");

        this.stock = stock;
    }

    public string Name
    {
        get { return name; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Name cannot be empty.");

            name = value.Trim();
        }
    }

    public decimal Price
    {
        get { return price; }
        set
        {
            if (value < 0)
                throw new ArgumentException("Price cannot be negative.");

            price = value;
        }
    }

    public int Stock
    {
        get { return stock; }
    }

    public void AddStock(int amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Amount must be greater than zero.");

        stock += amount;
    }

    public void SellProduct(int amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Amount must be greater than zero.");

        if (amount > stock)
            throw new InvalidOperationException("Cannot sell more than is in stock.");

        stock -= amount;
    }

    public void GiveDiscount(int percent)
    {
        if (percent < 0 || percent > 100)
            throw new ArgumentException("Discount must be between 0 and 100 percent.");

        decimal newPrice = price * (100 - percent) / 100;

        if (newPrice < 0)
            newPrice = 0;

        price = newPrice;
    }
}