using System;
using NUnit.Framework;
using TeaPotParameters;

namespace TeaPotUnitTests
{
    [TestFixture]
    public class TeaPotTests
    {
        /// <summary>
        /// Поле хранит значения параметров
        /// </summary>
        private TeaPotParams teapotParams;

        /// <summary>
        /// Метод вызывается до всех модульных тестов.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            teapotParams = new TeaPotParams();
        }

        [TestCase(100, 
            TestName = "Позитивный тест установки параметров чайника с минимальным диаметром")]
        [TestCase(140, 
            TestName = "Позитивный тест установки параметров чайника с максимальным диаметром")]
        public void TestGet_CorrectDiameter(double diameter)
        {
            teapotParams.TeaPotDiameter = diameter;
        }

        [TestCase(150, 
            TestName = "Позитивный тест установки параметров чайника с минимальной высотой")]
        [TestCase(200, 
            TestName = "Позитивный тест установки параметров чайника с максимальной высотой")]
        public void TestGet_CorrectHeight(double height)
        {
            teapotParams.TeaPotHeight = height;
        }

        [TestCase(20, 
            TestName = "Позитивный тест установки параметров чайника с минимальной длиной носика")]
        [TestCase(25, 
            TestName = "Позитивный тест установки параметров чайника с максимальной длиной носика")]
        public void TestGet_CorrectSpoutLength(double spoutLength)
        {
            teapotParams.TeaPotSpoutLength = spoutLength;
        }

        [TestCase(100, 15, 
            TestName = "Позитивный тест установки зависимого параметра чайника с минимальной шириной носика")]
        [TestCase(140, 28, 
            TestName = "Позитивный тест установки зависимого параметра чайника с максимальной шириной носика")]
        public void TestGet_CorrectSpoutWidth(double diameter, double spoutWidth)
        {
            teapotParams.TeaPotDiameter = diameter;
            teapotParams.TeaPotSpoutWidth = spoutWidth;
        }

        [TestCase(100, 15, 
            TestName = "Позитивный тест установки зависимого параметра чайника с минимальной высотой носика")]
        [TestCase(140, 28, 
            TestName = "Позитивный тест установки зависимого параметра чайника с максимальной высотой носика")]
        public void TestGet_CorrectSpoutHeight(double diameter, double spoutHeight)
        {
            teapotParams.TeaPotDiameter = diameter;
            teapotParams.TeaPotSpoutHeight = spoutHeight;
        }

        [TestCase(95, 
            TestName = "Позитивный тест установки параметров чайника с минимальным размером ручки")]
        [TestCase(125, 
            TestName = "Позитивный тест установки параметров чайника с максимальным размером ручки")]
        public void TestGet_CorrectHandleSize(double handleSize)
        {
            teapotParams.TeaPotHandleSize = handleSize;
        }

        [TestCase(TeaPotParams.TheColor.Green, 
            TestName = "Позитивный тест установки параметров чайника с зеленым цветом корпуса")]
        [TestCase(TeaPotParams.TheColor.Blue, 
            TestName = "Позитивный тест установки параметров чайника с синим цветом корпуса")]
        public void TestGet_CorrectBodyColor(TeaPotParams.TheColor theColor)
        {
            teapotParams.TeaPotBodyColor = theColor;
        }

        [TestCase(TeaPotParams.TheColor.Yellow, 
            TestName = "Позитивный тест установки параметров чайника с желтым цветом ручки и носика")]
        [TestCase(TeaPotParams.TheColor.Red, 
            TestName = "Позитивный тест установки параметров чайника с красным цветом ручки и носика")]
        public void TestGet_CorrectHandleColor(TeaPotParams.TheColor theColor1)
        {
            teapotParams.TeaPotHandleColor = theColor1;
        }

        [TestCase(100, 150, 20, 15, 15, 95, 
            TeaPotParams.TheColor.Green, 
            TeaPotParams.TheColor.Yellow, 
            TestName = "Позитивный тест конструктора параметров чайника с минимальными значениями")]
        [TestCase(140, 200, 25, 28, 28, 125, 
            TeaPotParams.TheColor.Blue, 
            TeaPotParams.TheColor.Red, 
            TestName = "Позитивный тест конструктора параметров чайника с максимальными значениями")]
        public void TestCorrectConstructor(double diameter, double height, 
            double spoutLength, double spoutWidth, 
            double spoutHeight, double handleSize, 
            TeaPotParams.TheColor theColor, TeaPotParams.TheColor theColor1)
        {
            teapotParams = new TeaPotParams(diameter, height, 
                spoutLength, spoutWidth, 
                spoutHeight, handleSize, 
                theColor, theColor1);
        }

        [TestCase(99, 150, 20, 15, 15, 95, 
            TeaPotParams.TheColor.Green, 
            TeaPotParams.TheColor.Yellow, 
            TestName = "Негативный тест конструктора параметров чайника с минимальными значениями")]
        [TestCase(141, 200, 25, 28, 28, 125, 
            TeaPotParams.TheColor.Blue, 
            TeaPotParams.TheColor.Red, 
            TestName = "Негативный тест конструктора параметров чайника с максимальными значениями")]
        public void TestBadConstructor(double diameter, double height, 
            double spoutLength, double spoutWidth, 
            double spoutHeight, double handleSize, 
            TeaPotParams.TheColor theColor, TeaPotParams.TheColor theColor1)
        {
            Assert.Throws<ArgumentException>(() => { teapotParams = new TeaPotParams(diameter, height, 
                spoutLength, spoutWidth, 
                spoutHeight, handleSize, 
                theColor, theColor1); ; }, "-");
        }

