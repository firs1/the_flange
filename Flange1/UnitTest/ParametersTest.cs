using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using NUnit.Framework;

namespace UnitTest
{
    /// <description>
    /// Юнит-тесты для класса Parameters.
    /// Проверяют корректную работу свойств
    /// и соблюдение ограничений параметров.
    /// </description>
    [TestFixture]
    public class ParametersTests
    {
        //TODO: description
        /// <description>
        /// Проверка установки допустимого значения внешнего диаметра.
        /// </description>
        [Test]
        public void OuterDiameterA_SetValidValue_ValueIsStored()
        {
            var parameters = new Parameters();

            parameters.OuterDiameter_a = 200;

            Assert.AreEqual(200, parameters.OuterDiameter_a);
        }


        /// <description>
        /// Проверка установки граничного максимального значения высоты.
        /// </description>
        [Test]
        public void HeightD_SetMaxBoundaryValue_ValueIsStored()
        {
            var parameters = new Parameters();

            parameters.Height_d = 300;

            Assert.AreEqual(300, parameters.Height_d);
        }

        /// <description>
        /// Проверка корректного преобразования 
        /// количества отверстий в целое число.
        /// </description>
        [Test]
        public void NumberOfHoles_IsReturnedAsInt()
        {
            var parameters = new Parameters();

            parameters.NumberOfHoles_n = 6;

            Assert.AreEqual(6, parameters.NumberOfHoles_n);
        }


        /// <description>
        /// Проверка установки допустимого значения диаметра выступу B.
        /// </description>
        [Test]
        public void ProtrusionDiameterB_SetValidValue_ValueIsStored()
        {
            var parameters = new Parameters();

            parameters.ProtrusionDiameter_b = 150;

            Assert.AreEqual(150, parameters.ProtrusionDiameter_b);
        }


        /// <description>
        /// Проверка корректности геттера диаметра выступу B.
        /// </description>
        [Test]
        public void ProtrusionDiameterB_GetValue_ReturnsCorrectValue()
        {
            var parameters = new Parameters();
            double expectedValue = 180.5;

            parameters.ProtrusionDiameter_b = expectedValue;
            double actualValue = parameters.ProtrusionDiameter_b;

            Assert.AreEqual(expectedValue, actualValue);
        }

        /// <description>
        /// Проверка установки допустимого значения высоты D.
        /// </description>
        [Test]
        public void HeightD_SetValidValue_ValueIsStored()
        {
            var parameters = new Parameters();

            parameters.Height_d = 250;

            Assert.AreEqual(250, parameters.Height_d);
        }

        /// <description>
        /// Проверка установки допустимого значения толщины C.
        /// </description>
        [Test]
        public void ThicknessC_SetValidValue_ValueIsStored()
        {
            var parameters = new Parameters();

            parameters.Thickness_c = 25;

            Assert.AreEqual(25, parameters.Thickness_c);
        }

        /// <description>
        /// Проверка установки максимального допустимого значения толщины C.
        /// </description>
        [Test]
        public void ThicknessC_SetMaxBoundaryValue_ValueIsStored()
        {
            var parameters = new Parameters();

            parameters.Thickness_c = 100;

            Assert.AreEqual(100, parameters.Thickness_c);
        }


        /// <description>
        /// Проверка установки допустимого значения диаметра отверстий E.
        /// </description>
        [Test]
        public void DiameterHolesE_SetValidValue_ValueIsStored()
        {
            var parameters = new Parameters();

            parameters.DiameterHoles_e = 50;

            Assert.AreEqual(50, parameters.DiameterHoles_e);
        }


        /// <description>
        /// Проверка корректности геттера диаметра отверстий E.
        /// </description>
        [Test]
        public void DiameterHolesE_GetValue_ReturnsCorrectValue()
        {
            var parameters = new Parameters();
            double expectedValue = 75.5;

            parameters.DiameterHoles_e = expectedValue;
            double actualValue = parameters.DiameterHoles_e;

            Assert.AreEqual(expectedValue, actualValue);
        }



        /// <description>
        /// Проверка корректности последовательных операций чтения/записи.
        /// </description>
        [Test]
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

        [Test]
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

        /// <description>
        /// Проверка валидации параметров фланца
        /// </description>
        [Test]
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

        /// <description>
        /// Проверка валидации параметров с ошибками
        /// </description>
        [Test]
        public void ValidateParameters_WithErrors_ReturnsValidationErrors()
        {
            var parameters = new Parameters();
            parameters.OuterDiameter_a = 200;
            parameters.ProtrusionDiameter_b = 180;
            parameters.Height_d = 350;
            parameters.Thickness_c = 250;
            parameters.DiameterHoles_e = 150;


            var errors = parameters.Validate();

            Assert.IsTrue(errors.ContainsKey
               (ParameterType.ProtrusionDiameter),
               "Ошибка: Диаметр выступа должен быть ≤ 0.75 * A");
            Assert.IsTrue(errors.ContainsKey
                (ParameterType.Height),
                "Ошибка: Высота D должна быть в пределах диапазона");
            Assert.IsTrue(errors.ContainsKey
                (ParameterType.Thickness),
                "Ошибка: Толщина C должна быть меньше A");
            Assert.IsTrue(errors.ContainsKey
                (ParameterType.DiameterHoles),
                "Ошибка: Диаметр отверстий должен быть ≤ MaxHoleDiameter");
        }

        /// <description>
        /// Проверка валидации максимального диаметра отверстий
        /// </description>
        [Test]
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


        /// </description>
        /// Тест для проверки, что шаг в пределах 
        /// допустимого диапазона не вызывает исключений.
        /// </description>
        [Test]
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

        /// </description>
        /// Тест для проверки, что при задании шага для 
        /// 8 отверстий возникает исключение.
        /// </description>
        [Test]
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


        /// </description>
        /// Тест для проверки, что при превышении шага 
        /// более 130 градусов выбрасывается исключение.
        /// </description>
        [Test]
        public void ValidateStep_StepExceeds130Degrees_ShouldThrowException()
        {
            var parameters = new Parameters
            {
                NumberOfHoles_n = 5,
                HoleStep = 140
            };

            var ex = Assert.Throws<ArgumentOutOfRangeException>(()
                => parameters.ValidateStep());

            Assert.That(ex.Message.Contains("Шаг не может превышать 130 градусов."),
                        Is.True, "Сообщение об ошибке не совпадает.");
        }

        /// </description>
        /// Тест для проверки, что при задании шага, превышающего 90 
        /// градусов, для 4 отверстий выбрасывается исключение.
        /// </description>
        [Test]
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

        /// </description>
        /// Тест для проверки, что значение HoleStep_h устанавливается корректно.
        /// </description>
        [Test]
        public void HoleStep_h_SetValidValue_ValueIsStored()
        {
            var parameters = new Parameters();
            int expectedValue = 90;

            parameters.HoleStep_h = expectedValue;

            Assert.AreEqual(expectedValue, parameters.HoleStep_h,
                "Значение HoleStep_h не было установлено корректно.");
        }
    }
}

