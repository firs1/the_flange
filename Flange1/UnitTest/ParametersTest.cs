using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using NUnit.Framework;

namespace UnitTest
{
    /// <summary>
    /// Юнит-тесты для класса Parameters.
    /// Проверяют корректную работу свойств
    /// и соблюдение ограничений параметров.
    /// </summary>
    [TestFixture]
    public class ParametersTests
    {

        [TestCase, Description("Проверка установки допустимого " +
            "значения внешнего диаметра")]
        public void OuterDiameterA_SetValidValue_ValueIsStored()
        {
            var parameters = new Parameters();

            parameters.OuterDiameter_a = 200;

            Assert.AreEqual(200, parameters.OuterDiameter_a);
        }


        [TestCase, Description("Проверка установки граничного " +
            "максимального значения высоты.")]
        public void HeightD_SetMaxBoundaryValue_ValueIsStored()
        {
            var parameters = new Parameters();

            parameters.Height_d = 300;

            Assert.AreEqual(300, parameters.Height_d);
        }

        [TestCase, Description("Проверка корректного преобразования количества " +
            "отверстий в целое число.")]
        public void NumberOfHoles_IsReturnedAsInt()
        {
            var parameters = new Parameters();

            parameters.NumberOfHoles_n = 6;

            Assert.AreEqual(6, parameters.NumberOfHoles_n);
        }


        [TestCase, Description("Проверка установки допустимого " +
            "значения диаметра выступа.")]
        public void ProtrusionDiameterB_SetValidValue_ValueIsStored()
        {
            var parameters = new Parameters();

            parameters.ProtrusionDiameter_b = 150;

            Assert.AreEqual(150, parameters.ProtrusionDiameter_b);
        }


         [TestCase, Description("Проверка корректности геттера диаметра выступа.")]
        public void ProtrusionDiameterB_GetValue_ReturnsCorrectValue()
        {
            var parameters = new Parameters();
            double expectedValue = 180.5;

            parameters.ProtrusionDiameter_b = expectedValue;
            double actualValue = parameters.ProtrusionDiameter_b;

            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestCase, Description("Проверка установки допустимого значения высоты.")]
        public void HeightD_SetValidValue_ValueIsStored()
        {
            var parameters = new Parameters();

            parameters.Height_d = 250;

            Assert.AreEqual(250, parameters.Height_d);
        }


        [TestCase, Description("Проверка установки допустимого значения толщины.")]
        public void ThicknessC_SetValidValue_ValueIsStored()
        {
            var parameters = new Parameters();

            parameters.Thickness_c = 25;

            Assert.AreEqual(25, parameters.Thickness_c);
        }


        [TestCase, Description("Проверка установки максимального " +
            "допустимого значения толщины.")]
        public void ThicknessC_SetMaxBoundaryValue_ValueIsStored()
        {
            var parameters = new Parameters();

            parameters.Thickness_c = 100;

            Assert.AreEqual(100, parameters.Thickness_c);
        }


        [TestCase, Description("Проверка установки допустимого " +
            "значения диаметра отверстий.")]
        public void DiameterHolesE_SetValidValue_ValueIsStored()
        {
            var parameters = new Parameters();

            parameters.DiameterHoles_e = 50;

            Assert.AreEqual(50, parameters.DiameterHoles_e);
        }


        [TestCase, Description("Проверка корректности геттера диаметра отверстий.")]
        public void DiameterHolesE_GetValue_ReturnsCorrectValue()
        {
            var parameters = new Parameters();
            double expectedValue = 75.5;

            parameters.DiameterHoles_e = expectedValue;
            double actualValue = parameters.DiameterHoles_e;

            Assert.AreEqual(expectedValue, actualValue);
        }


        [TestCase, Description("Проверка корректности последовательных " +
            "операций чтения/записи.")]
        public void Properties_MultipleSetGetOperations_WorkCorrectly()
        {
            var parameters = new Parameters();


            parameters.ProtrusionDiameter_b = 100;
            parameters.Height_d = 200;
            parameters.Thickness_c = 30;
            parameters.DiameterHoles_e = 40;

            Assert.Multiple(() =>
            {
                Assert.AreEqual(100, parameters.ProtrusionDiameter_b);
                Assert.AreEqual(200, parameters.Height_d);
                Assert.AreEqual(30, parameters.Thickness_c);
                Assert.AreEqual(40, parameters.DiameterHoles_e);
            });
        }

        [TestCase, Description("Проверка установки значения " +
            "меньше максимального.")]
        public void MaxHoleDiameter_CorrectCalculation_ReturnsExpectedValue()
        {

            var parameters = new Parameters();
            parameters.OuterDiameter_a = 200;
            parameters.ProtrusionDiameter_b = 50;

            double maxHoleDiameter = parameters.MaxHoleDiameter;

            Assert.AreEqual(67.5,
                maxHoleDiameter,
                "Максимальный диаметр отверстий должен быть " +
                "(200 - 50) * 0.45 = 67.5");
        }


