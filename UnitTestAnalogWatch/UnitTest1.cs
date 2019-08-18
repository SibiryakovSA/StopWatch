using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Analog_watch.Models
{
    [TestClass]
    public class UnitTest1 : IObserver
    {
        StopWhatch sw = new StopWhatch();

        [TestMethod]
        public void TestMethod1()
        {

            sw.StartTimer();
            while (sw.GetTimeHasPassed != 5)
            {

            }
            sw.StopTimer();
        }

        public void Update()
        {
            Console.WriteLine(sw.GetTimeHasPassed);
            
        }
    }
}
