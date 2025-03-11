using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using RestAPI.Data;
using RestAPI.Models.Entity;
using RestAPI.Repository.IRepository;

namespace RestAPI.Repository
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMemoryCache _cache;
        private readonly string PedidoCacheKey = "PedidoCacheKey";
        private readonly int CacheExpirationTime = 3600;
        public PedidoRepository(ApplicationDbContext context, IMemoryCache cache)
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
            _cache.Remove(PedidoCacheKey);
        }

        public async Task<ICollection<PedidoEntity>> GetAllAsync()
        {
            if (_cache.TryGetValue(PedidoCacheKey, out ICollection<PedidoEntity> pedidosCached))
                return pedidosCached;

            var pedidosFromDb = await _context.Pedidos.OrderBy(c => c.Id).ToListAsync();
            var cacheEntryOptions = new MemoryCacheEntryOptions()
                  .SetAbsoluteExpiration(TimeSpan.FromSeconds(CacheExpirationTime));

            _cache.Set(PedidoCacheKey, pedidosFromDb, cacheEntryOptions);
            return pedidosFromDb;
        }

        public async Task<PedidoEntity> GetAsync(int id)
        {
            if (_cache.TryGetValue(PedidoCacheKey, out ICollection<PedidoEntity> pedidoCached))
            {
                var pedidos = pedidoCached.FirstOrDefault(c => c.Id == id);
                if (pedidos != null)
                    return pedidos;
            }

            return await _context.Pedidos.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Pedidos.AnyAsync(c => c.Id == id);
        }

        public async Task<bool> CreateAsync(PedidoEntity pedido)
        {
            _context.Pedidos.Add(pedido);
            return await Save();
        }

        public async Task<bool> UpdateAsync(PedidoEntity pedido)
        {
            _context.Update(pedido);
            return await Save();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var pedido = await GetAsync(id);
            if (pedido == null)
                return false;

            _context.Pedidos.Remove(pedido);
            return await Save();
        }
    }
}