        [TestCase, Description("Проверка валидации параметров фланца")]
        public void ValidateParameters_CorrectParameters_NoErrors()
        {
            var parameters = new Parameters();
            parameters.OuterDiameter_a = 200;
            parameters.ProtrusionDiameter_b = 100;
            parameters.Height_d = 250;
            parameters.Thickness_c = 50;
            parameters.DiameterHoles_e = 20;
            parameters.NumberOfHoles_n = 4;
            parameters.HoleStep = 0;

            var errors = parameters.Validate();

            Assert.IsEmpty(errors,
                "Ошибки не должны возникать при корректных данных");
        }


        [TestCase, Description("Проверка валидации параметров с ошибками")]
        public void ValidateParameters_WithErrors_ReturnsValidationErrors()
        {
            var parameters = new Parameters();

            parameters.OuterDiameter_a = 200;

            parameters.ProtrusionDiameter_b = 160; // > 0.75 * 200 = 150

            parameters.Height_d = 300;
            parameters.Thickness_c = 250;
            parameters.DiameterHoles_e = 120;

            var errors = parameters.Validate();

            Assert.IsTrue(errors.ContainsKey(ParameterType.ProtrusionDiameter),
                "Диаметр выступа должен быть ≤ 0.75 * A");

            Assert.IsTrue(errors.ContainsKey(ParameterType.Thickness),
                "Толщина C должна быть меньше A");

            Assert.IsTrue(errors.ContainsKey(ParameterType.DiameterHoles),
                "Диаметр отверстий должен быть ≤ MaxHoleDiameter");
        }


        [TestCase, Description("Проверка валидации максимального диаметра отверстий")]
        public void Validate_MaxHoleDiameter_ExceedsLimit_ThrowsError()
        {
            var parameters = new Parameters();
            parameters.OuterDiameter_a = 200;
            parameters.ProtrusionDiameter_b = 50;
            parameters.DiameterHoles_e = 75;

            var errors = parameters.Validate();

            Assert.IsTrue(errors.ContainsKey(ParameterType.DiameterHoles),
                "Ошибка: Диаметр отверстий должен быть ≤ 67.5");
        }


        [TestCase, Description("Тест для проверки, что шаг в" +
            " пределах допустимого диапазона не вызывает исключений.")]
        public void ValidateStep_StepWithinAllowedRange_ShouldPass()
        {
            var parameters = new Parameters
            {
                NumberOfHoles_n = 5,
                HoleStep = 70
            };

            Assert.DoesNotThrow(() => parameters.ValidateStep(),
                "Шаг в пределах допустимого диапазона.");
        }

        [TestCase, Description("Тест для проверки, что шаг в " +
            "пределах допустимого диапазона не вызывает исключений.")]
        public void ValidateStep_StepNotZeroForEightHoles_ShouldThrowException()
        {
            var parameters = new Parameters
            {
                NumberOfHoles_n = 8,
                HoleStep = 45
            };

            var ex = Assert.Throws<InvalidOperationException>(()
                => parameters.ValidateStep());

            Assert.That(ex.Message, Is.EqualTo
                ("Для 8 отверстий шаг не может быть задан."));
        }


        [TestCase, Description("Тест для проверки, что при задании шага, превышающего" +
            " 90 градусов, для 4 отверстий выбрасывается исключение. ")]
        public void ValidateStep_StepGreaterThanMaxAllowed_ShouldThrowException()
        {
            var parameters = new Parameters
            {
                NumberOfHoles_n = 4,
                HoleStep = 100
            };

            var ex = Assert.Throws<ArgumentOutOfRangeException>(() =>
            parameters.ValidateStep());

            Assert.That(ex.Message.Contains("Шаг не может быть больше " +
                "90 для заданного количества отверстий."),
                        Is.True, "Сообщение об ошибке не совпадает.");
        }

        [TestCase, Description("Тест для проверки, что значение HoleStep_h устанавливается корректно")]
        public void HoleStep_h_SetValidValue_ValueIsStored()
        {
            var parameters = new Parameters();
            int expectedValue = 90;

            parameters.HoleStep_h = expectedValue;

            Assert.AreEqual(expectedValue, parameters.HoleStep_h,
                "Значение HoleStep_h не было установлено корректно.");
        }


        [TestCase, Description("Тест для проверки, что значение Height_d" +
            " выдаёт ошибку при некорректном вводе")]
        public void Validate_ValueGreaterThanMax_ReturnsError()
        {
            var parameters = new Parameters();
            parameters.Height_d = 350; // max = 300

            var errors = parameters.Validate();

            Assert.That(errors.ContainsKey(ParameterType.Height), Is.True);
        }


        [TestCase, Description("Тест для проверки, что значение OuterDiameter_a" +
            " устанавливается корректно")]
        public void Validate_ValueLessThanMin_ReturnsError()
        {
            var parameters = new Parameters();
            parameters.OuterDiameter_a = 1; // min = 2

            var errors = parameters.Validate();

            Assert.That(errors.ContainsKey(ParameterType.OuterDiameter), Is.True);
        }

    }
}
