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

        //TODO: RSDN
        /// <summary>
        /// Строит 3D-модель фланца по заданным параметрам.
        /// </summary>
        /// <param name="p">Параметры флxанца для построения модели.</param>
        public void BuildModel( Parameters p, bool closeDocumentAfterBuild = false)
        {
            //TODO: {}
            if (p == null)
                throw new ArgumentNullException(nameof(p));

            _wrapper.AttachOrRunCAD();
            _wrapper.CreateDocument3D();

            try
            {
                var part = _wrapper.GetPart();

                double a = p.OuterDiameter_a;
                double b = p.ProtrusionDiameter_b;
                double c = p.Thickness_c;
                double d = p.Height_d;
                double holeDiameter = p.DiameterHoles_e;
                int holeCount = p.NumberOfHoles_n;
                int holeStep = p.HoleStep_h;
                double infelicity = 1.1;

                _wrapper.CreateBaseCylinder(part, a, c);

                var topPlane = _wrapper.CreateOffsetPlane(part, c);
                _wrapper.CreateCylinderOnPlane(part, topPlane, b, d);

                double holeRadius = (a / 2 + b / 2) / 2;

                double aproxAngleDiameter =
                    infelicity * 360 /
                    (p.OuterDiameter_a * Math.PI / p.DiameterHoles_e);

                if (holeCount == 8)
                {
                    holeStep = 360 / holeCount;
                }

                if (holeCount != 8 &&
                    p.HoleStep_h != 0 &&
                    p.HoleStep_h < aproxAngleDiameter)
                {
                    holeStep =
                        p.HoleStep_h +
                        (int)p.DiameterHoles_e / 2 + 2;
                }

                if (p.HoleStep_h == 0 ||
                    p.HoleStep_h > aproxAngleDiameter)
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

                var doc2D =
                    (ksDocument2D)sketchDef.BeginEdit();

                for (int i = 0; i < holeCount; i++)
                {
                    double angleRad =
                        holeStep * i * Math.PI / 180.0;

                    double x =
                        holeRadius * Math.Cos(angleRad);
                    double y =
                        holeRadius * Math.Sin(angleRad);

                    doc2D.ksCircle(x, y, holeDiameter / 2, 1);
                }

                sketchDef.EndEdit();

                var cut =
                    (ksEntity)part.NewEntity(
                        (short)Obj3dType.o3d_cutExtrusion);

                var cutDef =
                    (ksCutExtrusionDefinition)cut.GetDefinition();

                cutDef.SetSketch(sketch);
                cutDef.SetSideParam(false, 1, c + 1);
                cut.Create();
            }
            finally
            {
                if (closeDocumentAfterBuild)
                {
                    _wrapper.CloseActiveDocument3D(save: false);
                }
            }
        }
    }
}
