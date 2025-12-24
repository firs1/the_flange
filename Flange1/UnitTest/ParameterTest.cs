using NUnit.Framework;
using System;
using Models;
namespace UnitTest
{
    /// <summary>
    /// Набор юнит-тестов для класса Parameter.
    /// Проверяет корректность хранения значений
    /// и соблюдение допустимых диапазонов.
    /// </summary>
    [TestFixture]
    public class ParameterTests
    {
        /// <summary>
        /// Проверка установки значения, находящегося внутри допустимого диапазона.
        /// Ожидается, что значение будет успешно сохранено.
        /// </summary>
        [Test]
        public void Value_SetInsideRange_ValueIsStored()
        {
            // Arrange — создаём параметр с диапазоном [1; 10]
            var p = new Parameter(1, 10);

            // Act — устанавливаем допустимое значение
            p.Value = 5;

            // Assert — проверяем, что значение сохранилось
            Assert.AreEqual(5, p.Value);
        }

        /// <summary>
        /// Проверка обработки ошибки при установке значения меньше минимального.
        /// Ожидается выброс исключения ArgumentException.
        /// </summary>
        [Test]
        public void Value_LessThanMin_ThrowsArgumentException()
        {
            // Arrange
            var p = new Parameter(1, 10);

            // Act & Assert — попытка установить недопустимое значение
            Assert.Throws<ArgumentException>(() =>
            {
                p.Value = 0;
            });
        }

        /// <summary>
        /// Проверка обработки ошибки при превышении максимального значения.
        /// Ожидается выброс исключения ArgumentException.
        /// </summary>
        [Test]
        public void Value_GreaterThanMax_ThrowsArgumentException()
        {
            // Arrange
            var p = new Parameter(1, 10);

            // Act & Assert
            Assert.Throws<ArgumentException>(() =>
            {
                p.Value = 11;
            });
        }

        /// <summary>
        /// Проверка корректности сохранения минимального и максимального значений,
        /// переданных через конструктор.
        /// </summary>
        [Test]
        public void Constructor_MinAndMax_AreStoredCorrectly()
        {
            // Arrange
            var p = new Parameter(2, 20);

            // Assert
            Assert.AreEqual(2, p.Min);
            Assert.AreEqual(20, p.Max);
        }
    }
}