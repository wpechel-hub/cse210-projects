using System.Collections.Generic;
using System.Text;

namespace OnlineOrdering
{
    public class Order
    {
        private List<Product> _products;
        private Customer _customer;

        public Order(Customer customer)
        {
            _customer = customer;
            _products = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            _products.Add(product);
        }

        public decimal CalculateTotalCost()
        {
            decimal total = 0;
            foreach (var product in _products)
            {
                total += product.GetTotalCost();
            }

        
            decimal shippingCost = _customer.IsInUSA() ? 5.00m : 35.00m;
            
            return total + shippingCost;
        }

        public string GetPackingLabel()
        {
            StringBuilder label = new StringBuilder();
            label.AppendLine("--- Packing Label ---");
            foreach (var product in _products)
            {
                label.AppendLine($"Product: {product.GetName()} (ID: {product.GetProductId()})");
            }
            return label.ToString();
        }

        public string GetShippingLabel()
        {
            StringBuilder label = new StringBuilder();
            label.AppendLine("--- Shipping Label ---");
            label.AppendLine(_customer.GetName());
            label.AppendLine(_customer.GetAddress().GetFullAddressString());
            return label.ToString();
        }
    }
}
