using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Classes;
using System.Collections.Generic;

namespace CapstoneTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void VendingMachineCreateTest()
        {
            VendingMachine vm = new VendingMachine();
            Assert.IsNotNull(vm);
        }

        [TestMethod]
        public void VendingMachineCreateItemListTest()
        {
            List<VendingMachineItem> items = new List<VendingMachineItem>();
            Assert.IsNotNull(items);
        }

        [TestMethod]
        public void VendingMachineAddToItemListTest()
        {
            List<VendingMachineItem> items = new List<VendingMachineItem>();
            VendingMachineItem item = new VendingMachineItem()
            {
                Slot = "a1",
                ProductName = "item",
                Price = 1.10m,
            };
            items.Add(item);
            Assert.AreEqual(1, items.Count);
        }

        [TestMethod]
        public void AddPropertiesToItemTestReturnTest()
        {
            VendingMachineItem item = new VendingMachineItem();
            item.Slot = "A1";
            item.ProductName = "TestName";
            item.Price = 3.00M;
            Assert.AreEqual("A1", item.Slot);
        }

        [TestMethod]
        public void TakeArraySplitAndAddToPropertiesOfVendingMachineItemTest()
        {
            VendingMachineItem item = new VendingMachineItem();
            string itemLine = "A1|Potato Crisps|3.05";
            string[] itemArray = itemLine.Split('|');
            item.Slot = itemArray[0];
            item.ProductName = itemArray[1];
            item.Price = decimal.Parse(itemArray[2]);
            Assert.AreEqual("A1", item.Slot);
            Assert.AreEqual("Potato Crisps", item.ProductName);
            Assert.AreEqual(3.05M, item.Price);
        }

        [TestMethod]
        public void ListToArrayTest()
        {
            List<VendingMachineItem> items = new List<VendingMachineItem>();
            VendingMachineItem item = new VendingMachineItem()
            {
                Slot = "a1",
                ProductName = "item",
                Price = 1.10m,
            };
            items.Add(item);
            VendingMachineItem[] itemArray = items.ToArray();
            CollectionAssert.AreEquivalent(items, itemArray);
        }

        [TestMethod]
        public void BalanceMethodPropertyTest()
        {
            VendingMachine vm = new VendingMachine();
            vm.AddToBalance(5);
            Assert.AreEqual(5, vm.Balance);
        }

        [TestMethod]
        public void MakeChangeTest25CentsReturn1Quarter()
        {
            VendingMachine vm = new VendingMachine();
            vm.AddToBalance(0.25M);
            int[] result = vm.MakeChange(vm.Balance);
            int[] expectedResult = { 1, 0, 0 };
            CollectionAssert.AreEquivalent(expectedResult, result);
        }

        [TestMethod]
        public void MakeChangeTest35CentsReturn1Quarter1Dime()
        {
            VendingMachine vm = new VendingMachine();
            vm.AddToBalance(0.35M);
            int[] result = vm.MakeChange(vm.Balance);
            int[] expectedResult = { 1, 1, 0 };
            CollectionAssert.AreEquivalent(expectedResult, result);
        }

        [TestMethod]
        public void MakeChangeTest40CentsReturn1Quarter1Dime1Nickel()
        {
            VendingMachine vm = new VendingMachine();
            vm.AddToBalance(0.40M);
            int[] result = vm.MakeChange(vm.Balance);
            int[] expectedResult = { 1, 1, 1 };
            CollectionAssert.AreEquivalent(expectedResult, result);
        }

        [TestMethod]
        public void MakeChangeTest50CentsReturn2Quarters()
        {
            VendingMachine vm = new VendingMachine();
            vm.AddToBalance(0.50M);
            int[] result = vm.MakeChange(vm.Balance);
            int[] expectedResult = { 2, 0, 0 };
            CollectionAssert.AreEquivalent(expectedResult, result);
        }

        [TestMethod]
        public void MakeChangeTest10CentsReturn1Dime()
        {
            VendingMachine vm = new VendingMachine();
            vm.AddToBalance(0.10M);
            int[] result = vm.MakeChange(vm.Balance);
            int[] expectedResult = { 0, 1, 0 };
            CollectionAssert.AreEquivalent(expectedResult, result);
        }

        [TestMethod]
        public void MakeChangeTest5CentsReturn1Nickel()
        {
            VendingMachine vm = new VendingMachine();
            vm.AddToBalance(0.10M);
            int[] result = vm.MakeChange(vm.Balance);
            int[] expectedResult = { 0, 0, 1 };
            CollectionAssert.AreEquivalent(expectedResult, result);
        }

        [TestMethod]
        public void MakeChangeTest10DollarsReturn40Quarters()
        {
            VendingMachine vm = new VendingMachine();
            vm.AddToBalance(10);
            int[] result = vm.MakeChange(vm.Balance);
            int[] expectedResult = { 40, 0, 0 };
            CollectionAssert.AreEquivalent(expectedResult, result);
        }
    }
}

