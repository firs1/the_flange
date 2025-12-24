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
        /// <summary>
        /// Проверка установки допустимого значения внешнего диаметра.
        /// </summary>
        [Test]
        public void OuterDiameterA_SetValidValue_ValueIsStored()
        {
            // Arrange
            var parameters = new Parameters();

            // Act
            parameters.OuterDiameter_a = 200;

            // Assert
            Assert.AreEqual(200, parameters.OuterDiameter_a);
        }

        /// <summary>
        /// Проверка выброса исключения при установке толщины меньше минимального значения.
        /// </summary>
        [Test]
        public void ThicknessC_SetValueBelowMin_ThrowsException()
        {
            // Arrange
            var parameters = new Parameters();

            // Act & Assert
            TestDelegate code = () => parameters.Thickness_c = 0;
            Assert.Throws<ArgumentException>(code);
        }

        /// <summary>
        /// Проверка установки граничного максимального значения высоты.
        /// </summary>
        [Test]
        public void HeightD_SetMaxBoundaryValue_ValueIsStored()
        {
            // Arrange
            var parameters = new Parameters();

            // Act
            parameters.Height_d = 300;

            // Assert
            Assert.AreEqual(300, parameters.Height_d);
        }

        /// <summary>
        /// Проверка корректного преобразования количества отверстий в целое число.
        /// </summary>
        [Test]
        public void NumberOfHoles_IsReturnedAsInt()
        {
            // Arrange
            var parameters = new Parameters();

            // Act
            parameters.NumberOfHoles_n = 6;

            // Assert
            Assert.AreEqual(6, parameters.NumberOfHoles_n);
        }

        /// <summary>
        /// Проверка выброса исключения при превышении допустимого диаметра отверстий.
        /// </summary>
        [Test]
        public void DiameterHolesE_GreaterThanMax_ThrowsException()
        {
            // Arrange
            var parameters = new Parameters();

            // Act & Assert
            _ = Assert.Throws<ArgumentException>(() =>
            {
                parameters.DiameterHoles_e = 500;
            });
        }

        /// <summary>
        /// Проверка установки допустимого значения диаметра выступу B.
        /// </summary>
        [Test]
        public void ProtrusionDiameterB_SetValidValue_ValueIsStored()
        {
            // Arrange
            var parameters = new Parameters();

            // Act
            parameters.ProtrusionDiameter_b = 150;

            // Assert
            Assert.AreEqual(150, parameters.ProtrusionDiameter_b);
        }

        /// <summary>
        /// Проверка выброса исключения при установке отрицательного диаметра выступу B.
        /// </summary>
        [Test]
        public void ProtrusionDiameterB_SetNegativeValue_ThrowsException()
        {
            // Arrange
            var parameters = new Parameters();

            // Act & Assert
            Assert.Throws<ArgumentException>(() =>
            {
                parameters.ProtrusionDiameter_b = -10;
            });
        }

        /// <summary>
        /// Проверка корректности геттера диаметра выступу B.
        /// </summary>
        [Test]
        public void ProtrusionDiameterB_GetValue_ReturnsCorrectValue()
        {
            // Arrange
            var parameters = new Parameters();
            double expectedValue = 180.5;

            // Act
            parameters.ProtrusionDiameter_b = expectedValue;
            double actualValue = parameters.ProtrusionDiameter_b;

            // Assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        /// <summary>
        /// Проверка установки допустимого значения высоты D.
        /// </summary>
        [Test]
        public void HeightD_SetValidValue_ValueIsStored()
        {
            // Arrange
            var parameters = new Parameters();

            // Act
            parameters.Height_d = 250;

            // Assert
            Assert.AreEqual(250, parameters.Height_d);
        }

        /// <summary>
        /// Проверка выброса исключения при установке отрицательной высоты D.
        /// </summary>
        [Test]
        public void HeightD_SetNegativeValue_ThrowsException()
        {
            // Arrange
            var parameters = new Parameters();

            // Act & Assert
            Assert.Throws<ArgumentException>(() =>
            {
                parameters.Height_d = -50;
            });
        }


        /// <summary>
        /// Проверка установки допустимого значения толщины C.
        /// </summary>
        [Test]
        public void ThicknessC_SetValidValue_ValueIsStored()
        {
            // Arrange
            var parameters = new Parameters();

            // Act
            parameters.Thickness_c = 25;

            // Assert
            Assert.AreEqual(25, parameters.Thickness_c);
        }

        /// <summary>
        /// Проверка установки максимального допустимого значения толщины C.
        /// </summary>
        [Test]
        public void ThicknessC_SetMaxBoundaryValue_ValueIsStored()
        {
            // Arrange
            var parameters = new Parameters();

            // Act
            parameters.Thickness_c = 100;

            // Assert
            Assert.AreEqual(100, parameters.Thickness_c);
        }


        /// <summary>
        /// Проверка установки допустимого значения диаметра отверстий E.
        /// </summary>
        [Test]
        public void DiameterHolesE_SetValidValue_ValueIsStored()
        {
            // Arrange
            var parameters = new Parameters();

            // Act
            parameters.DiameterHoles_e = 50;

            // Assert
            Assert.AreEqual(50, parameters.DiameterHoles_e);
        }

        /// <summary>
        /// Проверка выброса исключения при установке нулевого диаметра отверстий E.
        /// </summary>
        [Test]
        public void DiameterHolesE_SetZeroValue_ThrowsException()
        {
            // Arrange
            var parameters = new Parameters();

            // Act & Assert
            Assert.Throws<ArgumentException>(() =>
            {
                parameters.DiameterHoles_e = 0;
            });
        }

        /// <summary>
        /// Проверка корректности геттера диаметра отверстий E.
        /// </summary>
        [Test]
        public void DiameterHolesE_GetValue_ReturnsCorrectValue()
        {
            // Arrange
            var parameters = new Parameters();
            double expectedValue = 75.5;

            // Act
            parameters.DiameterHoles_e = expectedValue;
            double actualValue = parameters.DiameterHoles_e;

            // Assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        /// <summary>
        /// Проверка взаимосвязи свойств при установке значений.
        /// Например, проверка что диаметр выступу B не может быть больше внешнего диаметра A.
        /// </summary>
        [Test]
        public void ProtrusionDiameterB_CannotExceedOuterDiameterA_ThrowsException()
        {
            // Arrange
            var parameters = new Parameters();
            parameters.OuterDiameter_a = 200;

            // Act & Assert
            // Предполагаем, что диаметр выступу должен быть меньше внешнего диаметра
            Assert.Throws<ArgumentException>(() =>
            {
                parameters.ProtrusionDiameter_b = 350; // Больше чем OuterDiameter_a
            });
        }

        /// <summary>
        /// Проверка корректности последовательных операций чтения/записи.
        /// </summary>
        [Test]
        public void Properties_MultipleSetGetOperations_WorkCorrectly()
        {
            // Arrange
            var parameters = new Parameters();

            // Act
            parameters.ProtrusionDiameter_b = 100;
            parameters.Height_d = 200;
            parameters.Thickness_c = 30;
            parameters.DiameterHoles_e = 40;

            // Assert
            Assert.Multiple(() =>
            {
                Assert.AreEqual(100, parameters.ProtrusionDiameter_b);
                Assert.AreEqual(200, parameters.Height_d);
                Assert.AreEqual(30, parameters.Thickness_c);
                Assert.AreEqual(40, parameters.DiameterHoles_e);
            });
        }
    }
}
