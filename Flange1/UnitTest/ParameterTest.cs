using NUnit.Framework;
using System;
using Models;
namespace UnitTest
{
    /// </description>
    /// Ќабор юнит-тестов дл€ класса Parameter.
    /// ѕровер€ет корректность хранени€ значений
    /// и соблюдение допустимых диапазонов.
    /// </description>
    [TestFixture]
    public class ParameterTests
    {
        /// </description>
        /// ѕроверка установки значени€, наход€щегос€ 
        /// внутри допустимого диапазона.
        /// ќжидаетс€, что значение будет успешно сохранено.
        /// </description>
        [Test]
        public void Value_SetInsideRange_ValueIsStored()
        {
            var p = new Parameter(1, 10);

            p.Value = 5;
            Assert.AreEqual(5, p.Value);
        }


        /// </description>
        /// ѕроверка корректности сохранени€ минимального 
        /// и максимального значений,переданных через конструктор.
        /// </description>
        [Test]
        public void Constructor_MinAndMax_AreStoredCorrectly()
        {
            var p = new Parameter(2, 20);

            Assert.AreEqual(2, p.Min);
            Assert.AreEqual(20, p.Max);
        }
    }
}