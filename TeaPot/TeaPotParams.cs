using System;


namespace TeaPot
{
   public class TeaPotParams
    {
        private int _radius;
        private int _height;
        private int _spoutLength;
        private int _handleSize;
        private TheColor _bodyColor;
        private TheColor _handleColor;

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

        public TeaPotParams(int teapotDiameter, int teapotHeight, int teapotSpoutLength, int teapotHandleSize,
            TheColor teapotbodycolor, TheColor teapothandlecolor)
        {
            TeaPotDiameter = teapotDiameter;
            TeaPotHeight = teapotHeight;
            TeaPotSpoutLength = teapotSpoutLength;
            TeaPotHandleSize = teapotHandleSize;
            TeaPotBodyColor = teapotbodycolor;
            TeaPotHandleColor = teapothandlecolor;
        }



        public int TeaPotDiameter 
        {
            get => _radius;
            set
            {
                if (value < 100 || value > 140)
                {
                    throw new ArgumentException("Значение должно находиться в диапазоне от 100 до 150");
                }

                _radius = value;
            }
        }
        public int TeaPotHeight 
        {
            get => _height;
            set
            {
                if (value < 150 || value > 200)
                {
                    throw new ArgumentException("Значение должно находится в диапазоне от 150 до 200");
                }

                _height = value;
            }
        }
        public int TeaPotSpoutLength 
        {
            get => _spoutLength;
            set
            {
                if (value < 20 || value > 25)
                {
                   throw new ArgumentException("Значение должно находится в диапазоне от 10 до 20");
                }

                _spoutLength = value;
            }
        }

        public int TeaPotHandleSize
        {
            get => _handleSize;
            set
            {
                if (value < 95 || value > 125)
                {
                    throw new ArgumentException("Значение должно находится в диапазоне от 95 до 125");
                }

                _handleSize = value;
            }
        }
        public TheColor TeaPotBodyColor
        {
            get
            {
                return _bodyColor;
            }
            set
            {
                _bodyColor = value;
            }
        }
        public TheColor TeaPotHandleColor
        {
            get
            {
                return _handleColor;
            }
            set
            {
                _handleColor = value;
            }
        }
    }
}
