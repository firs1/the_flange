using System;
using Kompas6API5;
using Kompas6Constants3D;
using Models;

namespace Wrapper
{
    /// <summary>
    /// Класс для построения 3D-модели фланца в КОМПАС-3D.
    /// Осуществляет создание геометрических элементов на основе параметров фланца.
    /// </summary>
    public class Builder
    {
        private readonly Wrapper _wrapper;

        /// <summary>
        /// Инициализирует новый экземпляр построителя модели.
        /// </summary>
        /// <param name="wrapper">Обертка для работы с API КОМПАС-3D.</param>
        public Builder(Wrapper wrapper)
        {
            _wrapper = wrapper;
        }

        /// <summary>
        /// Строит 3D-модель фланца по заданным параметрам.
        /// </summary>
        /// <param name="p">Параметры фланца для построения модели.</param>
        public void BuildModel(Parameters p)
        {
            // Запуск или подключение к КОМПАС-3D
            _wrapper.AttachOrRunCAD();

            // Создание нового 3D-документа
            var doc = _wrapper.CreateDocument3D();
            var part = _wrapper.GetPart(doc);

            // Извлечение параметров модели
            double a = p.OuterDiameter_a;
            double b = p.ProtrusionDiameter_b;
            double c = p.Thickness_c;
            double d = p.Height_d;
            double holeDiameter = p.DiameterHoles_e;
            int holeCount = p.NumberOfHoles_n;

            // Создание основного диска
            _wrapper.CreateBaseCylinder(part, a, c);

            // Создание центрального выступа
            var topPlane = _wrapper.CreateOffsetPlane(part, c);
            _wrapper.CreateCylinderOnPlane(part, topPlane, b, d);

            // Создание отверстий для крепления
            double holeRadius = (a / 2 + b / 2) / 2;

            // Создание эскиза для отверстий
            var basePlane = part.GetDefaultEntity((short)Obj3dType.o3d_planeXOY);
            var sketch = (ksEntity)part.NewEntity((short)Obj3dType.o3d_sketch);
            var sketchDef = (ksSketchDefinition)sketch.GetDefinition();
            sketchDef.SetPlane(basePlane);
            sketch.Create();

            var doc2D = (ksDocument2D)sketchDef.BeginEdit();

            // Рисование отверстий в эскизе
            for (int i = 0; i < holeCount; i++)
            {
                double angle = 2 * Math.PI * i / holeCount;
                double x = holeRadius * Math.Cos(angle);
                double y = holeRadius * Math.Sin(angle);

                doc2D.ksCircle(x, y, holeDiameter / 2, 1);
            }

            sketchDef.EndEdit();

            // Вырез отверстий в модели
            var cut = (ksEntity)part.NewEntity((short)Obj3dType.o3d_cutExtrusion);
            var cutDef = (ksCutExtrusionDefinition)cut.GetDefinition();
            cutDef.SetSketch(sketch);
            cutDef.SetSideParam(false, 1, c + 1);
            cut.Create();
        }
    }
}