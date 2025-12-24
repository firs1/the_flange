using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Models;
using Wrapper;

namespace Flange1
{
    public partial class Form1 : Form
    {
        private Parameters parameters; // объект для хранения и проверки параметров фланца

        /// <summary>
        /// Конструктор главной формы
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            // Инициализация объекта параметров фланца
            parameters = new Parameters();
        }

        /// <summary>
        /// Обработчик события загрузки формы
        /// </summary>
        private void MainForm_Load(object sender, EventArgs e)
        {
            // Метод может быть использован для дополнительной инициализации интерфейса
        }

        // Обработчики кликов по меткам (заглушки - не несут функциональности)
        private void label3_Click(object sender, EventArgs e) { }
        private void label5_Click(object sender, EventArgs e) { }
        private void label6_Click(object sender, EventArgs e) { }

        /// <summary>
        /// Обработчик изменения текста в поле внешнего диаметра (a)
        /// Вычисляет и устанавливает значение диаметра выступа (b) как 75% от a
        /// </summary>
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Парсим значение из textBoxA
            if (double.TryParse(textBoxA.Text, out double a) && a > 0)
            {
                // Вычисляем диаметр выступа по формуле: b = 0.75 * a
                double b = 0.75 * a;
                textBoxB.Text = b.ToString("0.###");  // округление до трех знаков после запятой
                toolTip1.SetToolTip(textBoxB, "Вычислено автоматически: b = 0.75 * a");
            }
            else
            {
                // Если значение некорректно - очищаем поле b
                textBoxB.Text = "";
            }
        }

        /// <summary>
        /// Валидация значения поля с использованием пользовательского правила
        /// </summary>
        /// <typeparam name="T">Тип валидируемого значения</typeparam>
        /// <param name="box">TextBox для валидации</param>
        /// <param name="value">Значение для проверки</param>
        /// <param name="rule">Функция-правило валидации (возвращает сообщение об ошибке или null)</param>
        /// <returns>true если валидация успешна, false если есть ошибки</returns>
        private bool ValidateField<T>(System.Windows.Forms.TextBox box, T value, Func<T, string> rule)
        {
            string error = rule(value);

            if (error != null)
            {
                // Подсвечиваем поле с ошибкой
                box.BackColor = Color.LightPink;
                toolTip1.SetToolTip(box, error);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Парсинг вещественного числа из TextBox с обработкой ошибок
        /// </summary>
        /// <param name="box">TextBox для парсинга</param>
        /// <param name="ok">Флаг успешности операции (передается по ссылке)</param>
        /// <returns>Распарсенное значение или 0 при ошибке</returns>
        private double TryParse(System.Windows.Forms.TextBox box, ref bool ok)
        {
            double val;
            if (!double.TryParse(box.Text, out val))
            {
                // Ошибка парсинга - подсвечиваем поле
                box.BackColor = Color.LightPink;
                toolTip1.SetToolTip(box, "Неверный формат числа");
                ok = false;
            }
            else
            {
                // Парсинг успешен - сбрасываем подсветку
                box.BackColor = Color.White;
                toolTip1.SetToolTip(box, null);
            }
            return val;
        }

        /// <summary>
        /// Парсинг целого числа из TextBox с обработкой ошибок
        /// </summary>
        /// <param name="box">TextBox для парсинга</param>
        /// <param name="ok">Флаг успешности операции (передается по ссылке)</param>
        /// <returns>Распарсенное значение или 0 при ошибке</returns>
        private int TryParseInt(System.Windows.Forms.TextBox box, ref bool ok)
        {
            int val;
            if (!int.TryParse(box.Text, out val))
            {
                // Ошибка парсинга - подсвечиваем поле
                box.BackColor = Color.LightPink;
                toolTip1.SetToolTip(box, "Неверный формат числа");
                ok = false;
            }
            else
            {
                // Парсинг успешен - сбрасываем подсветку
                box.BackColor = Color.White;
                toolTip1.SetToolTip(box, null);
            }
            return val;
        }

        /// <summary>
        /// Обработчик нажатия кнопки проверки и построения модели
        /// Основной метод валидации и обработки данных формы
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            bool ok = true;

            // Этап 1: Парсинг значений из всех полей ввода
            double a = TryParse(textBoxA, ref ok);
            double b = TryParse(textBoxB, ref ok);
            double d = TryParse(textBoxD, ref ok);
            double c = TryParse(textBoxC, ref ok);
            double e_ = TryParse(textBoxE, ref ok);
            int n = TryParseInt(textBoxN, ref ok);

            // Если есть ошибки формата чисел - прерываем выполнение
            if (!ok)
            {
                MessageBox.Show("Исправьте выделенные красным поля.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Этап 2: Валидация бизнес-правил для каждого параметра
            // a: внешний диаметр должен быть в диапазоне (1; 400]
            ok &= ValidateField(textBoxA, a, val => (val > 1 && val <= 400) ? null : "a должно быть в диапазоне (0; 400]");

            // b: диаметр выступа должен быть > 1 и <= 0.75 * a
            ok &= ValidateField(textBoxB, b, val => (val > 1 && val <= 0.75 * a) ? null : "b должно быть <= 0.75 * a");

            // d: высота должна быть в диапазоне (1; 300]
            ok &= ValidateField(textBoxD, d, val => (val > 1 && val <= 300) ? null : "Высота d должна быть в диапазоне (0; 300]");

            // c: толщина должна быть > 1 и < a
            ok &= ValidateField(textBoxC, c, val => (val > 1 && val < a) ? null : "Толщина c должна быть меньше a");

            // e: диаметр отверстий должен быть > 1 и меньше c и a
            ok &= ValidateField(textBoxE, e_, val => (val > 1 && val < c && val < a) ? null : "Диаметр e должен быть < c и < a");

            // n: количество отверстий должно быть в диапазоне 1..8
            ok &= ValidateField(textBoxN, n, val => (val > 0 && val <= 8) ? null : "Количество отверстий n должно быть 1..8");

            // Если есть ошибки валидации - прерываем выполнение
            if (!ok)
            {
                MessageBox.Show("Исправьте выделенные красным поля.", "Ошибки ввода",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Этап 3: Все проверки пройдены - сохраняем значения в объект Parameters
            parameters.OuterDiameter_a = a;
            parameters.ProtrusionDiameter_b = b;
            parameters.Height_d = d;
            parameters.Thickness_c = c;
            parameters.DiameterHoles_e = e_;
            parameters.NumberOfHoles_n = n;

            // Этап 4: Создание и построение 3D-модели через Builder и Wrapper
            Builder builder = new Builder(new Wrapper.Wrapper());
            builder.BuildModel(parameters);
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

  
        private void textBoxB_TextChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }


        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {
    
        }

  
        private void textBoxC_TextChanged(object sender, EventArgs e)
        {
  
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
        }


        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {
        }
    }
}

