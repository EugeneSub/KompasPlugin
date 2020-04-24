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

        /// <summary>
        /// Позитивные тесты установки параметров чайника
        /// </summary>
        /// <param name="Diameter">Диаметр корпуса</param>
        /// <param name="Height">Высота корпуса</param>
        /// <param name="SpoutLength">Длина носика</param>
        /// <param name="SpoutWidth">Ширина носика</param>
        /// <param name="SpoutHeight">Высота носика</param>
        /// <param name="HandleSize">Размер ручки</param>
        /// <param name="theColor">Цвет корпуса</param>
        /// <param name="theColor1">Цвет ручки и носика</param>
        [Test]
        [TestCase(100,150,20,15,15,95, TeaPotParams.TheColor.Green, TeaPotParams.TheColor.Yellow, TestName = "Позитивный тест установки параметров чайника с минимальными значениями")]
        [TestCase(140,200,25,28,28,125, TeaPotParams.TheColor.Blue, TeaPotParams.TheColor.Red, TestName = "Позитивный тест установки параметров чайника с максимальными значениями")]
        public void TestGet_CorrectValues(double Diameter, double Height, double SpoutLength, double SpoutWidth, double SpoutHeight, double HandleSize, TeaPotParams.TheColor theColor, 
            TeaPotParams.TheColor theColor1)
        { 
            teapotParams.TeaPotDiameter = Diameter;
            teapotParams.TeaPotHeight = Height;
            teapotParams.TeaPotSpoutLength = SpoutLength;
            teapotParams.TeaPotSpoutWidth = SpoutWidth;
            teapotParams.TeaPotSpoutHeight = SpoutHeight;
            teapotParams.TeaPotHandleSize = HandleSize;
            teapotParams.TeaPotBodyColor = theColor;
            teapotParams.TeaPotHandleColor = theColor1;
        }

        /// <summary>
        /// Негативные тесты установки параметров чайника
        /// </summary>
        /// <param name="Diameter">Диаметр корпуса</param>
        /// <param name="Height">Высота корпуса</param>
        /// <param name="SpoutLength">Длина носика</param>
        /// <param name="SpoutWidth">Ширина носика</param>
        /// <param name="SpoutHeight">Высота носика</param>
        /// <param name="HandleSize">Размер ручки</param>
        /// <param name="theColor">Цвет корпуса</param>
        /// <param name="theColor1">Цвет ручки и носика</param>
        [TestCase(99, 149, 19, 14, 14, 94, 11, 12, TestName = "Негативный тест установки параметров чайника с минимальными значениями - 1")]
        [TestCase(141, 201, 26, 29, 29, 126, 12, 34, TestName = "Негативный тест установки параметров чайника с минимальными значениями + 1")]
        public void TestGet_BadValues(double Diameter, double Height, double SpoutLength, double SpoutWidth, double SpoutHeight, double HandleSize, TeaPotParams.TheColor theColor, 
            TeaPotParams.TheColor theColor1)
        {
            Assert.Throws<ArgumentException>(() => { teapotParams.TeaPotDiameter = Diameter; }, "-");
            Assert.Throws<ArgumentException>(() => { teapotParams.TeaPotHeight = Height; }, "-");
            Assert.Throws<ArgumentException>(() => { teapotParams.TeaPotSpoutLength = SpoutLength; }, "-");
            Assert.Throws<ArgumentException>(() => { teapotParams.TeaPotSpoutLength = SpoutWidth; }, "-");
            Assert.Throws<ArgumentException>(() => { teapotParams.TeaPotSpoutLength = SpoutHeight; }, "-");
            Assert.Throws<ArgumentException>(() => { teapotParams.TeaPotHandleSize = HandleSize; }, "-");
            Assert.Throws<ArgumentException>(() => { teapotParams.TeaPotBodyColor = theColor; }, "-");
            Assert.Throws<ArgumentException>(() => { teapotParams.TeaPotHandleColor = theColor1; }, "-");
        }
    }
}
