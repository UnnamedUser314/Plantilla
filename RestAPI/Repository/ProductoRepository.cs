using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using RestAPI.Data;
using RestAPI.Models.Entity;
using RestAPI.Repository.IRepository;

namespace RestAPI.Repository
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMemoryCache _cache;
        private readonly string ProductoCacheKey = "ProductoCacheKey";
        private readonly int CacheExpirationTime = 3600;
        public ProductoRepository(ApplicationDbContext context, IMemoryCache cache)
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
            _cache.Remove(ProductoCacheKey);
        }

        public async Task<ICollection<ProductoEntity>> GetAllAsync()
        {
            if (_cache.TryGetValue(ProductoCacheKey, out ICollection<ProductoEntity> productosCached))
                return productosCached;

            var productosFromDb = await _context.Productos.OrderBy(c => c.Id).ToListAsync();
            var cacheEntryOptions = new MemoryCacheEntryOptions()
                  .SetAbsoluteExpiration(TimeSpan.FromSeconds(CacheExpirationTime));

            _cache.Set(ProductoCacheKey, productosFromDb, cacheEntryOptions);
            return productosFromDb;
        }

        public async Task<ProductoEntity> GetAsync(int id)
        {
            if (_cache.TryGetValue(ProductoCacheKey, out ICollection<ProductoEntity> productoCached))
            {
                var productos = productoCached.FirstOrDefault(c => c.Id == id);
                if (productos != null)
                    return productos;
            }

            return await _context.Productos.FirstOrDefaultAsync(c => c.Id == id);
        }
       
        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Productos.AnyAsync(c => c.Id == id);
        }

        public async Task<bool> CreateAsync(ProductoEntity producto)
        {
            _context.Productos.Add(producto);
            return await Save();
        }

        public async Task<bool> UpdateAsync(ProductoEntity producto)
        {
            _context.Update(producto);
            return await Save();
        }

        public async Task<ICollection<ProductoEntity>> GetByNameAsync(string name)
        {
            return await _context.Productos
                .Where(p => p.Nombre.Contains(name))
                .ToListAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var producto = await GetAsync(id);
            if (producto == null)
                return false;

            _context.Productos.Remove(producto);
            return await Save();
        }
    }
}
