using UnityEngine;
using UnityEngine.Assertions;

namespace Cobra.UnitTesting
{
    public class UT_UnitTest : UnitTest
    {
        [Test]
        public void ExampleEqual()
        {
            //Assemble
            //Act
            //Assert
            Assert.AreEqual(1, 1);
        }
        [Test]
        public void ExampleTrue()
        {
            //Assemble
            //Act
            //Assert
            Assert.IsTrue(true);
        }
        [Test]
        public void ExampleFalse()
        {
            //Assemble
            //Act
            //Assert
            Assert.IsFalse(false);
        }
        [Test]
        public void ExampleNull()
        {
            //Assemble
            //Act
            //Assert
            Assert.IsNull<string>(null);
        }
    }
}