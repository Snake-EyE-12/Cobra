using System;
using Cobra.DesignPattern.Observer;
using Cobra.UnitTesting;
using UnityEngine;
using UnityEngine.Assertions;

namespace Cobra.UnitTesting.Tests
{
    public class UT_EventBusNoParam : UnitTest
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
            EventBusNoParams looselyTypedEventBus = new EventBusNoParams();
            //Act
            //Assert
            Assert.AreEqual(0, looselyTypedEventBus.Count);
        }

        [Test]
        public void AddingListenerThroughMethod()
        {
            //Assemble
            EventBusNoParams looselyTypedEventBus = new EventBusNoParams();
            //Act
            looselyTypedEventBus.AddListener(FakeMethod);
            //Assert
            Assert.AreEqual(1, looselyTypedEventBus.Count);
        }

        [Test]
        public void AddingListenerThroughOperator()
        {
            //Assemble
            EventBusNoParams looselyTypedEventBus = new EventBusNoParams();
            //Act
            looselyTypedEventBus += FakeMethod;
            //Assert
            Assert.AreEqual(1, looselyTypedEventBus.Count);
        }

        [Test]
        public void RemovingListenerThroughMethod()
        {
            //Assemble
            EventBusNoParams looselyTypedEventBus = new EventBusNoParams();
            //Act
            looselyTypedEventBus.RemoveListener(FakeMethod);
            //Assert
            Assert.AreEqual(0, looselyTypedEventBus.Count);
        }

        [Test]
        public void RemovingListenerThroughOperator()
        {
            //Assemble
            EventBusNoParams looselyTypedEventBus = new EventBusNoParams();
            //Act
            looselyTypedEventBus -= FakeMethod;
            //Assert
            Assert.AreEqual(0, looselyTypedEventBus.Count);
        }

        [Test]
        public void BlankInvocation()
        {
            //Assemble
            EventBusNoParams looselyTypedEventBus = new EventBusNoParams();
            //Act
            looselyTypedEventBus.Invoke();
            //Assert
            Assert.AreEqual(0, looselyTypedEventBus.Count);
        }
    }
}