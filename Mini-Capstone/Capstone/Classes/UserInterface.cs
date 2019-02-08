using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class UserInterface
    {
        private VendingMachine vendingMachine = new VendingMachine();
        private VendingMachineItem items = new VendingMachineItem();

        public void RunInterface()
        {
            vendingMachine.ReadFile();
            bool done = false;
            while (!done)
            {
                Console.WriteLine("(1) Display Vending Machine Items");
                Console.WriteLine("(2) Purchase");
                Console.WriteLine("(3) End");
                int choice = 0;
                try
                {
                    choice = Int32.Parse(Console.ReadLine());
                }
                catch
                {
                    choice = 0;
                }

                switch (choice)
                {
                    case 1:
                        DisplayVendingMachineItems();
                        break;

                    case 2:
                        PurchaseMenu();
                        break;

                    case 3:
                        SalesReport();
                        done = true;
                        break;

                    case 9:
                        SalesReport();
                        break;
                }

            }
        }

        private void PurchaseMenu()
        {
            bool done = false;
            while (!done)
            {
                Console.Clear();
                Console.WriteLine("(1) Feed Money");
                Console.WriteLine("(2) Select Product");
                Console.WriteLine("(3) Finish Transaction");
                Console.WriteLine($"Current Balance: {vendingMachine.Balance:C}");
                int choice = 0;
                try
                {
                    choice = Int32.Parse(Console.ReadLine());
                }
                catch
                {
                    choice = 0;
                }

                switch (choice)
                {
                    case 1:
                        FeedMoney();
                        break;

                    case 2:
                        SelectProduct();
                        break;

                    case 3:
                        FinishTransaction();
                        done = true;
                        break;
                }

            }

        }

        private void DisplayVendingMachineItems()
        {
            Console.Clear();
            Console.WriteLine("Slot".PadRight(5) + "Product Name".PadRight(20) + "# Remaining".PadRight(14) + "Price");
            Console.WriteLine("=============================================");
            VendingMachineItem[] result = vendingMachine.ToArray();
            foreach (VendingMachineItem item in result)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine();
            Console.WriteLine($"Current Balance: {vendingMachine.Balance:C}");
            Console.WriteLine();
        }

        private void FeedMoney()
        {
            Console.WriteLine("How much money would you like to enter (in dollar bills up to 10$)?");
            try
            {
                int deposit = int.Parse(Console.ReadLine());
                if (deposit == 1 || deposit == 2 || deposit == 5 || deposit == 10)
                {
                    vendingMachine.AddToBalance(deposit);
                }
                else
                {
                    Console.WriteLine("Invalid amount, please enter a valid amount.\n");
                }
            }
            catch
            {

            }

        }

        private void SelectProduct()
        {
            Console.Clear();
            DisplayVendingMachineItems();
            Console.WriteLine("Please make selection.");
            string selection = Console.ReadLine().ToUpper();
            vendingMachine.SlotSelection = selection;
            string result = "";
            if (vendingMachine.IsSlotSelectionValid())
            {
                VendingMachineItem[] inventory = GetInventory();
                foreach (VendingMachineItem item in inventory)
                {
                    if (item.Slot == selection)
                    {
                        result = vendingMachine.DispenseItem(item);
                    }
                }
            }
            else
            {
                result = "Invalid selection entered.";
            }
            Console.WriteLine(result);
            Console.ReadLine();
        }

        //private void SelectProduct()
        //{  


        //    VendingMachineItem[] result = GetInventory(); //Gets current working inventory to operate on
        //    foreach (VendingMachineItem item in result)
        //    {
        //        if (item.Slot == userInput)
        //        {
        //            resultString = vendingMachine.DispenseItem(item);
        //        }
        //        else
        //        {
        //            resultString = "Slot number not found, please try again.";
        //        }
        //    }
        //    Console.WriteLine(resultString);
        //}

        private void FinishTransaction()
        {
            string result = $"Your change is {vendingMachine.Balance:C}: ";
            int[] change = vendingMachine.MakeChange(vendingMachine.Balance);
            if (change[0] > 0 || change[1] > 0 || change[2] > 0)
            {
                if (change[0] != 0)
                {
                    result += $"{change[0]} quarters ";
                }
                if (change[1] != 0)
                {
                    result += $"{change[1]} dimes ";
                }
                if (change[2] != 0)
                {
                    result += $"{change[2]} nickels";
                }
            }
            else
            {
                result = "Transaction Complete.";
            }
            Console.WriteLine(result);
            Console.WriteLine();
        }

        private void SalesReport()
        {

        }

        private VendingMachineItem[] GetInventory()
        {
            VendingMachineItem[] result;
            result = vendingMachine.ToArray();
            return result;
        }
    }
}