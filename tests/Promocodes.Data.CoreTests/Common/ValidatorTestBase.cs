using FluentValidation;
using NUnit.Framework;
using Promocodes.Data.Core.Entities;
using Promocodes.Data.CoreTests.Helpers;

namespace Promocodes.Data.CoreTests.Common
{
    public abstract class ValidatorTestBase<T> where T : EntityBase
    {
        protected IValidator<T> Validator { get; set; }
        
        protected static string InvalidDataSource { get; set; }

        public abstract void ValidProperties_True();

        public abstract void InvalidProperties_True(ValidatorTestCase<T> testCase);

        protected virtual void CheckValidProperties()
        {
            var entity = EntityFactory.Get<T>();
            var result = Validator.Validate(entity);

            var actual = result.IsValid;

            Assert.IsTrue(actual);
        }

        protected virtual void CheckInvalidProperties(ValidatorTestCase<T> testCase)
        {
            var result = Validator.Validate(testCase.Entity);

            var actual = !result.IsValid && result.Errors.Count == testCase.ExpectedErrors;

            Assert.IsTrue(actual);
        }

        protected static T New() => EntityFactory.Get<T>();

        protected static string New(int length) => new('a', length);

        protected static ValidatorTestCase<T> StringLengthTestCase(T entity, string property, bool greater = true, int expectedErrors = 1)
        {
            var message = greater ? $"{property} length greater max" : $"{property} length less min";

            return TestCase(entity, message, expectedErrors);
        }

        protected static ValidatorTestCase<T> OutOfRangeTestCase(T entity, string property, bool greater, int expectedErrors = 1)
        {
            var message = greater ? $"{property} value greater max" : $"{property} value less min";

            return TestCase(entity, message, expectedErrors);
        }

        protected static ValidatorTestCase<T> NullTestCase(T entity, string property, int expectedErrors = 1) => new()
        {
            Entity = entity,
            DisplayMessage = $"Null {property}",
            ExpectedErrors = expectedErrors
        };

        protected static ValidatorTestCase<T> TestCase(T entity, string displayMessage, int expectedErrors = 1) => new()
        {
            Entity = entity,
            DisplayMessage = displayMessage,
            ExpectedErrors = expectedErrors
        };
    }
}
