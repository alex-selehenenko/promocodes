namespace Promocodes.Data.Core.DataConstraints
{
    public class OfferConstraints
    {
        public const int MinDescriptionLength = 10;
        public const int MaxDescriptionLength = 200;

        public const int MinTitleLength = 3;
        public const int MaxTitleLength = 100;

        public const int MinPromocodeLength = 3;
        public const int MaxPromocodeLength = 30;

        public const float MinDiscount = 0;
        public const float MaxDiscount = 1;
    }
}
