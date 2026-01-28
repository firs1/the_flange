using System;
using System.Collections.Generic;
using System.Drawing;

namespace Models
{
    /// <summary>
    /// Хранение и бизнес-валидация параметров фланца
    /// Включает логику для работы с параметрами фланца, 
    /// их валидации и обработки ограничений.
    /// </summary>
    public class Parameters
    {
        /// <summary>
        /// Коллекция параметров фланца, сгруппированных по типу.
        /// Используется для централизованного хранения значений
        /// и выполнения проверок корректности.
        /// </summary>
        private readonly Dictionary<ParameterType, Parameter> _parameters;

        /// </summary>
        /// Конструктор класса Parameters, который инициализирует 
        /// словарь с параметрами фланца
        /// </summary>
        public Parameters()
        {
            _parameters = new Dictionary<ParameterType, Parameter>
            {
                { ParameterType.OuterDiameter,      new Parameter(2, 400) },
                { ParameterType.ProtrusionDiameter, new Parameter(1, 300) },
                { ParameterType.Height,             new Parameter(2, 300) },
                { ParameterType.Thickness,          new Parameter(1, 400) },
                { ParameterType.DiameterHoles,      new Parameter(0.1, 300) },
                { ParameterType.HolesAmount,        new Parameter(1, 8) },
                { ParameterType.HoleStep,           new Parameter(0, 130) }
            };
        }

        /// </summary>
        /// Свойство для работы с шагом отверстий
        /// </summary>
        public double HoleStep
        {
            get => GetParameter(ParameterType.HoleStep);
            set
            {
  
                if (value == 0)
                {
                    value = 360.0 / NumberOfHoles_n;
                }

                SetParameter(ParameterType.HoleStep, value);
            }
        }

        /// </summary>
        /// Метод для использования в стресс тестах
        /// </summary>
        public IReadOnlyDictionary<ParameterType, Parameter> GetAll()
        {
            return _parameters;
        }

        /// </summary>
        /// Метод для проверки шагов отверстий в 
        /// зависимости от количества отверстий
        /// </summary>
        public void ValidateStep()
        {
            //TODO: {}
            //TODO: to const
            if (NumberOfHoles_n == 8 && HoleStep != 0)
                throw new InvalidOperationException(
                    "Для 8 отверстий шаг не может быть задан.");

            double maxStep = 360.0 / NumberOfHoles_n;

            //TODO: {}
            if (HoleStep > maxStep)
                throw new ArgumentOutOfRangeException(
                    nameof(HoleStep),
                    $"Шаг не может быть больше {maxStep} для заданного количества отверстий.");
        }

        #region Base access

        /// <summary>
        /// Устанавливает значение параметра по его типу.
        /// </summary>
        /// <param name="type">Тип параметра.</param>
        /// <param name="value">Новое значение параметра.</param>
        public void SetParameter(ParameterType type, double value)
        {
            _parameters[type].Value = value;
        }

        /// <summary>
        /// Возвращает значение параметра по его типу.
        /// </summary>
        /// <param name="type">Тип параметра.</param>
        /// <returns>Текущее значение параметра.</returns>
        public double GetParameter(ParameterType type)
        {
            return _parameters[type].Value;
        }

        #endregion

        #region Strongly typed properties

        /// <summary>
        /// Наружный диаметр фланца.
        /// </summary>
        public double OuterDiameter_a
        {
            get => GetParameter(ParameterType.OuterDiameter);
            set => SetParameter(ParameterType.OuterDiameter, value);
        }

        /// <summary>
        /// Диаметр выступа фланца.
        /// </summary>
        public double ProtrusionDiameter_b
        {
            get => GetParameter(ParameterType.ProtrusionDiameter);
            set => SetParameter(ParameterType.ProtrusionDiameter, value);
        }

        /// <summary>
        /// Высота фланца.
        /// </summary>
        public double Height_d
        {
            get => GetParameter(ParameterType.Height);
            set => SetParameter(ParameterType.Height, value);
        }

        /// <summary>
        /// Толщина фланца.
        /// </summary>
        public double Thickness_c
        {
            get => GetParameter(ParameterType.Thickness);
            set => SetParameter(ParameterType.Thickness, value);
        }

        /// <summary>
        /// Диаметр отверстий.
        /// </summary>
        public double DiameterHoles_e
        {
            get => GetParameter(ParameterType.DiameterHoles);
            set => SetParameter(ParameterType.DiameterHoles, value);
        }

        /// <summary>
        /// Количество отверстий.
        /// </summary>
        public int NumberOfHoles_n
        {
            get => (int)GetParameter(ParameterType.HolesAmount);
            set => SetParameter(ParameterType.HolesAmount, value);
        }

        /// <summary>
        /// Угловой шаг между отверстиями.
        /// </summary>
        public int HoleStep_h
        {
            get => (int)GetParameter(ParameterType.HoleStep);
            set => SetParameter(ParameterType.HoleStep, value);
        }

        #endregion

        #region Derived constraints

        /// <summary>
        /// Максимально допустимый диаметр отверстий,
        /// вычисляемый на основе наружного диаметра и диаметра выступа.
        /// </summary>
        
        public double MaxHoleDiameter =>
            (OuterDiameter_a - ProtrusionDiameter_b) * 0.45;

        #endregion


        #region Validation

        /// <summary>
        /// Проверка взаимных ограничений параметров
        /// </summary>
        public Dictionary<ParameterType, string> Validate()
        {
            var errors = new Dictionary<ParameterType, string>();

            foreach (var pair in _parameters)
            {
                var type = pair.Key;
                var param = pair.Value;

                if (param.Value < param.Min || param.Value > param.Max)
                {
                    errors[type] =
                        $"Значение должно быть в диапазоне [{param.Min}; " +
                        $"{param.Max}]";
                }
            }

            double AcceptableSize = 0.75;
            if (ProtrusionDiameter_b > AcceptableSize * OuterDiameter_a)
            {
                errors[ParameterType.ProtrusionDiameter] =
                    "Диаметр выступа B должен быть ≤ 0.75 * A";
            }

            if (Thickness_c >= OuterDiameter_a)
            { 
            errors[ParameterType.Thickness] =
                "Толщина C должна быть меньше A";
            }

            if (DiameterHoles_e > MaxHoleDiameter)
            {
                errors[ParameterType.DiameterHoles] =
                    $"Диаметр отверстий E должен быть ≤ {MaxHoleDiameter:F2}";
            }

            double maxStep = 360.0 / NumberOfHoles_n;
            if (HoleStep_h <= 0 || HoleStep_h > maxStep)
            {
                errors[ParameterType.HoleStep] =
                    $"Шаг отверстий должен быть в пределах от" +
                    $" 0 до {maxStep} градусов для {NumberOfHoles_n:F2} " +
                    $"отверстий.";
            }

            return errors;
        }

        #endregion
    }
}