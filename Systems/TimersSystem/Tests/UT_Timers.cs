using UnityEngine.Assertions;
using Cobra.UnitTesting;
using UnityEngine;
using ImprovedTimers;

namespace Cobra.UnitTesting.Tests
{
    public class UT_Timers : UnitTest
    {
        private Timer timer;
        [Test]
        public void StartCountdownTimerTest()
        {
           timer = new CountdownTimer(4);
           timer.OnTimerStart += method;
           timer.Start();
        }

        private void method()
        {
            
        }
        
    }
}