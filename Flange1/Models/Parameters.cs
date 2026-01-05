using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// Класс для управления параметрами фланца. Хранит параметры в словаре и предоставляет
    /// типизированные свойства для доступа к ним с автоматической валидацией через класс Parameter.
    /// </summary>
    public class Parameters
    {
        private Dictionary<ParameterType, Parameter> _parameters;

        /// <summary>
        /// Инициализирует новый экземпляр класса Parameters со значениями по умолчанию.
        /// Создает словарь параметров с заданными диапазонами допустимых значений.
        /// </summary>
        public Parameters()
        {
            _parameters = new Dictionary<ParameterType, Parameter>()
            {
                // Внешний диаметр (A): от 1 до 400
                { ParameterType.OuterDiameterA,      new Parameter(1, 400) },
                
                // Диаметр выступа (B): от 1 до 300
                { ParameterType.ProtrusionDiameterB, new Parameter(1, 300) },
                
                // Высота (D): от 1 до 300
                { ParameterType.HeightD,             new Parameter(1, 300) },
                
                // Толщина (C): от 1 до 400
                { ParameterType.ThicknessC,          new Parameter(1, 400) },
                
                // Диаметр отверстий (E): от 0.1 до 300
                { ParameterType.DiameterHolesE,      new Parameter(0.1, 100) },
                
                // Количество отверстий (N): от 1 до 8
                { ParameterType.HolesAmountN,        new Parameter(1, 8)  }
            };
        }

        /// <summary>
        /// Устанавливает значение параметра указанного типа.
        /// </summary>
        /// <param name="type">Тип параметра для установки.</param>
        /// <param name="value">Значение параметра.</param>
        /// <exception cref="ArgumentException">
        /// Выбрасывается, если значение выходит за пределы допустимого диапазона для данного параметра.
        /// </exception>
        public void SetParameter(ParameterType type, double value)
        {
            _parameters[type].Value = value;
        }

        /// <summary>
        /// Получает значение параметра указанного типа.
        /// </summary>
        /// <param name="type">Тип параметра для получения.</param>
        /// <returns>Текущее значение параметра.</returns>
        public double GetParameter(ParameterType type)
        {
            return _parameters[type].Value;
        }

        /// <summary>
        /// Внешний диаметр фланца (параметр A).
        /// </summary>
        public double OuterDiameter_a
        {
            get => GetParameter(ParameterType.OuterDiameterA);
            set => SetParameter(ParameterType.OuterDiameterA, value);
        }

        /// <summary>
        /// Диаметр центрального выступа (параметр B).
        /// </summary>
        public double ProtrusionDiameter_b
        {
            get => GetParameter(ParameterType.ProtrusionDiameterB);
            set => SetParameter(ParameterType.ProtrusionDiameterB, value);
        }

        /// <summary>
        /// Высота фланца (параметр D).
        /// </summary>
        public double Height_d
        {
            get => GetParameter(ParameterType.HeightD);
            set => SetParameter(ParameterType.HeightD, value);
        }

        /// <summary>
        /// Толщина фланца (параметр C).
        /// </summary>
        public double Thickness_c
        {
            get => GetParameter(ParameterType.ThicknessC);
            set => SetParameter(ParameterType.ThicknessC, value);
        }

        /// <summary>
        /// Диаметр крепежных отверстий (параметр E).
        /// </summary>
        public double DiameterHoles_e
        {
            get => GetParameter(ParameterType.DiameterHolesE);
            set => SetParameter(ParameterType.DiameterHolesE, value);
        }

        /// <summary>
        /// Количество крепежных отверстий (параметр N).
        /// Преобразует double в int при получении значения.
        /// </summary>
        public int NumberOfHoles_n
        {
            get => (int)GetParameter(ParameterType.HolesAmountN);
            set => SetParameter(ParameterType.HolesAmountN, value);
        }
    }
}