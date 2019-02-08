using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone.Classes
{
    public class VendingMachine
    {
        private List<VendingMachineItem> items = new List<VendingMachineItem>();
        private string filePath = @"C:\VendingMachine\vendingmachine.csv";
        public decimal Balance { get; private set; }

        public bool ReadFile()
        {
            bool result = false;
            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    items.Clear();
                    while (!sr.EndOfStream)
                    {
                        string itemLine = sr.ReadLine();
                        string[] itemArray = itemLine.Split('|');
                        VendingMachineItem item = new VendingMachineItem();
                        item.Slot = itemArray[0];
                        item.ProductName = itemArray[1];
                        item.Price = decimal.Parse(itemArray[2]);    //TODO, add a tryparse
                        item.Quantity = 5;
                        items.Add(item);
                    }

                }
                result = true;
            }
            catch//TODO add proper catch later
            {
                result = false;
            }
            //catch (DirectoryNotFoundException)
            //{
            //    result = false;
            //}
            return result;
        }

        public VendingMachineItem[] ToArray()
        {
            VendingMachineItem[] displayItems = items.ToArray();
            return displayItems;
        }

        public decimal AddToBalance(decimal money)
        {
            Balance += money;
            return Balance;
        }

        public string DispenseItem(VendingMachineItem item) //TODO FINISH ME!
        {
            string result = "";
            if (CheckBalance(item))
            {
                result = "Insufficient funds.";
            }
            if (item.Quantity == 0)
            {
                result = "Sold Out.";
            }
            else
            {
                Balance -= item.Price;
                result = DispenseMessage(item);
                item.Quantity--;
            }

            return result;

            //go back to purchase menu
        }
        public string DispenseMessage(VendingMachineItem item)  //todo linebreak after dispensing
        {
            string result = "";
            if (item.Slot.Contains('A'))
            {
                result = "Crunch Crunch, Yum!";
            }
            else if (item.Slot.Contains('B'))
            {
                result = "Munch Munch, Yum!";
            }
            else if (item.Slot.Contains('C'))
            {
                result = "Glug Glug, Yum!";
            }
            else if (item.Slot.Contains('D'))
            {
                result = "Chew Chew, Yum!";
            }
            else
            {
                result = "The machine dispenses your item.";
            }
            return result;
        }

        public bool CheckBalance(VendingMachineItem item)
        {
            bool result = false;
            if (Balance >= item.Price)
            {
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }
        public int[] MakeChange(decimal Balance)
        {
            int quarter = 0;
            int dime = 0;
            int nickel = 0;
            int[] change = { quarter, dime, nickel };
            while (Balance != 0)
            {
                if (Balance >= 0.25M)
                {
                    Balance -= 0.25M;
                    quarter++;
                }
                else if (Balance >= 0.1M)
                {
                    Balance -= 0.1M;
                    dime++;
                }
                else if (Balance >= 0.05M)
                {
                    Balance -= 0.05M;
                    nickel++;
                }
            }
            change[0] = quarter;
            change[1] = dime;
            change[2] = nickel;
            this.Balance = Balance;
            return change;
        }

    }
}