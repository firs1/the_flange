using NUnit.Framework;
using System;
using Models;
namespace UnitTest
{
    //TODO: encoding
    /// <summary>
    /// Ќабор юнит-тестов дл€ класса Parameter.
    /// ѕровер€ет корректность хранени€ значений
    /// и соблюдение допустимых диапазонов.
    /// <summary>
    [TestFixture]
    public class ParameterTests
    {
        [TestCase, Description("ѕроверка установки значени€, наход€щегос€ " +
            "внутри допустимого диапазона.")]
        public void Value_SetInsideRange_ValueIsStored()
        {
            var ValueSet = new Parameter(1, 10);

           ValueSet.Value = 5;
            Assert.AreEqual(5, ValueSet.Value);
        }


        [TestCase, Description("ѕроверка корректности сохранени€ минимального" +
            " и максимального значений,переданных через конструктор. ")]
        public void Constructor_MinAndMax_AreStoredCorrectly()
        {

            var MinMax = new Parameter(2, 20);

            Assert.AreEqual(2, MinMax.Min);
            Assert.AreEqual(20, MinMax.Max);
        }

        [TestCase, Description("ѕроверка установки минимального " +
            "значени€ больше чем максимального")]
        public void Constructor_MinGreaterThanMax_ShouldThrowArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(
                () => new Parameter(10, 5));

            Assert.That(
                ex.Message.Contains("ћинимальное значение не может " +
                "быть больше максимального."),
                Is.True,
                "—ообщение об ошибке не совпадает.");
        }

    }
}