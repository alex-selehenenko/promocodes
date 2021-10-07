namespace Promocodes.Data.Core.DataConstraints
{
    public class ShopConstraints
    {
        public const int NameMinLength = 3;
        public const int NameMaxLength = 50;

        public const int DescriptionMinLength = 50;
        public const int DescriptionMaxLength = 500;

        public const float MinRating = 0f;
        public const float MaxRating = 10f;
    }
}
