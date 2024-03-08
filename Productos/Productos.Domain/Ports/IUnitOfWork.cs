namespace Productos.Domain.Ports
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository product { get; }
        ICategoryRepository category { get; }
        IProductDetailsRepository productDetails { get; }

        Task SaveAsync();

    }
}
