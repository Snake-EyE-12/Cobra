using UnityEngine.Assertions;
using Cobra.UnitTesting;
using Cobra.Utilities;
using UnityEngine;

namespace Cobra.UnitTesting.Tests
{
    public class UT_Illion : UnitTest
    {
        
        [Test]
        public void IntToIllion()
        {
            //Assemble
            Illion illion = 4;
            //Act
            //Assert
            Assert.AreEqual(4, illion.Value);
        }
        [Test]
        public void IllionToInt()
        {
            //Assemble
            Illion illion = new Illion(6);
            //Act
            int converted = illion;
            //Assert
            Assert.AreEqual(6, converted);
        }

        [Test]
        public void ValueGetting()
        {
            //Assemble
            Illion illion = new Illion(6);
            //Act
            //Assert
            Assert.AreEqual(6, illion.Value);
            
        }
        [Test]
        public void InitializeNormal()
        {
            //Assemble
            Illion illion = 394;
            //Act
            //Assert
            Assert.AreEqual(394, illion.Value);
            
        }
        [Test]
        public void InitializeLarge()
        {
            //Assemble
            Illion illion = 267345394;
            //Act
            //Assert
            Assert.AreEqual(267345394, illion.Value);
            
        }
        [Test]
        public void InitializeInfinite()
        {
            //Assemble
            Illion illion = int.MaxValue;
            //Act
            //Assert
            Assert.AreEqual(int.MaxValue, illion.Value);
            
        }
        [Test]
        public void InitializeZero()
        {
            //Assemble
            Illion illion = 0;
            //Act
            //Assert
            Assert.AreEqual(0, illion.Value);
            
        }
        [Test]
        public void InitializeSmallNegative()
        {
            //Assemble
            Illion illion = -78;
            //Act
            //Assert
            Assert.AreEqual(-78, illion.Value);
            
        }
        [Test]
        public void InitializeLargeNegative()
        {
            //Assemble
            Illion illion = -782345;
            //Act
            //Assert
            Assert.AreEqual(-782345, illion.Value);
            
        }
        [Test]
        public void InitializeInfiniteNegative()
        {
            //Assemble
            Illion illion = int.MinValue;
            //Act
            //Assert
            Assert.AreEqual(int.MinValue, illion.Value);
            
        }
        
        [Test]
        public void AddValue()
        {
            //Assemble
            Illion illion = 7;
            //Act
            illion += 5;
            //Assert
            Assert.AreEqual(12, illion.Value);
            
        }
        [Test]
        public void AddValueOverSection()
        {
            //Assemble
            Illion illion = 7;
            //Act
            illion += 5000;
            //Assert
            Assert.AreEqual(5007, illion.Value);
            
        }
        [Test]
        public void AddValueCausingOverSection()
        {
            //Assemble
            Illion illion = 999;
            //Act
            illion += 5;
            //Assert
            Assert.AreEqual(1004, illion.Value);
            
        }
        [Test]
        public void AddValueTooLarge()
        {
            //Assemble
            Illion illion = 10;
            //Act
            illion += int.MaxValue;
            //Assert
            Assert.AreEqual(int.MaxValue, illion.Value);
            
        }
        [Test]
        public void AddValueCausingTooLarge()
        {
            //Assemble
            Illion illion = 2000000000;
            //Act
            illion += 2000000000;
            //Assert
            Assert.AreEqual(int.MaxValue, illion.Value);
            
        }
        
        [Test]
        public void GetStringNormal()
        {
            //Assemble
            Illion illion = 8327;
            //Act
            string actual = illion.ToString();
            //Assert
            Assert.AreEqual("8327", actual);
        }
        [Test]
        public void GetStringInfinite()
        {
            //Assemble
            Illion illion = int.MaxValue;
            //Act
            string actual = illion.ToString();
            //Assert
            Assert.AreEqual(int.MaxValue.ToString(), actual);
        }
        [Test]
        public void GetStringPastInfinite()
        {
            //Assemble
            Illion illion = 2000000000;
            string expected = "4000435090";
            //Act
            illion += 2000000000;
            illion += 30000;
            illion += 350000;
            illion += 54745;
            illion += 345;
            string actual = illion.ToString();
            //Assert
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void SubtractValue()
        {
            //Assemble
            Illion illion = 7;
            //Act
            illion -= 5;
            //Assert
            Assert.AreEqual(2, illion.Value);
        }
        
        
        
        
    }
}