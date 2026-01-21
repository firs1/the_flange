namespace Models
{
    /// <summary>
    /// Класс, представляющий параметр с допустимым диапазоном значений.
    /// Хранит границы и текущее значение.
    /// </summary>
    public class Parameter
    {
        //TODO: XML
        private double _min;   // Минимально допустимое значение
        private double _max;   // Максимально допустимое значение
        private double _value;          // Текущее значение

        /// <summary>
        /// Инициализирует параметр с заданными 
        /// границами и начальным значением.
        /// </summary>
        /// <param name="min">Минимальное допустимое значение</param>
        /// <param name="max">Максимальное допустимое значение</param>
        /// <param name="value">Начальное значение</param>
        public Parameter(double min, double max, double value = 0)
        {
            //TODO: validation
            _min = min;
            _max = max;
            _value = value;
        }

        /// <summary>
        /// Текущее значение параметра.
        /// </summary>
        public double Value
        {
            get => _value;
            //TODO: validation
            set => _value = value;
        }

        /// <summary>
        /// Минимально допустимое значение
        /// </summary>
        public double Min => _min;

        /// <summary>
        /// Максимально допустимое значение
        /// </summary>
        public double Max => _max;
    }
}