using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// Перечисление, определяющее типы параметров фланца.
    /// Используется для идентификации параметров в системе и обеспечения 
    /// типобезопасного доступа к ним через методы GetParameter и SetParameter.
    /// Каждый элемент перечисления соответствует конкретному геометрическому параметру модели.
    /// </summary>
    public enum ParameterType
    {
        HeightD,
        DiameterHolesE,
        HolesAmountN,
        ProtrusionDiameterB,
        OuterDiameterA,
        ThicknessC
    }
}