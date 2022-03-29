using System;
using System.Collections.Generic;
using System.Text;

namespace Entities {
    class Product {
        public string name { get; set; }
        public double price { get; set; }
        public int quantity { get; set; }

        public Product() {
            this.name = null;
            this.price = 0.0;
            this.quantity = 0;
        }

        public Product(string name, double price, int quantity) {
            this.name = name;
            this.price = price;
            this.quantity = quantity;
        }

        public double totalValue() {
            return this.price * this.quantity;
        }

        public override string ToString() {

            StringBuilder s1 = new StringBuilder();
            s1.Append(this.name);
            s1.Append(",");
            s1.Append(this.price);
            s1.Append(",");
            s1.Append(this.quantity);
            s1.Append(",");            
            return s1.ToString();
        }
    }
}