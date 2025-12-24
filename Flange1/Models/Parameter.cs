namespace Models
{
    /// <summary>
    /// Класс, представляющий параметр с диапазоном допустимых значений.
    /// Обеспечивает валидацию устанавливаемого значения и хранение минимального и максимального допустимых значений.
    /// </summary>
    public class Parameter
    {
        private double _max; // Максимальное допустимое значение
        private double _min; // Минимальное допустимое значение
        private double _value; // Текущее значение параметра

        /// <summary>
        /// Инициализирует новый экземпляр параметра с указанными границами и начальным значением.
        /// </summary>
        /// <param name="min">Минимальное допустимое значение параметра.</param>
        /// <param name="max">Максимальное допустимое значение параметра.</param>
        /// <param name="value">Начальное значение параметра (по умолчанию 0).</param>
        public Parameter(double min, double max, double value = 0)
        {
            _min = min;
            _max = max;
            _value = value;
        }

        /// <summary>
        /// Текущее значение параметра. При установке значения выполняется проверка на соответствие допустимому диапазону.
        /// </summary>
        /// <exception cref="ArgumentException">Выбрасывается, если устанавливаемое значение выходит за пределы диапазона [Min; Max].</exception>
        public double Value
        {
            get => _value; // Возвращает текущее значение
            set
            {
                // Проверка, что значение находится в допустимом диапазоне
                if (value < _min || value > _max)
                    throw new ArgumentException($"Значение должно быть в диапазоне [{_min}; {_max}]");

                _value = value; // Устанавливаем значение, если проверка пройдена
            }
        }

        /// <summary>
        /// Максимальное допустимое значение параметра.
        /// </summary>
        public double Max => _max;

        /// <summary>
        /// Минимальное допустимое значение параметра.
        /// </summary>
        public double Min => _min;
    }
}