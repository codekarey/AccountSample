using System;
using System.Collections.Generic;
using System.Text;

namespace AccountSample
{
    class Store
    {
        public string Item { get; set; }
        public int Stock { get; set; }
        public string ClassId { get; set; }
        public double Price { get; set; }
        public bool Rented { get; set; }
        public DateTime Term{ get; set; }
        

        public Store()
        {
            ClassId = "No Id";
            Rented = false;
            Term = DateTime.Today;
        }

        public Store(string item, int stock, string classId, double price, bool rented, DateTime term)
        {
            Item = item;
            Stock = stock;
            ClassId = classId;
            Price = price;
            Rented = rented;
            Term = term;
        }

        public override string ToString()
        {
            return $"{Item}|{Stock}|{ClassId}|{Price}|{Rented}|{Term}|";
        }
    }
}
