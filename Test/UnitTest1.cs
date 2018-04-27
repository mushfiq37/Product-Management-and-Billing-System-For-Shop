using System;
using System.Windows;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]

        public void billMethod()
        {
            int sum = 1025;

            Baby_Choice.Purchase_Form pr = new Baby_Choice.Purchase_Form();
            Baby_Choice.MainForm mf = new Baby_Choice.MainForm();

            pr.bill(sum);
            double result = mf.grandTotal(100);

            Assert.AreEqual(976.25, result);
        }
    }
}
