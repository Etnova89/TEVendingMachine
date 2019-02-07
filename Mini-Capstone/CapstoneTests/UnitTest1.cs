using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Classes;
using System.Collections.Generic;

namespace CapstoneTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void VendingMachineCreate()
        {
            VendingMachine vm = new VendingMachine();
            Assert.IsNotNull(vm);
        }

        [TestMethod]
        public void VendingMachineCreateItemList()
        {
            List<VendingMachineItem> items = new List<VendingMachineItem>();
            Assert.IsNotNull(items);
        }

        [TestMethod]
        public void VendingMachineAddToItemList()
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
        public void VendingMachineItemAdd()
        {
            VendingMachine vm = new VendingMachine();
            int oldCount = vm.ToArray().Length;
            VendingMachineItem item = new VendingMachineItem()
            {
                Slot = "a1",
                ProductName = "item",
                Price = 1.10m,
            };
            vm.Add(item);
            int newCount = vm.ToArray().Length;
            Assert.AreEqual(oldCount + 1, newCount);


        }

    }
}
