namespace Promocodes.Data.Entities.Pagination
{
    public interface IPage<T>
    {
        T[] Content { get; }

        int TotalPages { get; }

        int IndexPage { get; }
    }
}
