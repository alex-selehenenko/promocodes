using Promocodes.Business.Core.Dto.Reviews;
using Promocodes.Business.Core.ServiceInterfaces.Behaviors;
using System.Threading.Tasks;

namespace Promocodes.Business.Core.ServiceInterfaces
{
    public interface IReviewService : ICanGet<ReviewDto, int>, ICanEdit<ReviewDto, EditReviewDto>, ICanCreate<ReviewDto, CreateReviewDto>, ICanDelete<int>
    {
    }
}
