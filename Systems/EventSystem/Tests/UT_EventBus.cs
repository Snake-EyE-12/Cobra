using System;
using Cobra.DesignPattern.Observer;
using Cobra.UnitTesting;
using UnityEngine;
using UnityEngine.Assertions;
namespace Cobra.UnitTesting.Tests
{
    public class UT_EventBus : UnitTest
    {
        private void FakeMethod()
        {

        }

        private void FakeMethod(int data)
        {

        }

        private void FakeMethod(string data)
        {

        }

        [Test]
        public void BusCountCorrect()
        {
            //Assemble
            EventBusWeak looselyTypedEventBus = new EventBusWeak();
            //Act
            //Assert
            Assert.AreEqual(0, looselyTypedEventBus.Count);
        }

        [Test]
        public void AddingListenerThroughMethod()
        {
            //Assemble
            EventBusWeak looselyTypedEventBus = new EventBusWeak();
            //Act
            looselyTypedEventBus.AddListener((Action)FakeMethod);
            //Assert
            Assert.AreEqual(1, looselyTypedEventBus.Count);
        }

        [Test]
        public void AddingListenerThroughOperator()
        {
            //Assemble
            EventBusWeak looselyTypedEventBus = new EventBusWeak();
            //Act
            looselyTypedEventBus += (Action)FakeMethod;
            looselyTypedEventBus += (Action<int>)FakeMethod;
            //Assert
            Assert.AreEqual(2, looselyTypedEventBus.Count);
        }

        [Test]
        public void RemovingListenerThroughMethod()
        {
            //Assemble
            EventBusWeak looselyTypedEventBus = new EventBusWeak();
            //Act
            looselyTypedEventBus.RemoveListener((Action)FakeMethod);
            //Assert
            Assert.AreEqual(0, looselyTypedEventBus.Count);
        }

        [Test]
        public void RemovingListenerThroughOperator()
        {
            //Assemble
            EventBusWeak looselyTypedEventBus = new EventBusWeak();
            //Act
            looselyTypedEventBus -= (Action)FakeMethod;
            looselyTypedEventBus -= (Action<int>)FakeMethod;
            //Assert
            Assert.AreEqual(0, looselyTypedEventBus.Count);
        }

        [Test]
        public void BlankInvocation()
        {
            //Assemble
            EventBusWeak looselyTypedEventBus = new EventBusWeak();
            //Act
            looselyTypedEventBus.Invoke();
            //Assert
            Assert.AreEqual(0, looselyTypedEventBus.Count);
        }

        [Test]
        public void ParameterizedInvocation()
        {
            //Assemble
            EventBusWeak looselyTypedEventBus = new EventBusWeak();
            //Act
            looselyTypedEventBus.Invoke(7, "string");
            //Assert
            Assert.AreEqual(0, looselyTypedEventBus.Count);
        }
    }

}
