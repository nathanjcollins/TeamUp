using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using TeamUp.Data;
using TeamUp.Data.Models;
using TeamUp.Shared.Components.Forms.Models;

namespace TeamUp.Services;

public class PlatformService
{
    private readonly IMemoryCache _cache;
    private readonly ApplicationDbContext _dbContext;

    public PlatformService(IMemoryCache cache, ApplicationDbContext dbContext)
    {
        _cache = cache;
        _dbContext = dbContext;
    }

    public async Task<int> CountAsync()
    {
        return (await GetAllAsync()).Count;
    }

    public async Task<List<Platform>> GetAllAsync()
    {
        if (!_cache.TryGetValue(CacheKeys.Platforms, out List<Platform>? cacheValue))
        {
            cacheValue = await _dbContext.Platforms.Where(x => !x.IsDeleted).ToListAsync();

            _cache.Set(CacheKeys.Platforms, cacheValue);
        }

        return cacheValue!;
    }

    public async Task<Platform?> GetByIdAsync(int id)
    {
        var platforms = await GetAllAsync();

        return platforms.SingleOrDefault(x => x.Id == id);
    }

    public async Task<Platform> UpdateAsync(PlatformModel platformModel)
    {
        var platform = platformModel.Id.HasValue ? await GetByIdAsync(platformModel.Id.Value) : new Platform();

        platform!.Name = platformModel.Name;

        _dbContext.Update(platform);
        await _dbContext.SaveChangesAsync();
        
        InvalidateCache();

        return platform;
    }

    public async Task DeleteByIdAsync(int id)
    {
        var platform = await GetByIdAsync(id);

        if (platform is null)
        {
            throw new ArgumentException(null, nameof(id));
        }

        platform.IsDeleted = true;

        _dbContext.Update(platform);
        await _dbContext.SaveChangesAsync();
        
        InvalidateCache();
    }
    
    public async Task UndoDeleteByIdAsync(int id)
    {
        var platform = await _dbContext.Platforms.SingleOrDefaultAsync(x => x.Id == id);

        if (platform is null)
        {
            throw new ArgumentException(null, nameof(id));
        }

        platform.IsDeleted = false;

        _dbContext.Update(platform);
        await _dbContext.SaveChangesAsync();
        
        InvalidateCache();
    }

    private void InvalidateCache()
    {
        _cache.Remove(CacheKeys.Platforms);
    }
}