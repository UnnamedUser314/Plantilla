using RestAPI.Models.Entity;

namespace RestAPI.Repository.IRepository
{
    public interface IUsuarioRepository : IRepository<UsuarioEntity>
    {
        Task<ICollection<UsuarioEntity>> GetByNameAsync(string id);
        Task<UsuarioEntity> GetByIdAsync(int id);
    }
}
