using System;
using System.Windows.Forms;
using TeaPotAPI;
using TeaPotParameters;

namespace TeaPotGUI
{
    public partial class Main : Form
    {
        private KompasConnector kompasConnector;
        private TeaPotParams _teaPotParams;

        public Main()
        {
            InitializeComponent();
            AutoFill();
            //Добавление вариантов цветов в comboBox
            comboBox1.Items.Add(TeaPotParams.TheColor.Red);
            comboBox1.Items.Add(TeaPotParams.TheColor.Blue);
            comboBox1.Items.Add(TeaPotParams.TheColor.HeavenBlue);
            comboBox1.Items.Add(TeaPotParams.TheColor.Green);
            comboBox1.Items.Add(TeaPotParams.TheColor.Orange);
            comboBox1.Items.Add(TeaPotParams.TheColor.Yellow);
            comboBox1.Items.Add(TeaPotParams.TheColor.Purple);
            comboBox1.Items.Add(TeaPotParams.TheColor.Black);

            comboBox2.Items.Add(TeaPotParams.TheColor.Red);
            comboBox2.Items.Add(TeaPotParams.TheColor.Blue);
            comboBox2.Items.Add(TeaPotParams.TheColor.HeavenBlue);
            comboBox2.Items.Add(TeaPotParams.TheColor.Green);
            comboBox2.Items.Add(TeaPotParams.TheColor.Orange);
            comboBox2.Items.Add(TeaPotParams.TheColor.Yellow);
            comboBox2.Items.Add(TeaPotParams.TheColor.Purple);
            comboBox2.Items.Add(TeaPotParams.TheColor.Black);
            //Объявление цветов в comboBox по умолчанию
            comboBox1.SelectedItem = TeaPotParams.TheColor.Orange;
            comboBox2.SelectedItem = TeaPotParams.TheColor.Green;

        }
        /// <summary>
        /// Функция проверки на корректность введенных данных 
        /// </summary>
        private void ColorValidate_Values()
        {
            button1.Enabled = false;
            int Points = 0;

            if ((textBox1.Text == "") || Convert.ToInt32(textBox1.Text) < 100 || (Convert.ToInt32(textBox1.Text)) > 140)
            {
                textBox1.BackColor = System.Drawing.Color.Red;

            }
            else
            {
                textBox1.BackColor = System.Drawing.Color.Green;
                Points++;
            }

            if ((textBox2.Text == "") || Convert.ToInt32(textBox2.Text) < 150 || (Convert.ToInt32(textBox2.Text)) > 200)
            {
                textBox2.BackColor = System.Drawing.Color.Red;

            }
            else
            {
                textBox2.BackColor = System.Drawing.Color.Green;
                Points++;

            }

            if ((textBox3.Text == "") || Convert.ToInt32(textBox3.Text) < 20 || (Convert.ToInt32(textBox3.Text)) > 25)
            {
                textBox3.BackColor = System.Drawing.Color.Red;

            }
            else
            {
                textBox3.BackColor = System.Drawing.Color.Green;
                Points++;
            }

            if ((textBox4.Text == "") || Convert.ToInt32(textBox4.Text) < 95 || (Convert.ToInt32(textBox4.Text)) > 125)
            {
                textBox4.BackColor = System.Drawing.Color.Red;

            }
            else
            {
                textBox4.BackColor = System.Drawing.Color.Green;
                Points++;

            }

            if ((textBox5.Text == "") || Convert.ToInt32(textBox5.Text) < 15 || (Convert.ToInt32(textBox5.Text)) > Convert.ToInt32(textBox1.Text) / 5)
            {
                textBox5.BackColor = System.Drawing.Color.Red;

            }
            else
            {
                textBox5.BackColor = System.Drawing.Color.Green;
                Points++;

            }

            if ((textBox6.Text == "") || Convert.ToInt32(textBox6.Text) < 15 || (Convert.ToInt32(textBox6.Text)) > Convert.ToInt32(textBox1.Text) / 5)
            {
                textBox6.BackColor = System.Drawing.Color.Red;

            }
            else
            {
                textBox6.BackColor = System.Drawing.Color.Green;
                Points++;

            }

            if (Points == 6)
            {
                button1.Enabled = true;
            }
        }

        /// <summary>
        /// Постройка детали при нажатии на кнопку
        /// </summary>
        /// <param name="sender">Ссылка на объект, который поднял событие</param>
        /// <param name="e">Передает объект, специфичный для обрабатываемого события</param>
        private void button1_Click(object sender, EventArgs e)
        {
            _teaPotParams = new TeaPotParams(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox3.Text), Convert.ToInt32(textBox5.Text),
            Convert.ToInt32(textBox6.Text), Convert.ToInt32(textBox4.Text),(TeaPotParams.TheColor)comboBox1.SelectedItem, (TeaPotParams.TheColor)comboBox2.SelectedItem);
            kompasConnector = new KompasConnector(_teaPotParams);
            Builder builder = new Builder();
            builder.Build(kompasConnector.iPart, kompasConnector._kompas, _teaPotParams);   
        }

        /// <summary>
        /// Проверка на корректность введённых данных
        /// </summary>
        /// <param name="sender">Ссылка на объект, который поднял событие</param>
        /// <param name="e">Передает объект, специфичный для обрабатываемого события</param>
        private void textBox_TextChanged(object sender, EventArgs e)
        {
            //Автозамена пустой ячейки на "0". Необходимо для предотвращения ошибки при проверке введенных данных
            if (textBox1.Text == "")
            {
                textBox1.Text = "0";
            }
            ColorValidate_Values();
        }

        /// <summary>
        /// Предотвращение ввода посторонних символов. Вводятся только цифры
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Функция автозаполнения параметров, и ограничитель количества символов
        /// </summary>
        private void AutoFill()
        {
            textBox1.MaxLength = 3;
            textBox2.MaxLength = 3;
            textBox3.MaxLength = 3;
            textBox4.MaxLength = 3;
            textBox5.MaxLength = 3;
            textBox6.MaxLength = 3;
            textBox1.Text = "120";
            textBox2.Text = "175";
            textBox3.Text = "22";
            textBox4.Text = "110";
            textBox5.Text = "20";
            textBox6.Text = "20";
        }
    }
}
