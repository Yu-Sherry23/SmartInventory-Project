using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInventory.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        //自動計算總和，移除set 外部不能修改
        //public decimal TotalValue=>Quantity* Price;
        public decimal TotalValue
        {
            get { return Quantity * Price; }
        }
        public override string ToString()
        {
            return $"ID:{Id} Category:{Category} Name:{Name} Price:{Price} Quantity:{Quantity} TotalValue:{TotalValue}";
        }


    }
}
