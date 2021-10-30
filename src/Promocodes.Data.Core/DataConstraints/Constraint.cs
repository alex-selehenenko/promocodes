namespace Promocodes.Data.Core.DataConstraints
{
    public abstract class Constraint
    {
        public class User
        {
            public const int IdMaxLength = 38;
        }

        public class Category
        {
            public const int NameMinLength = 3;

            public const int NameMaxLength = 50;
        }

        public class Offer
        {
            public const int DescriptionMinLength = 10;
            public const int DescriptionMaxLength = 200;

            public const int TitleMinLength = 3;
            public const int TitleMaxLength = 100;

            public const int PromocodeMinLength = 3;
            public const int PromocodeMaxLength = 30;

            public const float DiscountMinValue = 0;
            public const float DiscountMaxValue = 1;
        }

        public class Review
        {
            public const int StarsMin = 1;
            public const int StarsMax = 10;

            public const int TextMinLength = 0;
            public const int TextMaxLength = 500;
        }

        public class Shop
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 50;

            public const int DescriptionMinLength = 50;
            public const int DescriptionMaxLength = 500;

            public const float RatingMin = 0f;
            public const float RatingMax = 10f;
        }
    }
}