        [TestCase(99, 
            TestName = "Негативный тест установки параметров чайника с минимальным диаметром")]
        [TestCase(141, 
            TestName = "Негативный тест установки параметров чайника с максимальным диаметром")]
        public void TestGet_BadDiameter(double diameter)
        {
            Assert.Throws<ArgumentException>(() => { teapotParams.TeaPotDiameter = diameter; }, "-");
        }

        [TestCase(149, 
            TestName = "Негативный тест установки параметров чайника с минимальной высотой")]
        [TestCase(201, 
            TestName = "Негативный тест установки параметров чайника с максимальной высотой")]
        public void TestGet_BadHeight(double height)
        {
            Assert.Throws<ArgumentException>(() => { teapotParams.TeaPotHeight = height; }, "-");
        }

        [TestCase(19, 
            TestName = "Негативный тест установки параметров чайника с минимальной длиной носика")]
        [TestCase(26, 
            TestName = "Негативный тест установки параметров чайника с максимальной длиной носика")]
        public void TestGet_BadSpoutLength(double spoutLength)
        {
            Assert.Throws<ArgumentException>(() => { teapotParams.TeaPotSpoutLength = spoutLength; }, "-");
        }

        [TestCase(100, 14, 
            TestName = "Негативный тест установки зависимого параметра чайника с минимальной шириной носика")]
        [TestCase(140, 29, 
            TestName = "Негативный тест установки зависимого параметра чайника с максимальной шириной носика")]
        public void TestGet_BadSpoutWidth(double diameter, double spoutWidth)
        {
            teapotParams.TeaPotDiameter = diameter;
            Assert.Throws<ArgumentException>(() => { teapotParams.TeaPotSpoutWidth = spoutWidth; }, "-");
        }

        [TestCase(100, 14, 
            TestName = "Негативный тест установки зависимого параметра чайника с минимальной высотой носика")]
        [TestCase(140, 29, 
            TestName = "Негативный тест установки зависимого параметра чайника с максимальной высотой носика")]
        public void TestGet_BadSpoutHeight(double diameter, double spoutHeight)
        {
            teapotParams.TeaPotDiameter = diameter;
            Assert.Throws<ArgumentException>(() => { teapotParams.TeaPotSpoutHeight = spoutHeight; }, "-");
        }

        [TestCase(94, 
            TestName = "Негативный тест установки параметров чайника с минимальным размером ручки")]
        [TestCase(126, 
            TestName = "Негативный тест установки параметров чайника с максимальным размером ручки")]
        public void TestGet_BadHandleSize(double handleSize)
        {
            Assert.Throws<ArgumentException>(() => { teapotParams.TeaPotHandleSize = handleSize; }, "-");
        }

        [TestCase(11, 
            TestName = "Негативный тест установки параметров чайника с некорректным цветом корпуса")]
        public void TestGet_BadBodyColor(TeaPotParams.TheColor theColor)
        {
            Assert.Throws<ArgumentException>(() => { teapotParams.TeaPotBodyColor = theColor; }, "-");
        }

        [TestCase(12, 
            TestName = "Негативный тест установки параметров чайника с некорректным цветом ручки и носика")]
        public void TestGet_BadValues(TeaPotParams.TheColor theColor1)
        {
            Assert.Throws<ArgumentException>(() => { teapotParams.TeaPotHandleColor = theColor1; }, "-");
        }

        [TestCase(TestName = "Тесты геттеров")]
        public void Test_Getters()
        {
            teapotParams.TeaPotDiameter = 140;
            Assert.AreEqual(140, teapotParams.TeaPotDiameter);

            teapotParams.TeaPotHeight = 200;
            Assert.AreEqual(200, teapotParams.TeaPotHeight);

            teapotParams.TeaPotSpoutLength = 25;
            Assert.AreEqual(25, teapotParams.TeaPotSpoutLength);

            teapotParams.TeaPotSpoutWidth = 20;
            Assert.AreEqual(20, teapotParams.TeaPotSpoutWidth);

            teapotParams.TeaPotSpoutHeight = 20;
            Assert.AreEqual(20, teapotParams.TeaPotSpoutHeight);

            teapotParams.TeaPotHandleSize = 105;
            Assert.AreEqual(105, teapotParams.TeaPotHandleSize);

            teapotParams.TeaPotBodyColor = TeaPotParams.TheColor.Black;
            Assert.AreEqual(TeaPotParams.TheColor.Black, teapotParams.TeaPotBodyColor);

            teapotParams.TeaPotHandleColor = TeaPotParams.TheColor.Black;
            Assert.AreEqual(TeaPotParams.TheColor.Black, teapotParams.TeaPotHandleColor);
        }
    }
}
