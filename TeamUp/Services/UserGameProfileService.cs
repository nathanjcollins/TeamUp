using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using TeamUp.Data;
using TeamUp.Data.Models;

namespace TeamUp.Services;

public class UserGameProfileService
{
    private readonly IMemoryCache _cache;
    private readonly ApplicationDbContext _dbContext;

    public UserGameProfileService(IMemoryCache cache, ApplicationDbContext dbContext)
    {
        _cache = cache;
        _dbContext = dbContext;
    }

    public async Task<List<UserGameProfile>> GetGameProfilesByUserIdAsync(string userId)
    {
        return (await GetAllAsync())
            .Where(x => x.UserId == userId)
            .ToList();
    }

    public async Task<UserGameProfile?> GetByIdAsync(int id)
    {
        return (await GetAllAsync()).SingleOrDefault(x => x.Id == id);
    }

    private async Task<List<UserGameProfile>> GetAllAsync()
    {
        if (!_cache.TryGetValue(CacheKeys.GamePlatforms, out List<UserGameProfile>? cacheValue))
        {
            cacheValue = await _dbContext.UserGameProfiles
                .Include(x => x.UserGameProfilePositions)!
                    .ThenInclude(x => x.Position)
                        .ThenInclude(x => x.Game)
                .Include(x => x.Rank)
                .Where(x => !x.IsDeleted)
                .ToListAsync();

            _cache.Set(CacheKeys.GamePlatforms, cacheValue);
        }

        return cacheValue!;
    }
}