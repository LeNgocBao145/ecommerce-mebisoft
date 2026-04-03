namespace ProductService.Application.Common
{
    public class PagedResponse<T>
    {
        public IReadOnlyList<T> Data { get; init; } = [];
        public required PagedMetadata Metadata { get; init; }
    }
}
