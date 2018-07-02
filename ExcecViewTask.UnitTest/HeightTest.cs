using NUnit.Framework;
using System;

namespace ExecViewTask.UnitTest
{
    [TestFixture()]
    public class HeightTest
    {
        [Test()]
        public void GetHeightInCentimeters()
        {
            int feet = 5;
            int inches = 7;

            double expected = 170.18;

            Height height = new Height(feet, inches);
            double actual = height.GetHeightInCentimeters();

            Assert.AreEqual(expected, actual);
        }
    }
}
