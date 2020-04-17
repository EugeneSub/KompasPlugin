using System;
using NUnit.Framework;

namespace TeaPot.UnitTests
{

    [TestFixture]
    public class TeaPotTests
    {
        [Test(Description = "Позитивный тест геттера Diameter")]
        public void TestDiameterGet_CorrectValue()
        {
            var teapotParams = new TeaPotParams(100, 150, 20, 95, TeaPotParams.TheColor.Green, TeaPotParams.TheColor.Blue);
            var expected = 100;
            var actual = teapotParams.TeaPotDiameter;
            Assert.AreEqual(expected, actual, "Геттер Diameter возвращает неправильное значение.");
        }

        [Test(Description = "Негативный тест геттера Diameter")]
        public void TestDiameterGet_BadValue()
        {
            var wrongBodyDiameter = 99;
            var teapotParams = new TeaPotParams(100, 150, 20, 95, TeaPotParams.TheColor.Green, TeaPotParams.TheColor.Blue);
            Assert.Throws<ArgumentException>(() => { teapotParams.TeaPotDiameter = wrongBodyDiameter; }, "-");
        }

        [Test(Description = "Позитивный тест геттера Height")]
        public void TestHeightGet_CorrectValue()
        {
            var teapotParams = new TeaPotParams(100, 150, 20, 95, TeaPotParams.TheColor.Green, TeaPotParams.TheColor.Blue);
            var expected = 150;
            var actual = teapotParams.TeaPotHeight;
            Assert.AreEqual(expected, actual, "Геттер Height возвращает неправильное значение.");
        }
        [Test(Description = "Негативный тест геттера Height")]
        public void TestHeightGet_BadValue()
        {
            var wrongBodyHeight = 149;
            var teapotParams = new TeaPotParams(100, 150, 20, 95, TeaPotParams.TheColor.Green, TeaPotParams.TheColor.Blue);
            Assert.Throws<ArgumentException>(() => { teapotParams.TeaPotHeight = wrongBodyHeight; }, "-");
        }

        [Test(Description = "Позитивный тест геттера SpoutLength")]
        public void TestSpoutLengthGet_CorrectValue()
        {
            var teapotParams = new TeaPotParams(100, 150, 20, 95, TeaPotParams.TheColor.Green, TeaPotParams.TheColor.Blue);
            var expected = 20;
            var actual = teapotParams.TeaPotSpoutLength;
            Assert.AreEqual(expected, actual, "Геттер SpoutLength возвращает неправильное значение.");
        }

        [Test(Description = "Негативный тест геттера SpoutLength")]
        public void TestSpoutLengthGet_BadValue()
        {
            var wrongSpoutLength = 19;
            var teapotParams = new TeaPotParams(100, 150, 20, 95, TeaPotParams.TheColor.Green, TeaPotParams.TheColor.Blue);
            Assert.Throws<ArgumentException>(() => { teapotParams.TeaPotSpoutLength = wrongSpoutLength; }, "-");
        }

        [Test(Description = "Позитивный тест геттера HandleSize")]
        public void TestHandleSizeGet_CorrectValue()
        {
            var teapotParams = new TeaPotParams(100, 150, 20, 95, TeaPotParams.TheColor.Green, TeaPotParams.TheColor.Blue);
            var expected = 95;
            var actual = teapotParams.TeaPotHandleSize;
            Assert.AreEqual(expected, actual, "Геттер HandleSize возвращает неправильное значение.");
        }

        [Test(Description = "Негативный тест геттера HandleSize")]
        public void TestHandleSizeGet_BadValue()
        {
            var wrongHandleSize = 94;
            var teapotParams = new TeaPotParams(100, 150, 20, 95, TeaPotParams.TheColor.Green, TeaPotParams.TheColor.Blue);
            Assert.Throws<ArgumentException>(() => { teapotParams.TeaPotHandleSize = wrongHandleSize; }, "-");
        }

        [Test(Description = "Позитивный тест геттера BodyColor")]
        public void TestBodyColorGet_CorrectValue()
        {
            var teapotParams = new TeaPotParams(100, 150, 20, 95, TeaPotParams.TheColor.Green, TeaPotParams.TheColor.Blue);
            var expected = TeaPotParams.TheColor.Green;
            var actual = teapotParams.TeaPotBodyColor;
            Assert.AreEqual(expected, actual, "Геттер BodyColor возвращает неправильное значение.");
        }

        [Test(Description = "Позитивный тест геттера HandleColor")]
        public void TestHandleColorGet_CorrectValue()
        {
            var teapotParams = new TeaPotParams(100, 150, 20, 95, TeaPotParams.TheColor.Green, TeaPotParams.TheColor.Blue);
            var expected = TeaPotParams.TheColor.Blue;
            var actual = teapotParams.TeaPotHandleColor;
            Assert.AreEqual(expected, actual, "Геттер HandleColor возвращает неправильное значение.");
        }
    }
}
