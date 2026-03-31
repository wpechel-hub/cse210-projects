using System;

namespace OnlineOrdering
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Address address1 = new Address("1023 Main St", "Murray", "UT", "USA");
            Customer customer1 = new Customer("John Smith", address1);
            Order order1 = new Order(customer1);
            order1.AddProduct(new Product("Laptop", "L001", 1200.00m, 1));
            order1.AddProduct(new Product("Mouse", "M002", 25.00m, 2));

            
            Address address2 = new Address("Avenida Brasil,56", "Curitiba", "PR", "BRAZIL");
            Customer customer2 = new Customer("Carlos Silva", address2);
            Order order2 = new Order(customer2);
            order2.AddProduct(new Product("Keyboard", "K003", 75.00m, 12));
            order2.AddProduct(new Product("Monitor", "MON04", 300.00m, 1));


            Address address3 = new Address("2014 North Street", "Newcastle", "KZN", "SOUTH AFRICA");
            Customer customer3 = new Customer("Nkazimulo Nkosi", address3);
            Order order3 = new Order(customer3);
            order3.AddProduct(new Product("Headset Gamer", "H005", 150.00m, 6));
            order3.AddProduct(new Product("Webcam 4K", "W006", 1200.00m, 3));
            order3.AddProduct(new Product("USB Hub", "U007", 15.00m, 3));

            Console.WriteLine("===================================================");
            Console.WriteLine(order1.GetPackingLabel());
            Console.WriteLine(order1.GetShippingLabel());
            Console.WriteLine($"Total Price: ${order1.CalculateTotalCost():F2}\n");
            Console.WriteLine("===================================================");
            
            Console.WriteLine(order2.GetPackingLabel());
            Console.WriteLine(order2.GetShippingLabel());
            Console.WriteLine($"Total Price: ${order2.CalculateTotalCost():F2}");
            Console.WriteLine("===================================================");
            

            
            Console.WriteLine(order3.GetPackingLabel());
            Console.WriteLine(order3.GetShippingLabel());
            Console.WriteLine($"Total Price: ${order3.CalculateTotalCost():F2}");
            Console.WriteLine("===================================================");
        }
    }
}
