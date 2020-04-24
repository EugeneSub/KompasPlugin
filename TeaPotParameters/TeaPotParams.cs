using System;


namespace TeaPotParameters
{
    /// <summary>
    /// Класс, в котором хранятся параметры чайника
    /// </summary>
   public class TeaPotParams
    {
        private double _radius;
        private double _height;
        private double _spoutLength;
        private double _spoutWidth;
        private double _spoutHeight;
        private double _handleSize;
        private TheColor _bodyColor;
        private TheColor _handleColor;

        /// <summary>
        /// Перечисление, в котором хранятся цвета чайника
        /// </summary>
        public enum TheColor
        {
            Red = 100,
            Blue = 8000000,
            HeavenBlue = 12345678,
            Green = 20000,
            Orange = 80000,
            Yellow = 100000,
            Purple = 105000010,
            Black = 10
        }

        /// <summary>
        /// Конструктор класса TeaPotParams
        /// </summary>
        /// <param name="teapotDiameter">Диаметр корпуса чайника</param>
        /// <param name="teapotHeight">Высота корпуса чайника</param>
        /// <param name="teapotSpoutLength">Длина носика</param>
        /// <param name="teapotSpoutWidth">Ширина носика</param>
        /// <param name="teapotSpoutHeight">Высота носика</param>
        /// <param name="teapotHandleSize">Размер ручки</param>
        /// <param name="teapotbodycolor">Цвет корпуса</param>
        /// <param name="teapothandlecolor">Цвет ручки</param>
        public TeaPotParams(double teapotDiameter, double teapotHeight, double teapotSpoutLength, double teapotSpoutWidth, double teapotSpoutHeight, double teapotHandleSize, 
            TheColor teapotbodycolor, TheColor teapothandlecolor)
        {
            TeaPotDiameter = teapotDiameter;
            TeaPotHeight = teapotHeight;
            TeaPotSpoutLength = teapotSpoutLength;
            TeaPotSpoutWidth = teapotSpoutWidth;
            TeaPotSpoutHeight = teapotSpoutHeight;
            TeaPotHandleSize = teapotHandleSize;
            TeaPotBodyColor = teapotbodycolor;
            TeaPotHandleColor = teapothandlecolor;
        }

        /// <summary>
        /// Пустой конструктор. Необходим для модульных тестов
        /// </summary>
        public TeaPotParams()
        {

        }

        /// <summary>
        /// Свойства диаметра корпуса чайника
        /// </summary>
        public double TeaPotDiameter 
        {
            get => _radius;
            set
            {
                CheckValue(value, 100, 140);
                _radius = value;
            }
        }

        /// <summary>
        /// Свойства высоты корпуса чайника
        /// </summary>
        public double TeaPotHeight 
        {
            get => _height;
            set
            {
                CheckValue(value, 150, 200);
                _height = value;
            }
        }

        /// <summary>
        /// Свойства длины носика
        /// </summary>
        public double TeaPotSpoutLength 
        {
            get => _spoutLength;
            set
            {
                CheckValue(value, 20, 25);
                _spoutLength = value;
            }
        }

        /// <summary>
        /// Свойства ширины носика
        /// </summary>
        public double TeaPotSpoutWidth
        {
            get => _spoutWidth;
            set
            {
                CheckValue(value, 15, TeaPotDiameter/5);
                _spoutWidth = value;
            }
        }

        /// <summary>
        /// Свойства высоты носика
        /// </summary>
        public double TeaPotSpoutHeight
        {
            get => _spoutHeight;
            set
            {
                CheckValue(value, 15, TeaPotDiameter / 5);
                _spoutHeight = value;
            }
        }

        /// <summary>
        /// Свойства размера ручки
        /// </summary>
        public double TeaPotHandleSize
        {
            get => _handleSize;
            set
            {
                CheckValue(value, 95, 125);
                _handleSize = value;
            }
        }

        /// <summary>
        /// Свойства цвета корпуса
        /// </summary>
        public TheColor TeaPotBodyColor
        {
            get
            {
                return _bodyColor;
            }
            set
            {
                CheckColor(value);
                _bodyColor = value;
            }
        }

        /// <summary>
        /// Свойства цвета ручки и носика
        /// </summary>
        public TheColor TeaPotHandleColor
        {
            get
            {
                return _handleColor;
            }
            set
            {
                CheckColor(value);
                _handleColor = value;
            }
        }
    
        /// <summary>
        /// Проверка на корректность ввода цвета
        /// </summary>
        /// <param name="value"></param>
        public void CheckColor(TeaPotParams.TheColor value)
        {
            if (value != TheColor.Black && value != TheColor.Blue && value != TheColor.Green && value != TheColor.HeavenBlue && value != TheColor.Orange && value != TheColor.Purple 
                && value != TheColor.Red && value != TheColor.Yellow)
            {
                throw new ArgumentException("Неверный цвет");
            }
                
        }

        /// <summary>
        /// Проверка на корректность ввода значения параметров
        /// </summary>
        /// <param name="value"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void CheckValue(double value, double x, double y)
        {
            if (value < x || value > y)
            {
                throw new ArgumentException("Значение должно находится в диапазоне!");
            }
        }
    }
}
