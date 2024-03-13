namespace Productos.Domain.Ports
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository product { get; }
        ICategoryRepository category { get; }

        Task SaveAsync();
    }
}