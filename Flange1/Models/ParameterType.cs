namespace Models
{
    /// <summary>
    /// Имена параметров фланца.
    /// </summary>
    public enum ParameterType
    {
        Height,                 // Высота фланца.
        DiameterHoles,          // Диаметр отверстий.
        HolesAmount,            // Количество отверстий.
        ProtrusionDiameter,     // Диаметр выступа фланца.
        OuterDiameter,          // Наружный диаметр фланца.
        Thickness,              // Толщина фланца.
        HoleStep                // Угловой шаг между отверстиями, в градусах.
    }
}