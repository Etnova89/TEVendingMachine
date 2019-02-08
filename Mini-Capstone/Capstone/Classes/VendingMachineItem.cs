using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class VendingMachineItem
    {
        public string Slot { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }


        public override string ToString()
        {
            return $"{Slot.PadRight(1)} - {ProductName.PadRight(20)} - {Quantity.ToString().PadRight(8)} - {Price:C} ";
        }
    }
}
