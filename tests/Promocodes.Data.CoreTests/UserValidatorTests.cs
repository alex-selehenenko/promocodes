using NUnit.Framework;
using Promocodes.Data.Core.DataConstraints;
using Promocodes.Data.Core.Entities;
using Promocodes.Data.Core.Validation;
using Promocodes.Data.CoreTests.Common;
using Promocodes.Data.CoreTests.Helpers;
using System.Collections.Generic;

namespace Promocodes.Data.CoreTests
{
    public class UserValidatorTests : ValidatorTestBase<User>
    {
        [SetUp]
        public void SetUp()
        {
            Validator = new UserEntityValidator();
        }

        public static IEnumerable<ValidatorTestCase<User>> GetInvalidProperties()
        {
            // UnerName cases
            var property = nameof(User.UserName);

            var user = New();
            user.UserName = null;
            yield return NullTestCase(user, property);

            user = New();
            user.UserName = New(UserConstraints.MinUserNameLength - 1);
            yield return StringLengthTestCase(user, property, false);

            user = New();
            user.UserName = New(UserConstraints.MaxUserNameLength + 1);
            yield return StringLengthTestCase(user, property);

            //Phone cases
            property = nameof(User.Phone);

            user = New();
            user.Phone = "065451235";
            yield return TestCase(user, "Phone doesn't match pattern");            

            user = New();
            user.Phone = "+" + new string('1', CommonConstraints.PhoneMinLength - 2);
            yield return OutOfRangeTestCase(user, property, false);

            user = New();
            user.Phone = "+" + new string('1', CommonConstraints.PhoneMaxLength + 2);
            yield return OutOfRangeTestCase(user, property, true);

            user = New();
            user.Phone = null;
            yield return NullTestCase(user, property);
        }

        [Test]
        [TestCaseSource(nameof(GetInvalidProperties))]
        public override void InvalidProperties_True(ValidatorTestCase<User> testCase)
        {
            CheckInvalidProperties(testCase);
        }

        [Test]        
        public override void ValidProperties_True()
        {
            CheckValidProperties();
        }
    }
}
