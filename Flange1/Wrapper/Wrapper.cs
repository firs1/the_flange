using System;
using Kompas6API5;
using Kompas6Constants3D;

namespace Wrapper
{
    /// <summary>
    /// Класс-обертка для работы с API КОМПАС-3D.
    /// Предоставляет методы для запуска КОМПАС, создания документов 
    /// и построения геометрических элементов.
    /// </summary>
    public class Wrapper
    {
        /// <summary>
        /// Экземпляр приложения КОМПАС-3D.
        /// Может быть <c>null</c>, если приложение не запущено
        /// или подключение не было выполнено.
        /// </summary>
        private KompasObject? _kompas;

        //TODO: XML
        public double HoleStep { get; set; } = 0;

        /// <summary>
        /// Подключается к запущенному экземпляру КОМПАС-3D 
        /// или запускает новый.
        /// </summary>
        /// <exception cref="Exception">Выбрасывается при 
        /// невозможности подключения или запуска КОМПАС.</exception>
        public void AttachOrRunCAD()
        {
            var type = Type.GetTypeFromProgID("KOMPAS.Application.5");

            if (type == null)
            {
                throw new Exception("Не удалось получить ProgID KOMPАС.");
            }

            _kompas = Activator.CreateInstance(type) as KompasObject;

            if (_kompas == null)
            {
                throw new Exception("Компас не удалось запустить.");
            }

            _kompas.Visible = true;
        }

        /// <summary>
        /// Создает новый 3D-документ в КОМПАС-3D.
        /// </summary>
        /// <returns>Созданный 3D-документ.</returns>
        public ksDocument3D CreateDocument3D()
        {
            ksDocument3D doc = (ksDocument3D)_kompas!.Document3D();
            doc.Create(false, true);
            return doc;
        }

        /// <summary>
        /// Получает корневую деталь из 3D-документа.
        /// </summary>
        /// <param name="doc">3D-документ КОМПАС-3D.</param>
        /// <returns>Корневая деталь документа.</returns>
        public ksPart GetPart(ksDocument3D doc)
        {
            return (ksPart)doc.GetPart((short)Part_Type.pTop_Part);
        }

        /// <summary>
        /// Создаёт базовый цилиндр путём выдавливания эскиза окружности.
        /// </summary>
        /// <param name="part">Деталь КОМПАС-3D, в которой 
        /// создаётся цилиндр.</param>
        /// <param name="diameter">Диаметр цилиндра.</param>
        /// <param name="height">Высота цилиндра.</param>
        /// <remarks>
        /// Метод создаёт эскиз окружности в плоскости XOY
        /// и выполняет базовое выдавливание на заданную высоту.
        /// </remarks>
        public void CreateBaseCylinder(
            ksPart part, double diameter, double height)
        {
            var entity = 
                (ksEntity)part.NewEntity((short)Obj3dType.o3d_baseExtrusion);
            var def = 
                (ksBaseExtrusionDefinition)entity.GetDefinition();

            // Задаём параметры выдавливания
            def.SetSideParam(true, 0, height);

            // Создаём эскиз в плоскости XOY
            var sketch = 
                (ksEntity)part.NewEntity((short)Obj3dType.o3d_sketch);
            var sketchDef = 
                (ksSketchDefinition)sketch.GetDefinition();
            sketchDef.SetPlane(part.GetDefaultEntity((short)Obj3dType.o3d_planeXOY));
            sketch.Create();

            // Рисуем окружность с радиусом diameter / 2
            var doc2d = (ksDocument2D)sketchDef.BeginEdit();
            doc2d.ksCircle(0, 0, diameter / 2, 1);
            sketchDef.EndEdit();

            def.SetSketch(sketch);
            entity.Create();
        }


        /// <summary>
        /// Создает плоскость смещения от базовой плоскости.
        /// </summary>
        /// <param name="part">Деталь, в которой создается плоскость.</param>
        /// <param name="offset">Величина смещения 
        /// от базовой плоскости.</param>
        /// <returns>Созданная плоскость смещения.</returns>
        public ksEntity CreateOffsetPlane(ksPart part, double offset)
        {
            var plane =
                (ksEntity)part.NewEntity((short)Obj3dType.o3d_planeOffset);
            var def =
                (ksPlaneOffsetDefinition)plane.GetDefinition();

            def.SetPlane
                (part.GetDefaultEntity((short)Obj3dType.o3d_planeXOY));
            def.offset = offset;
            def.direction = true;

            plane.Create();
            return plane;
        }

        /// <summary>
        /// Создает цилиндр на указанной плоскости (для буртика фланца).
        /// </summary>
        /// <param name="part">Деталь, в которой создается цилиндр.</param>
        /// <param name="plane">Плоскость для построения цилиндра.</param>
        /// <param name="diameter">Диаметр цилиндра.</param>
        /// <param name="height">Высота цилиндра.</param>
        public void CreateCylinderOnPlane(
            ksPart part,
            ksEntity plane,
            double diameter,
            double height)
        {
            var entity = 
                (ksEntity)part.NewEntity((short)Obj3dType.o3d_baseExtrusion);
            var def = 
                (ksBaseExtrusionDefinition)entity.GetDefinition();

            def.SetSideParam(true, 0, height);

            var sketch = 
                (ksEntity)part.NewEntity((short)Obj3dType.o3d_sketch);

            var sketchDef = (ksSketchDefinition)sketch.GetDefinition();
            sketchDef.SetPlane(plane);
            sketch.Create();

            var doc2d = (ksDocument2D)sketchDef.BeginEdit() as ksDocument2D;
            doc2d.ksCircle(0, 0, diameter / 2, 1);
            sketchDef.EndEdit();

            def.SetSketch(sketch);
            entity.Create();
        }

        /// <summary>
        /// Создает сквозное отверстие в диске фланца.
        /// </summary>
        /// <param name="part">Деталь, в которой создается отверстие.</param>
        /// <param name="diameter">Диаметр отверстия.</param>
        /// <param name="diskHeight">Толщина диска.</param>
        /// <param name="holeRadius">Радиус окружности, на 
        /// которой расположено отверстие.</param>
        /// <param name="angle">Угол расположения отверстия на 
        /// окружности (в радианах).</param>
        public void CutThroughDiskHole(
            ksPart part,
            double diameter,
            double diskHeight,
            double holeRadius,
            double angle)
        {
            double x = holeRadius * Math.Cos(angle);
            double y = holeRadius * Math.Sin(angle);

            var plane = 
                (ksEntity)part.NewEntity((short)Obj3dType.o3d_planeXOY);
            plane.Create();

            var sketch = 
                (ksEntity)part.NewEntity((short)Obj3dType.o3d_sketch);

            var sketchDef = (ksSketchDefinition)sketch.GetDefinition();
            sketchDef.SetPlane(plane);
            sketch.Create();

            var doc2D = (ksDocument2D)sketchDef.BeginEdit() as ksDocument2D;
            doc2D.ksCircle(x, y, diameter / 2, 1);
            sketchDef.EndEdit();

            var cut = 
                (ksEntity)part.NewEntity((short)Obj3dType.o3d_cutExtrusion);

            var cutDef = (ksCutExtrusionDefinition)cut.GetDefinition();
            cutDef.SetSketch(sketch);
            //TODO: to const
            cutDef.SetSideParam(true, 2, diskHeight + 40);
            cut.Create();
        }
    }
}