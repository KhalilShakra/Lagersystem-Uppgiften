using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<Product> products = new List<Product>
        {
            new Product("T-shirt", 199m, 12),
            new Product("Mug", 89m, 3),
            new Product("Notebook", 49m, 4)
        };

        products[0].SellProduct(2);
        products[1].AddStock(1);
        products[2].GiveDiscount(20);

        PrintProducts(products);
        Console.WriteLine($"Total stock value: {TotalValue(products)} kr");
    }

    static void PrintProducts(List<Product> products)
    {
        foreach (Product product in products)
        {
            Console.WriteLine($"{product.Name} | {product.Price} kr | stock: {product.Stock}");

            if (product.Stock < 5)
                Console.WriteLine("Low stock!");
        }
    }

    static decimal TotalValue(List<Product> products)
    {
        decimal total = 0;

        foreach (Product product in products)
            total += product.Price * product.Stock;

        return total;
    }
}