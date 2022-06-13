using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using TeamUp.Data;
using TeamUp.Data.Models;
using TeamUp.Pages.Admin.Games.Models;

namespace TeamUp.Services;

public class PositionService
{
    private readonly IMemoryCache _cache;
    private readonly ApplicationDbContext _dbContext;

    public PositionService(IMemoryCache cache, ApplicationDbContext dbContext)
    {
        _cache = cache;
        _dbContext = dbContext;
    }

    public async Task<List<Position>> GetByGameIdAsync(int gameId)
    {
        return (await GetAllAsync())
            .Where(x => x.GameId == gameId)
            .ToList();
    }

    public async Task<Position> UpdateAsync(PositionModel positionModel)
    {
        var position = positionModel.Id.HasValue
            ? (await GetAllAsync()).Single(x => x.Id == positionModel.Id.Value)
            : new Position { GameId = positionModel.GameId };

        position.Name = positionModel.Name;

        _dbContext.Update(position);
        await _dbContext.SaveChangesAsync();
        
        InvalidateCache();

        return position;
    }

    private async Task<List<Position>> GetAllAsync()
    {
        if (!_cache.TryGetValue(CacheKeys.Positions, out List<Position>? cacheValue))
        {
            cacheValue = await _dbContext.Positions
                .Where(x => !x.IsDeleted)
                .ToListAsync();

            _cache.Set(CacheKeys.Positions, cacheValue);
        }

        return cacheValue!;
    }

    private void InvalidateCache()
    {
        _cache.Remove(CacheKeys.Positions);
    }
}