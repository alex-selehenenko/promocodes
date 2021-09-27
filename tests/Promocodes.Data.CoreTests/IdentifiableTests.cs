using NUnit.Framework;
using Promocodes.Data.Core.Entities;

namespace Promocodes.Data.CoreTests
{
    public class Tests
    {
        [Test]
        public void Equals_SameTypeAndId_True()
        {
            var left = new Category() { Id = 1 };
            var right = new Category() { Id = 1 };

            var actual = left.Equals(right);

            Assert.IsTrue(actual);
        }

        [Test]
        public void Equals_SameTypeDifferentId_False()
        {
            var left = new Category() { Id = 1 };
            var right = new Category() { Id = 2 };

            var actual = left.Equals(right);

            Assert.IsFalse(actual);
        }

        [Test]
        public void Equals_DifferentTypeSameId_False()
        {
            var left = new Category() { Id = 1 };
            var right = new Offer() { Id = 2 };

            var actual = left.Equals(right);

            Assert.IsFalse(actual);
        }

        [Test]
        public void OperatorEquals_NullEntity_True()
        {
            Offer offer = null;

            var actual = offer == null;

            Assert.IsTrue(actual);
        }
    }
}