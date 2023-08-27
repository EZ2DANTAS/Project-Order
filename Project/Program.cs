using Project.Entities;
using Project.Entities.Enums;
using System;
using System.Globalization;
using System.Transactions;
using System.Xml;

namespace Project
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Client data");

            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Email: ");
            string email = Console.ReadLine();

            Console.Write("Birth Date: DD/MM/YYYY:  ");
            DateTime birthdate = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter Order data:");
            Console.Write("Status: ");
            DateTime now = DateTime.Now;
            string orderData = Console.ReadLine();
            OrderStatus status = Enum.Parse<OrderStatus>(orderData);

            Client client = new Client(name, email, birthdate);
            Order order = new Order(now,status,client);
            Console.Write("How many items to this order:");
            int qtd = int.Parse(Console.ReadLine());

            for (int i = 0; i < qtd; i++)
            {
                Console.WriteLine($"Enter #{i+1} item data: ");
                Console.Write("Product name: ");
                string nameProduct = Console.ReadLine();
                Console.Write("Product price: ");
                double priceProduct = double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);
                Console.Write("Quantity: ");
                int quantityProduct = int.Parse(Console.ReadLine());
                Product prod = new Product(nameProduct, priceProduct);
                OrderItem orderItem = new OrderItem(quantityProduct,priceProduct,prod);

                order.AddItem(orderItem);
            }

            Console.WriteLine(order);
        }
    }
}