using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using TeamUp.Data;
using TeamUp.Data.Models;
using TeamUp.Shared.Components.Forms.Models;

namespace TeamUp.Services;

public class GameService
{
    private IMemoryCache _cache;
    private readonly ApplicationDbContext _dbContext;

    public GameService(IMemoryCache cache, ApplicationDbContext dbContext)
    {
        _cache = cache;
        _dbContext = dbContext;
    }

    public async Task<int> CountAsync()
    {
        return (await GetAllAsync()).Count;
    }

    public async Task<List<Game>> GetAllAsync()
    {
        if (!_cache.TryGetValue(CacheKeys.Games, out List<Game>? cacheValue))
        {
            cacheValue = await _dbContext.Games
                .Include(x => x.GamePlatforms.Where(y => !y.IsDeleted))
                .ThenInclude(x => x.Platform)
                .Where(x => !x.IsDeleted)
                .ToListAsync();

            _cache.Set(CacheKeys.Games, cacheValue);
        }

        return cacheValue!;
    }

    public async Task<Game?> GetByIdAsync(int id)
    {
        var games = await GetAllAsync();

        return games.SingleOrDefault(x => x.Id == id);
    }

    public async Task<Game> UpdateAsync(GameModel gameModel)
    {
        var game = gameModel.Id.HasValue ? await GetByIdAsync(gameModel.Id.Value) : new Game();

        game!.Name = gameModel.Name;

        _dbContext.Update(game);

        await _dbContext.SaveChangesAsync();

        await UpdateGamePlatforms(game.Id, gameModel.PlatformIds);

        InvalidateCache();

        return game;
    }

    public async Task DeleteByIdAsync(int id)
    {
        var game = await GetByIdAsync(id);

        if (game is null)
        {
            throw new ArgumentException(null, nameof(id));
        }

        game.IsDeleted = true;

        _dbContext.Update(game);
        await _dbContext.SaveChangesAsync();

        InvalidateCache();
    }

    public async Task UndoDeleteByIdAsync(int id)
    {
        var game = await _dbContext.Games.SingleOrDefaultAsync(x => x.Id == id);

        if (game is null)
        {
            throw new ArgumentException(null, nameof(id));
        }

        game.IsDeleted = false;

        _dbContext.Update(game);
        await _dbContext.SaveChangesAsync();
        
        InvalidateCache();
    }

    private void InvalidateCache()
    {
        _cache.Remove(CacheKeys.Games);
    }

    private async Task UpdateGamePlatforms(int gameId, IEnumerable<int> platformIds)
    {
        var gamePlatformsToUpdate = new List<GamePlatform>();

        var currentGamePlatforms = _dbContext.GamePlatforms
            .Where(x => x.GameId == gameId)
            .ToList();

        var newGamePlatforms = platformIds.ToList();

        var gamePlatformsToDelete = currentGamePlatforms
            .Where(x => newGamePlatforms.All(y => y != x.PlatformId));

        foreach (var gamePlatform in gamePlatformsToDelete)
        {
            gamePlatform.IsDeleted = true;
            gamePlatformsToUpdate.Add(gamePlatform);
        }

        var gamePlatformsToAdd = newGamePlatforms
            .Where(x => currentGamePlatforms.All(y => y.PlatformId != x));

        foreach (var platformId in gamePlatformsToAdd)
        {
            gamePlatformsToUpdate.Add(new GamePlatform { GameId = gameId, PlatformId = platformId });
        }

        if (gamePlatformsToUpdate.Any())
        {
            _dbContext.UpdateRange(gamePlatformsToUpdate);
        }

        await _dbContext.SaveChangesAsync();
    }
}