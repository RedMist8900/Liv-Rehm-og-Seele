using DataModels;
using FunctionsLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        Function func = new Function();

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void OpretKundeFejlTest()
        {
            func.OpretKunde("A", "B", "T", "E", "56565656");
            func.OpretKunde("A", "B", "T", "E", "56565656");
        }

        //[TestMethod]
        //[ExpectedException(typeof(Exception))]
        //public void OpretForsikringFejlTest()
        //{
        //    func.OpretForsikring(new Kunde(), new BilModel(), "", 51, 80);
        //}

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void OpretForsikringFejlTest()
        {
            func.OpretBilModel("Ford", "Fiesta", new DateTime(2011/11/06), new DateTime(2012/11/06), "200000", "500000");
            func.OpretBilModel("Ford", "Fiesta", new DateTime(2011/11/06), new DateTime(2012/11/06), "200000", "500000");
        }
    }
}
