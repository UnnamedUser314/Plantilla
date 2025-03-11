using RestAPI.Models.Entity;

namespace RestAPI.Repository.IRepository
{
    public interface IProductoRepository : IRepository<ProductoEntity>
    {
        Task<ICollection<ProductoEntity>> GetByNameAsync(string id);
    }
}
