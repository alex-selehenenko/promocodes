using NUnit.Framework;
using Promocodes.Data.Core.DataConstraints;
using Promocodes.Data.Core.Entities;
using Promocodes.Data.Core.Validation;
using Promocodes.Data.CoreTests.Helpers;
using System.Collections.Generic;

namespace Promocodes.Data.CoreTests
{
    public class CategoryValidatorTests
    {
        private CategoryValidator _validator;

        [SetUp]
        public void Setup()
        {
            _validator = new CategoryValidator();
        }

        [Test]
        [TestCaseSource(nameof(GetCategoryWithInvalidname))]
        public void InvalidCategoryName(EntityContainer<Category> container)
        {
            var result = _validator.Validate(container.Entity);

            Assert.IsFalse(result.IsValid);
        }        

        [Test]
        public void CorrectName_Valid()
        {
            var category = new Category()
            {
                Id = 1,
                Name = new('a', CategoryConstraints.NameMinLength)
            };

            var result = _validator.Validate(category);
            var actual = result.IsValid;

            Assert.IsTrue(actual);
        }

        public static IEnumerable<EntityContainer<Category>> GetCategoryWithInvalidname()
        {
            yield return new()
            {
                Entity = new() { Id = 1, Name = null },
                CaseName = "NullName_Invalid"
            };

            yield return new()
            {
                Entity = new() { Id = 1, Name = new string('a', CategoryConstraints.NameMaxLength + 1) },
                CaseName = "NameLengthGreaterMaxValue_Invalid"
            };

            yield return new()
            {
                Entity = new() { Id = 1, Name = new string('a', CategoryConstraints.NameMinLength - 1) },
                CaseName = "NameLengthLessMinValue_Invalid"
            };
        }
    }    
}