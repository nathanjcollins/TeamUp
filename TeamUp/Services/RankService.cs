using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using TeamUp.Data;
using TeamUp.Data.Models;
using TeamUp.Pages.Admin.Games.Models;

namespace TeamUp.Services;

public class RankService
{
    private readonly IMemoryCache _cache;
    private readonly ApplicationDbContext _dbContext;

    public RankService(IMemoryCache cache, ApplicationDbContext dbContext)
    {
        _cache = cache;
        _dbContext = dbContext;
    }

    public async Task<List<Rank>> GetByGameIdAsync(int gameId)
    {
        return (await GetAllAsync())
            .Where(x => x.GameId == gameId)
            .ToList();
    }

    public async Task<Rank> UpdateAsync(RankModel rankModel)
    {
        var rank = rankModel.Id.HasValue
            ? (await GetAllAsync()).Single(x => x.Id == rankModel.Id.Value)
            : new Rank { GameId = rankModel.GameId };

        rank.Name = rankModel.Name;

        _dbContext.Update(rank);
        await _dbContext.SaveChangesAsync();
        
        InvalidateCache();

        return rank;
    }

    private async Task<List<Rank>> GetAllAsync()
    {
        if (!_cache.TryGetValue(CacheKeys.Ranks, out List<Rank>? cacheValue))
        {
            cacheValue = await _dbContext.Ranks
                .Where(x => !x.IsDeleted)
                .ToListAsync();

            _cache.Set(CacheKeys.Ranks, cacheValue);
        }

        return cacheValue!;
    }
    
    public async Task DeleteByIdAsync(int id)
    {
        var rank = (await GetAllAsync()).Single(x => x.Id == id);

        if (rank is null)
        {
            throw new ArgumentException(null, nameof(id));
        }

        rank.IsDeleted = true;

        _dbContext.Update(rank);
        await _dbContext.SaveChangesAsync();

        InvalidateCache();
    }

    public async Task UndoDeleteByIdAsync(int id)
    {
        var rank = await _dbContext.Ranks.SingleOrDefaultAsync(x => x.Id == id);

        if (rank is null)
        {
            throw new ArgumentException(null, nameof(id));
        }

        rank.IsDeleted = false;

        _dbContext.Update(rank);
        await _dbContext.SaveChangesAsync();
        
        InvalidateCache();
    }

    private void InvalidateCache()
    {
        _cache.Remove(CacheKeys.Ranks);
    }
}