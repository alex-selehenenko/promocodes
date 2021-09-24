namespace Promocodes.Data.Core.Common
{
    public interface IPage<T>
    {
        T[] Content { get; }

        int TotalPages { get; }

        int IndexPage { get; }
    }
}
