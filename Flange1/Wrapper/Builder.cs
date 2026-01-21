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
        /// <summary>
        /// Обёртка над API КОМПАС-3D,
        /// используемая для создания геометрических объектов.
        /// </summary>
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
            _wrapper.AttachOrRunCAD();

            var doc = _wrapper.CreateDocument3D();
            var part = _wrapper.GetPart(doc);

            double a = p.OuterDiameter_a;
            double b = p.ProtrusionDiameter_b;
            double c = p.Thickness_c;
            double d = p.Height_d;
            double holeDiameter = p.DiameterHoles_e;
            int holeCount = p.NumberOfHoles_n;

            _wrapper.CreateBaseCylinder(part, a, c);

            var topPlane = _wrapper.CreateOffsetPlane(part, c);
            _wrapper.CreateCylinderOnPlane(part, topPlane, b, d);

            double holeRadius = (a / 2 + b / 2) / 2;

            double holeStep = _wrapper.HoleStep;

            if (holeCount == 8)
            {
                holeStep = 360.0 / holeCount;  
            }

            if (holeCount != 8 && holeStep != 0)
            {
                holeStep = p.HoleStep_h + holeDiameter;
            }
            if (holeStep == 0)
            {
                holeStep = p.HoleStep_h;
            }

            var basePlane =
                part.GetDefaultEntity((short)Obj3dType.o3d_planeXOY);
            var sketch =
                (ksEntity)part.NewEntity((short)Obj3dType.o3d_sketch);
            var sketchDef =
                (ksSketchDefinition)sketch.GetDefinition();

            sketchDef.SetPlane(basePlane);
            sketch.Create();
            var doc2D = (ksDocument2D)sketchDef.BeginEdit();

            for (int i = 0; i < holeCount; i++)
            {
                double angle = holeStep * i; 
                double angleInRadians = angle * Math.PI / 180;

                double x = holeRadius * Math.Cos(angleInRadians);
                double y = holeRadius * Math.Sin(angleInRadians);

                doc2D.ksCircle(x, y, holeDiameter / 2, 1);
            }

            sketchDef.EndEdit();
            var cut = 
                (ksEntity)part.NewEntity((short)Obj3dType.o3d_cutExtrusion);

            var cutDef = (ksCutExtrusionDefinition)cut.GetDefinition();
            cutDef.SetSketch(sketch);
            cutDef.SetSideParam(false, 1, c + 1);
            cut.Create();
        }
    }
}
