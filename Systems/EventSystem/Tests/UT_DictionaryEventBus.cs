using System;
using Cobra.DesignPattern.Observer;
using Cobra.UnitTesting;
using UnityEngine;
using UnityEngine.Assertions;

namespace Cobra.UnitTesting.Tests
{
    public class UT_DictionaryEventBus : UnitTest
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
            EventBusWeakDictionary looselyTypedEventBus = new();
            //Act
            //Assert
            Assert.AreEqual(0, looselyTypedEventBus.Count("bus0"));
        }

        [Test]
        public void BusCountEntriesCorrect()
        {
            //Assemble
            EventBusWeakDictionary looselyTypedEventBus = new();
            //Act
            //Assert
            Assert.AreEqual(0, looselyTypedEventBus.Entries);
        }

        [Test]
        public void AddingListenerThroughMethod()
        {
            //Assemble
            EventBusWeakDictionary looselyTypedEventBus = new();
            //Act
            looselyTypedEventBus.AddListener("key1", (Action)FakeMethod);
            //Assert
            Assert.AreEqual(1, looselyTypedEventBus.Count("key1"));
        }

        [Test]
        public void AddingListenerMultiple()
        {
            //Assemble
            EventBusWeakDictionary looselyTypedEventBus = new();
            //Act
            looselyTypedEventBus.AddListener("key1", (Action)FakeMethod);
            looselyTypedEventBus.AddListener("key1", (Action)FakeMethod);
            //Assert
            Assert.AreEqual(2, looselyTypedEventBus.Count("key1"));
        }

        [Test]
        public void AddingListenerMultipleUnique()
        {
            //Assemble
            EventBusWeakDictionary looselyTypedEventBus = new();
            //Act
            looselyTypedEventBus.AddListener("key1", (Action)FakeMethod);
            looselyTypedEventBus.AddListener("key2", (Action)FakeMethod);
            //Assert
            Assert.AreEqual(1, looselyTypedEventBus.Count("key1"));
        }

        [Test]
        public void RemovingListenerThroughMethod()
        {
            //Assemble
            EventBusWeakDictionary looselyTypedEventBus = new();
            //Act
            looselyTypedEventBus.RemoveListener("bus0", (Action)FakeMethod);
            //Assert
            Assert.AreEqual(0, looselyTypedEventBus.Count("bus0"));
        }


        [Test]
        public void BlankInvocation()
        {
            //Assemble
            EventBusWeakDictionary looselyTypedEventBus = new();
            //Act
            looselyTypedEventBus.Invoke("key1");
            //Assert
            Assert.AreEqual(0, looselyTypedEventBus.Count("bus0"));
        }

        [Test]
        public void ParameterizedInvocation()
        {
            //Assemble
            EventBusWeakDictionary looselyTypedEventBus = new();
            //Act
            looselyTypedEventBus.Invoke("key1", 7, "string");
            //Assert
            Assert.AreEqual(0, looselyTypedEventBus.Count("bus0"));
        }
    }
}
