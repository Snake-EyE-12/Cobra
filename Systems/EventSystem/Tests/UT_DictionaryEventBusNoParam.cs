using System;
using Cobra.DesignPattern.Observer;
using Cobra.UnitTesting;
using UnityEngine;
using UnityEngine.Assertions;

namespace Cobra.UnitTesting.Tests
{
    public class UT_DictionaryEventBusNoParam : UnitTest
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
            EventBusNoParamsDictionary looselyTypedEventBus = new();
            //Act
            //Assert
            Assert.AreEqual(0, looselyTypedEventBus.Count("bus0"));
        }

        [Test]
        public void BusCountEntriesCorrect()
        {
            //Assemble
            EventBusNoParamsDictionary looselyTypedEventBus = new();
            //Act
            //Assert
            Assert.AreEqual(0, looselyTypedEventBus.Entries);
        }

        [Test]
        public void AddingListenerThroughMethod()
        {
            //Assemble
            EventBusNoParamsDictionary looselyTypedEventBus = new();
            //Act
            looselyTypedEventBus.AddListener("key1", FakeMethod);
            //Assert
            Assert.AreEqual(1, looselyTypedEventBus.Count("key1"));
        }

        [Test]
        public void AddingListenerMultiple()
        {
            //Assemble
            EventBusNoParamsDictionary looselyTypedEventBus = new();
            //Act
            looselyTypedEventBus.AddListener("key1", FakeMethod);
            looselyTypedEventBus.AddListener("key1", FakeMethod);
            //Assert
            Assert.AreEqual(2, looselyTypedEventBus.Count("key1"));
        }

        [Test]
        public void AddingListenerMultipleUnique()
        {
            //Assemble
            EventBusNoParamsDictionary looselyTypedEventBus = new();
            //Act
            looselyTypedEventBus.AddListener("key1", FakeMethod);
            looselyTypedEventBus.AddListener("key2", FakeMethod);
            //Assert
            Assert.AreEqual(1, looselyTypedEventBus.Count("key1"));
        }

        [Test]
        public void RemovingListenerThroughMethod()
        {
            //Assemble
            EventBusNoParamsDictionary looselyTypedEventBus = new();
            //Act
            looselyTypedEventBus.RemoveListener("bus0", FakeMethod);
            //Assert
            Assert.AreEqual(0, looselyTypedEventBus.Count("bus0"));
        }


        [Test]
        public void BlankInvocation()
        {
            //Assemble
            EventBusNoParamsDictionary looselyTypedEventBus = new();
            //Act
            looselyTypedEventBus.Invoke("key1");
            //Assert
            Assert.AreEqual(0, looselyTypedEventBus.Count("bus0"));
        }
    }
}