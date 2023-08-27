using Project.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entities
{
    internal class Order
    {
        public DateTime Moment { get; set; }
        public OrderStatus Status { get; set; }
        public Client Client { get; set; }

        public List<OrderItem> Items { get; set; } = new List<OrderItem>();



        public Order() { }
        public Order(DateTime moment, OrderStatus status,Client client) {
            Moment = moment;
            Status = status;
            Client = client;
        }

        public void AddItem(OrderItem item)
        {
            Items.Add(item);
        }

        public void RemoveItem(OrderItem item)
        {
            Items.Remove(item);
        }

        public double Total()
        {
            double sum = 0;

            foreach (OrderItem item in Items)
            {
                sum += item.SubTotal();
            }
            return sum;
        }

        public override string ToString()
        {
            StringBuilder stringB = new StringBuilder();
            stringB.AppendLine("Order Sumary");
            stringB.Append("Order moment: ");
            stringB.AppendLine(Moment.ToString("dd/MM/yyyy HH:mm:ss"));
            stringB.Append("Order status: ");
            stringB.AppendLine(Status.ToString(""));
            stringB.Append("Client: ");
            stringB.AppendLine("Name: " + Client.NameClient + " BirthDay: " + Client.BirthDate.ToString("dd/MM/yyyy") + " Email: " + Client.Email);
            stringB.AppendLine("Order Item: ");
            foreach (OrderItem i in Items)
            {
               stringB.AppendLine(i.Product.Name+ ", " + i.Price + ", Quantity: "+ i.Quantity + ", Subtotal: "+ i.SubTotal());
    
            }
            stringB.AppendLine("Total price: $" + Total().ToString("F2", CultureInfo.InvariantCulture));
            return stringB.ToString();
        }
    }
}
