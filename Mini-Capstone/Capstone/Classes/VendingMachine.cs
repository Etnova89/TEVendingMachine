﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone.Classes
{
    public class VendingMachine
    {
        private List<VendingMachineItem> items = new List<VendingMachineItem>();

        private string filePath = @"C:\VendingMachine\vendingmachine.csv";

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
                        item.Price = decimal.Parse(itemArray[2]);               //TODO, add a tryparse
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

        public decimal Balance { get; private set; }

        public  decimal AddToBalance(decimal money)
        {
            Balance += money;
            return Balance;
        }
    }
}