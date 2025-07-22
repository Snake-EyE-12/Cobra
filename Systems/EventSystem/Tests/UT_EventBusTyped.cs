using System;
using Cobra.DesignPattern.Observer;
using Cobra.UnitTesting;
using UnityEngine;
using UnityEngine.Assertions;

namespace Cobra.UnitTesting.Tests
{
    public class UT_EventBusTyped : UnitTest
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
            EventBus<int> looselyTypedEventBus = new EventBus<int>();
            //Act
            //Assert
            Assert.AreEqual(0, looselyTypedEventBus.Count);
        }

        [Test]
        public void AddingListenerThroughMethod()
        {
            //Assemble
            EventBus<int> looselyTypedEventBus = new EventBus<int>();
            //Act
            looselyTypedEventBus.AddListener(FakeMethod);
            //Assert
            Assert.AreEqual(1, looselyTypedEventBus.Count);
        }

        [Test]
        public void AddingListenerThroughOperator()
        {
            //Assemble
            EventBus<int> looselyTypedEventBus = new EventBus<int>();
            //Act
            looselyTypedEventBus += FakeMethod;
            //Assert
            Assert.AreEqual(1, looselyTypedEventBus.Count);
        }

        [Test]
        public void RemovingListenerThroughMethod()
        {
            //Assemble
            EventBus<int> looselyTypedEventBus = new EventBus<int>();
            //Act
            looselyTypedEventBus.RemoveListener(FakeMethod);
            //Assert
            Assert.AreEqual(0, looselyTypedEventBus.Count);
        }

        [Test]
        public void RemovingListenerThroughOperator()
        {
            //Assemble
            EventBus<int> looselyTypedEventBus = new EventBus<int>();
            //Act
            looselyTypedEventBus -= FakeMethod;
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