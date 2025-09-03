using Microsoft.VisualStudio.TestTools.UnitTesting;
using MooGame.App.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MooGame.App.Helper.Tests
{
    [TestClass()]
    
    public class MooUniqueNumberGeneratorTests
    {
        [DataTestMethod()]
        [TestCategory("Done")]
        [DataRow(1)]
        [DataRow(4)]
        [DataRow(8)]
        public void GenerateNumber_Returns_String_Of_Requested_Length(int length)
        {
            //Arrange
            var generator = new MooUniqueNumberGenerator();

            //Act
            var number = generator.GenerateNumber(length);

            //Assert

            Assert.IsNotNull(number, "Result should not be null.");
            Assert.AreEqual(length, number.Length);
        }

        [DataTestMethod()]
        [TestCategory("Done")]
        [DataRow(1)]
        [DataRow(4)]
        [DataRow(8)]
        public void Test_DigitsAreUnique(int length)
        {
            //Arrange
            var generator = new MooUniqueNumberGenerator();
            
            //Act
            var number = generator.GenerateNumber(length);
            //Assert
            Assert.AreEqual(length, number.Distinct().Count());
        }

        //Arrange

        //Act

        //Assert
    }
}