using Promocodes.Data.Core.Common;

namespace Promocodes.Business.Core.Dto.Reviews
{
    public class EditReviewDto : IdentityBase<int>, IDtoBase
    {
        public string Text { get; set; }

        public byte Stars { get; set; }
    }
}
