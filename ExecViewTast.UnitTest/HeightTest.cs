using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExecViewTask.UnitTest
{
    [TestClass]
    public class ProgramTest
    {
        [TestMethod]
        public void ReadPlayersData()
        {
            bool works = true;
            string message = "";
            try
            {
                ReadPlayersData();
            }
            catch(Exception ex)
            {
                message = ex.Message;
                works = false;
            }
            Assert.IsTrue(works, message);
        }
    }
}
