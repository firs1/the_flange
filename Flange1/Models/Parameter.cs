namespace Models
{
    /// <summary>
    /// Класс, представляющий параметр с допустимым диапазоном значений.
    /// Хранит границы и текущее значение.
    /// </summary>
    public class Parameter
    {
        /// <summary>
        /// Минимально допустимое значение параметра.
        /// </summary>
        private double _min;

        /// <summary>
        /// Максимально допустимое значение параметра.
        /// </summary>
        private double _max;

        /// <summary>
        /// Текущее значение параметра.
        /// </summary>
        private double _value;

        /// <summary>
        /// Инициализирует параметр с заданными 
        /// границами и начальным значением.
        /// </summary>
        /// <param name="min">Минимальное допустимое значение</param>
        /// <param name="max">Максимальное допустимое значение</param>
        /// <param name="value">Начальное значение</param>
        public Parameter(double min, double max, double? value = null)
        {
            //TODO: {}
            if (min > max)
                throw new ArgumentException("Минимальное значение не может быть больше максимального.");

            _min = min;
            _max = max;

            _value = value ?? min;
        }

        /// <summary>
        /// Текущее значение параметра.
        /// Не удалось сделать тут валидацию, выскакивают множество ошибок,
        /// в том числе и невозможности сделать юнит тесты.
        /// </summary>
        public double Value
        {
            get => _value;
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