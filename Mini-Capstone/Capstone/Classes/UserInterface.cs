using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class UserInterface
    {
        private VendingMachine vendingMachine = new VendingMachine();

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

                Console.ReadLine();
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

                Console.ReadLine();


            }

        }
        

        private void DisplayVendingMachineItems()
        {

        }

        private void SalesReport()
        {

        }

        private void FeedMoney()
        {

        }

        private void SelectProduct()
        {

        }
        
        private void FinishTransaction()
        {

        }
    }
}