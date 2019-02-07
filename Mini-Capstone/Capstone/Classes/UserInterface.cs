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
                        vendingMachine.ReadFile();
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
            VendingMachineItem[] result = vendingMachine.ToArray();
            //Console.Clear();
            foreach (VendingMachineItem item in result)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine();
            
        }

        private void FeedMoney()
        {
            Console.WriteLine("How much money would you like to enter (in dollar bills up to 10$)?");
            try
            {
                int deposit = int.Parse(Console.ReadLine());
                if(deposit == 1 || deposit == 2|| deposit == 5 || deposit == 10)
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
            //DispenseItem();
        }
        
        private void FinishTransaction()
        {
            //MakeChange;
        }

        private void SalesReport()
        {

        }
    }
}