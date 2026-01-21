using System;
using System.Collections.Generic;

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
        /// Метод для проверки шагов отверстий в 
        /// зависимости от количества отверстий
        /// </summary>
        public void ValidateStep()
        {
            if (NumberOfHoles_n == 8 && HoleStep != 0)
            {
                throw new InvalidOperationException("Для 8 отверстий" +
                    " шаг не может быть задан.");
            }

            if (HoleStep > 130)
            {
                throw new ArgumentOutOfRangeException(nameof(HoleStep), 
                    "Шаг не может превышать 130 градусов.");
            }

            double maxStep = 360.0 / NumberOfHoles_n;
            if (HoleStep > maxStep)
            {
                throw new ArgumentOutOfRangeException(nameof(HoleStep),
                    $"Шаг не может быть больше {maxStep} для заданного " +
                    $"количества отверстий.");
            }
        }

        #region Base access

        //TODO: XML
        public void SetParameter(ParameterType type, double value)
        {
            _parameters[type].Value = value;
        }


        //TODO: XML
        public double GetParameter(ParameterType type)
        {
            return _parameters[type].Value;
        }

        #endregion

        #region Strongly typed properties

        //TODO: XML
        public double OuterDiameter_a
        {
            get => GetParameter(ParameterType.OuterDiameter);
            set => SetParameter(ParameterType.OuterDiameter, value);
        }

        //TODO: XML
        public double ProtrusionDiameter_b
        {
            get => GetParameter(ParameterType.ProtrusionDiameter);
            set => SetParameter(ParameterType.ProtrusionDiameter, value);
        }

        //TODO: XML
        public double Height_d
        {
            get => GetParameter(ParameterType.Height);
            set => SetParameter(ParameterType.Height, value);
        }

        //TODO: XML
        public double Thickness_c
        {
            get => GetParameter(ParameterType.Thickness);
            set => SetParameter(ParameterType.Thickness, value);
        }

        //TODO: XML
        public double DiameterHoles_e
        {
            get => GetParameter(ParameterType.DiameterHoles);
            set => SetParameter(ParameterType.DiameterHoles, value);
        }

        //TODO: XML
        public int NumberOfHoles_n
        {
            get => (int)GetParameter(ParameterType.HolesAmount);
            set => SetParameter(ParameterType.HolesAmount, value);
        }

        //TODO: XML
        public int HoleStep_h
        {
            get => (int)GetParameter(ParameterType.HoleStep);
            set => SetParameter(ParameterType.HoleStep, value);
        }
        #endregion

        #region Derived constraints

        //TODO: XML
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

            //TODO: {}
            //TODO: to const
            if (ProtrusionDiameter_b > 0.75 * OuterDiameter_a)
                errors[ParameterType.ProtrusionDiameter] =
                    "Диаметр выступа B должен быть ≤ 0.75 * A";

            //TODO: {}
            if (Thickness_c >= OuterDiameter_a)
                errors[ParameterType.Thickness] =
                    "Толщина C должна быть меньше A";

            //TODO: {}
            if (DiameterHoles_e > MaxHoleDiameter)
                errors[ParameterType.DiameterHoles] =
                    $"Диаметр отверстий E должен быть ≤ {MaxHoleDiameter:F2}";

            double maxStep = 360.0 / NumberOfHoles_n;
            if (HoleStep_h <= 0 || HoleStep_h > maxStep)
            {
                errors[ParameterType.HoleStep] =
                    $"Шаг отверстий должен быть в пределах от" +
                    $" 0 до {maxStep} градусов для {NumberOfHoles_n} " +
                    $"отверстий.";
            }

            return errors;
        }

        #endregion
    }
}