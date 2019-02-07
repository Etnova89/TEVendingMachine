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
        public void AddPropertiesToItemTestReturn()
        {
            VendingMachineItem item = new VendingMachineItem();
            item.Slot = "A1";
            item.ProductName = "TestName";
            item.Price = 3.00M;
            Assert.AreEqual("A1", item.Slot);
        }

        [TestMethod]
        public void TakeArraySplitAndAddToPropertiesOfVendingMachineItem()
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


        //[TestMethod]
        //public void VendingMachineItemAdd()
        //{
        //    VendingMachine vm = new VendingMachine();
        //    int oldCount = vm.ToArray().Length;
        //    VendingMachineItem item = new VendingMachineItem()
        //    {
        //        Slot = "a1",
        //        ProductName = "item",
        //        Price = 1.10m,
        //    };
        //    vm.Add(item);
        //    int newCount = vm.ToArray().Length;
        //    Assert.AreEqual(oldCount + 1, newCount);


        //}

    }
}
