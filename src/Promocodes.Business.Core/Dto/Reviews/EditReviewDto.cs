namespace Promocodes.Business.Core.Dto.Reviews
{
    public class EditReviewDto : IntegerIdentityDto, IDtoBase
    {
        public string Text { get; set; }

        public byte Stars { get; set; }
    }
}
