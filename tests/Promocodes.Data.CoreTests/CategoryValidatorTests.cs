using NUnit.Framework;
using Promocodes.Data.Core.DataConstraints;
using Promocodes.Data.Core.Entities;
using Promocodes.Data.Core.Validation;
using Promocodes.Data.CoreTests.Common;
using Promocodes.Data.CoreTests.Helpers;
using System.Collections.Generic;

namespace Promocodes.Data.CoreTests
{
    public class CategoryValidatorTests : ValidatorTestBase<Category>
    {
        [SetUp]
        public void Setup()
        {
            Validator = new CategoryValidator();
        }

        public static IEnumerable<ValidatorTestCase<Category>> GetInvalidProperties()
        {
            var category = New();
            category.Name = null;
            yield return NullTestCase(category, nameof(Category.Name));

            category = New();
            category.Name = New(CategoryConstraints.NameMaxLength + 1);
            yield return StringLengthTestCase(category, nameof(Category.Name));

            category = New();
            category.Name = New(CategoryConstraints.NameMinLength - 1);
            yield return StringLengthTestCase(category, nameof(Category.Name), false);
        }

        [Test]
        public override void ValidProperties_True()
        {
            CheckValidProperties();
        }

        [Test]
        [TestCaseSource(nameof(GetInvalidProperties))]
        public override void InvalidProperties_True(ValidatorTestCase<Category> testCase)
        {
            CheckInvalidProperties(testCase);
        }
    }    
}