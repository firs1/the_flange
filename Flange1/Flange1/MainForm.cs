using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Models;
using Wrapper;

namespace Flange1
{
    /// <summary>
    /// Главная форма приложения.
    /// Отвечает за ввод параметров фланца, их валидацию
    /// и запуск построения 3D-модели.
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Объект бизнес-модели параметров фланца.
        /// Содержит значения и правила их валидации.
        /// </summary>
        private Parameters _parameters;

        /// <summary>
        /// Сопоставление типов параметров и элементов ввода формы.
        /// Используется для унифицированной подсветки и вывода ошибок.
        /// </summary>
        private Dictionary<ParameterType, TextBox> _fieldMap;

        /// <summary>
        /// Конструктор главной формы.
        /// Инициализирует модель параметров и связывает поля ввода
        /// с соответствующими типами параметров.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            _parameters = new Parameters();

            _fieldMap = new Dictionary<ParameterType, TextBox>
            {
                { ParameterType.OuterDiameter, OuterDiameter },
                { ParameterType.ProtrusionDiameter, ProtrusionDiameter },
                { ParameterType.Height, Height },
                { ParameterType.Thickness, Thickness },
                { ParameterType.DiameterHoles, DiameterHoles },
                { ParameterType.HolesAmount, HolesAmount },
                { ParameterType.HoleStep, Step }
            };
        }

        /// <summary>
        /// Сбрасывает визуальные признаки ошибок валидации
        /// (цвет фона и всплывающие подсказки).
        /// </summary>
        private void ClearValidation()
        {
            foreach (var box in _fieldMap.Values)
            {
                box.BackColor = Color.White;
                toolTip.SetToolTip(box, null);
            }
        }

        /// <summary>
        /// Пытается считать вещественное число из текстового поля.
        /// </summary>
        /// <param name="box">Поле ввода.</param>
        /// <param name="success">
        /// Флаг успешности парсинга (передаётся по ссылке).
        /// </param>
        /// <returns>
        /// Считанное значение либо 0 при ошибке.
        /// </returns>
        private double ParseDouble(TextBox box, ref bool success)
        {
            if (!double.TryParse(box.Text, out double value))
            {
                box.BackColor = Color.LightPink;
                toolTip.SetToolTip(box, "Введите число");
                success = false;
                return 0;
            }

            return value;
        }

        /// <summary>
        /// Пытается считать целое число из текстового поля.
        /// </summary>
        /// <param name="box">Поле ввода.</param>
        /// <param name="success">
        /// Флаг успешности парсинга (передаётся по ссылке).
        /// </param>
        /// <returns>
        /// Считанное значение либо 0 при ошибке.
        /// </returns>
        private int ParseInt(TextBox box, ref bool success)
        {
            if (!int.TryParse(box.Text, out int value))
            {
                box.BackColor = Color.LightPink;
                toolTip.SetToolTip(box, "Введите целое число");
                success = false;
                return 0;
            }

            return value;
        }

        /// <summary>
        /// Отображает ошибки бизнес-валидации параметров
        /// в соответствующих полях формы.
        /// </summary>
        /// <param name="errors">
        /// Словарь ошибок, где ключ — тип параметра,
        /// значение — текст сообщения об ошибке.
        /// </param>
        private void ShowParameterErrors(Dictionary<ParameterType, string> errors)
        {
            foreach (var err in errors)
            {
                if (_fieldMap.TryGetValue(err.Key, out var box))
                {
                    box.BackColor = Color.LightPink;
                    toolTip.SetToolTip(box, err.Value);
                }
            }
        }

        /// <summary>
        /// Обработчик изменения внешнего диаметра.
        /// Автоматически рассчитывает диаметр выступа
        /// как 75% от внешнего диаметра.
        /// </summary>
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(OuterDiameter.Text, out double a) && a > 0)
            {
                double c = a * 0.75;
                ProtrusionDiameter.Text = c.ToString("0.##");
            }
            else
            {
                ProtrusionDiameter.Text = string.Empty;
            }
        }

        /// <summary>
        /// Обработчик нажатия кнопки построения модели.
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            ClearValidation();

            bool parseSuccess = true;

            double a = ParseDouble(OuterDiameter, ref parseSuccess);
            double b = ParseDouble(ProtrusionDiameter, ref parseSuccess);
            double d = ParseDouble(Height, ref parseSuccess);
            double c = ParseDouble(Thickness, ref parseSuccess);
            double f = ParseDouble(DiameterHoles, ref parseSuccess);
            int n = ParseInt(HolesAmount, ref parseSuccess);
            double step = ParseDouble(Step, ref parseSuccess);

            if (!parseSuccess)
            {
                MessageBox.Show(
                    "Исправьте ошибки ввода.",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            // Передача значений в бизнес-модель
            _parameters.OuterDiameter_a = a;
            _parameters.ProtrusionDiameter_b = b;
            _parameters.Height_d = d;
            _parameters.Thickness_c = c;
            _parameters.DiameterHoles_e = f;
            _parameters.NumberOfHoles_n = n;
            _parameters.HoleStep = step;

            var validationErrors = _parameters.Validate();

            if (validationErrors.Any())
            {
                ShowParameterErrors(validationErrors);

                MessageBox.Show(
                    "Некорректные параметры.\nИсправьте выделенные поля.",
                    "Ошибка параметров",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            // Построение 3D-модели фланца
            var builder = new Builder(new Wrapper.Wrapper());
            builder.BuildModel(_parameters);
        }

        #region Пустые обработчики

        //TODO: remove
        private void label3_Click(object sender, EventArgs e) { }
        private void label5_Click(object sender, EventArgs e) { }
        private void label6_Click(object sender, EventArgs e) { }
        private void label16_Click(object sender, EventArgs e) { }
        private void label12_Click(object sender, EventArgs e) { }
        private void textBoxB_TextChanged(object sender, EventArgs e) { }
        private void textBox6_TextChanged(object sender, EventArgs e) { }
        private void textBoxC_TextChanged(object sender, EventArgs e) { }
        private void textBox_TextChanged(object sender, EventArgs e) { }
        private void textBoxE_TextChanged(object sender, EventArgs e) { }
        private void textBoxN_TextChanged(object sender, EventArgs e) { }
        private void groupBox1_Enter(object sender, EventArgs e) { }
        private void groupBox2_Enter(object sender, EventArgs e) { }
        private void label17_Click(object sender, EventArgs e) { }

        #endregion

        /// <summary>
        /// Флаг защиты от рекурсивного изменения текста
        /// при автоматическом пересчёте шага отверстий.
        /// </summary>
        private bool _isTextChanging = false;

        /// <summary>
        /// Обработчик изменения количества отверстий.
        /// Автоматически рассчитывает угловой шаг
        /// как 360 / N.
        /// </summary>
        private void HolesAmount_TextChanged(object sender, EventArgs e)
        {
            if (_isTextChanging)
                return;

            if (double.TryParse(HolesAmount.Text, out double n) && n > 0)
            {
                _isTextChanging = true;

                double step = 360 / n;
                Step.Text = step.ToString("0.#");

                _isTextChanging = false;
            }
            else
            {
                HolesAmount.Text = string.Empty;
            }
        }
    }
}
