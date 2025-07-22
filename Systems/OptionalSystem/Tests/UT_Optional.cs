using Cobra.DesignPattern;
using UnityEngine.Assertions;
using Cobra.UnitTesting;
using Cobra.Utilities.Extensions;
using UnityEngine;

namespace Cobra.UnitTesting.Tests
{
    public class UT_Optional : UnitTest
    {
        
        [Test]
        public void CreationSome()
        {
            //Assemble
            Optional<int> optional = Optional<int>.Some(6);
            //Act
            
            //Assert
            Assert.AreEqual(6, optional.Value);
        }
        [Test]
        public void CreationNone()
        {
            //Assemble
            Optional<int> optional = Optional<int>.None;
            //Act
            
            //Assert
            Assert.AreEqual(0, optional.Value);
        }
        
        [Test]
        public void DefaultSetValue()
        {
            //Assemble
            Optional<int> optional = Optional<int>.Some(8);
            //Act
            
            //Assert
            Assert.AreEqual(8, optional.GetValueOrDefault(7));
        }
        
        [Test]
        public void DefaultValue()
        {
            //Assemble
            Optional<int> optional = Optional<int>.None;
            //Act
            
            //Assert
            Assert.AreEqual(7, optional.GetValueOrDefault(7));
        }
        
        [Test]
        public void HasValueTrue()
        {
            //Assemble
            Optional<int> optional = Optional<int>.Some(3);
            //Act
            
            //Assert
            Assert.IsTrue(optional.HasValue);
        }
        [Test]
        public void HasValueFalse()
        {
            //Assemble
            Optional<int> optional = Optional<int>.None;
            //Act
            
            //Assert
            Assert.IsFalse(optional.HasValue);
        }
        
        [Test]
        public void EqualsValue()
        {
            //Assemble
            Optional<int> optional = Optional<int>.Some(12);
            //Act
            
            //Assert
            Assert.IsTrue(optional.Equals(12));
        }
        [Test]
        public void EqualsSimilarOptionalValue()
        {
            //Assemble
            Optional<int> optional = Optional<int>.Some(12);
            Optional<int> optional2 = Optional<int>.Some(12);
            //Act
            
            //Assert
            Assert.IsTrue(optional.Equals(optional2));
        }
        [Test]
        public void EqualsSelf()
        {
            //Assemble
            Optional<int> optional = Optional<int>.Some(12);
            //Act
            
            //Assert
            Assert.IsTrue(optional.Equals(optional));
        }
        
        [Test]
        public void CastingBool()
        {
            //Assemble
            Optional<int> optional = Optional<int>.Some(12);
            //Act
            
            //Assert
            Assert.IsTrue(optional);
        }
        
        [Test]
        public void CastingEquals()
        {
            //Assemble
            Optional<int> optional = Optional<int>.Some(12);
            //Act
            optional = 3;
            //Assert
            Assert.AreEqual(3, optional.Value);
        }
        
        [Test]
        public void CastingToType()
        {
            //Assemble
            Optional<int> optional = Optional<int>.Some(3);
            //Act
            int actualValue = (int)optional;
            //Assert
            Assert.AreEqual(3, actualValue);
        }
        //
        // public void d()
        // {
        //     Vector3Int wer = new Vector3(0, 0, 0).ToVector3Int();
        //     Vector3 te3 = Vector3.zero;
        //     Vector2 te2 = Vector2.zero;
        //
        //     Vector2 test1 = te3 + te2;
        //     Vector2 test2 = te2 + te3;
        //     
        //     Vector2 test3 = te3 - te2;
        //     Vector2 test4 = te2 - te3;
        //     
        //     Vector2 test5 = te3 * te2;
        //     Vector2 test6 = te2 * te3;
        //     
        //     Vector2 test7 = te3 / te2;
        //     Vector2 test8 = te2 / te3;
        //     
        //     
        //     Vector3 t3est1 = te3 + te2;
        //     Vector3 t3est2 = te2 + te3;
        //     
        //     Vector3 t3est3 = te3 - te2;
        //     Vector3 t3est4 = te2 - te3;
        //     
        //     Vector3 t3est5 = te3 * te2;
        //     Vector3 t3est6 = te2 * te3;
        //     
        //     Vector3 t3est7 = te3 / te2;
        //     Vector3 t3est8 = te2 / te3;
        //     
        //     bool comparison1 = te3 == te2;
        //     bool comparison2 = te2 == te3;
        //     
        //     bool comparison3 = te3 != te2;
        //     bool comparison4 = te2 != te3;
        //
        //     te3 += te2;
        //     te2 += te3;
        //     
        //     te3 -= te2;
        //     te2 -= te3;
        //     
        //     te3 *= te2;
        //     te2 *= te3;
        //     
        //     te3 /= te2;
        //     te2 /= te3;
        //     
        //     
        //     
        //     
        //     Vector3Int intte3 = Vector3Int.zero;
        //     Vector2Int intte2 = Vector2Int.zero;
        //
        //     Vector2Int iTest1 = intte3 + intte2;
        //     Vector2Int iTest2 = intte2 + intte3;
        //
        //     Vector2Int iTest3 = intte3 - intte2;
        //     Vector2Int iTest4 = intte2 - intte3;
        //     
        //     
        //     Vector2Int itest5 = intte3 * intte2;
        //     Vector2Int itest6 = intte2 * intte3;
        //     
        //     Vector2Int itest7 = intte3 / intte2;
        //     Vector2Int itest8 = intte2 / intte3;
        //     
        //     
        //     Vector3Int it3est1 = intte3 + intte2;
        //     Vector3Int it3est2 = intte2 + intte3;
        //     
        //     Vector3Int it3est3 = intte3 - intte2;
        //     Vector3Int it3est4 = intte2 - intte3;
        //     
        //     Vector3Int it3est5 = intte3 * intte2;
        //     Vector3Int it3est6 = intte2 * intte3;
        //
        //     Vector3Int it3est7 = intte3 / intte2;
        //     Vector3Int it3est8 = intte2 / intte3;
        //     
        //     bool icomparison1 = intte3 == intte2;
        //     bool icomparison2 = intte2 == intte3;
        //     
        //     bool icomparison3 = intte3 != intte2;
        //     bool icomparison4 = intte2 != intte3;
        //
        //     intte3 += intte2;
        //     intte2 += intte3;
        //     
        //     intte3 -= intte2;
        //     intte2 -= intte3;
        //     
        //     intte3 *= intte2;
        //     intte2 *= intte3;
        //     
        //     intte3 /= intte2;
        //     intte2 /= intte3;
        //
        //
        // }
        
    }
}