using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using RestAPI.Data;
using RestAPI.Models.Entity;
using RestAPI.Repository.IRepository;

namespace RestAPI.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMemoryCache _cache;
        private readonly string UsuarioCacheKey = "UsuarioCacheKey";
        private readonly int CacheExpirationTime = 3600;
        public UsuarioRepository(ApplicationDbContext context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
        }

        public async Task<bool> Save()
        {
            var result = await _context.SaveChangesAsync() >= 0;
            if (result)
            {
                ClearPedidoCache();
            }
            return result;
        }

        public void ClearPedidoCache()
        {
            _cache.Remove(UsuarioCacheKey);
        }

        public async Task<ICollection<UsuarioEntity>> GetAllAsync()
        {
            if (_cache.TryGetValue(UsuarioCacheKey, out ICollection<UsuarioEntity> usuariosCached))
                return usuariosCached;

            var usuariosFromDb = await _context.Usuarios.OrderBy(c => c.Id).ToListAsync();
            var cacheEntryOptions = new MemoryCacheEntryOptions()
                  .SetAbsoluteExpiration(TimeSpan.FromSeconds(CacheExpirationTime));

            _cache.Set(UsuarioCacheKey, usuariosFromDb, cacheEntryOptions);
            return usuariosFromDb;
        }

        public async Task<UsuarioEntity> GetAsync(int id)
        {
            if (_cache.TryGetValue(UsuarioCacheKey, out ICollection<UsuarioEntity> usuarioCached))
            {
                var usuarios = usuarioCached.FirstOrDefault(c => c.Id == id);
                if (usuarios != null)
                    return usuarios;
            }

            return await _context.Usuarios.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<ICollection<UsuarioEntity>> GetByNameAsync(string name)
        {
            return await _context.Usuarios
                .Where(p => p.Nombre.Contains(name))
                .ToListAsync();
        }

        public async Task<UsuarioEntity> GetByIdAsync(int id)
        {
            return await _context.Usuarios
                .FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Usuarios.AnyAsync(c => c.Id == id);
        }

        public async Task<bool> CreateAsync(UsuarioEntity usuario)
        {
            _context.Usuarios.Add(usuario);
            return await Save();
        }

        public async Task<bool> UpdateAsync(UsuarioEntity usuario)
        {
            _context.Update(usuario);
            return await Save();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var usuario = await GetAsync(id);
            if (usuario == null)
                return false;

            _context.Usuarios.Remove(usuario);
            return await Save();
        }
    }
}
