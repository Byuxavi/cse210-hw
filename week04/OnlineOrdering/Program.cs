using System;

class Program
{
    static void Main(string[] args)
    {
        // Order 1 - USA Customer
        Address address1 = new Address("123 Main St", "Miami", "FL", "USA");
        Customer customer1 = new Customer("John Smith", address1);

        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Soccer Ball", "A101", 25.99, 2));
        order1.AddProduct(new Product("Water Bottle", "B205", 9.50, 1));

        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order1.GetTotalCost():F2}");
        Console.WriteLine(new string('-', 40));

        // Order 2 - International Customer
        Address address2 = new Address("456 Elm St", "Toronto", "ON", "Canada");
        Customer customer2 = new Customer("Maria Lopez", address2);

        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Tennis Racket", "C308", 89.99, 1));
        order2.AddProduct(new Product("Wristband", "D412", 4.75, 3));

        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order2.GetTotalCost():F2}");
    }
}
