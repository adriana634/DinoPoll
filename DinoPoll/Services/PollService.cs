using DinoPoll.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace DinoPoll.Services
{
    public class PollService : IPollService
    {
        private readonly IDbContextFactory<DinoPollContext> DbFactory;
        private readonly IMemoryCache MemoryCache;

        public PollService(IDbContextFactory<DinoPollContext> dbFactory, IDinoPollCache memoryCache)
        {
            DbFactory = dbFactory;
            MemoryCache = memoryCache.Cache;
        }

        public async Task CreatePoll(Poll poll)
        {
            using var context = DbFactory.CreateDbContext();

            context.Polls.Add(poll);
            await context.SaveChangesAsync();
        }

        public Task<Poll?> GetPoll(Guid id)
        {
            return MemoryCache.GetOrCreateAsync(id, async cacheEntry =>
            {
                cacheEntry.SetOptions(new MemoryCacheEntryOptions
                {
                    Size = 50,
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(30)
                });

                using var context = DbFactory.CreateDbContext();

                var poll = await context.Polls
                    .Include(poll => poll.Options.OrderBy(option => option.Order))
                    .SingleOrDefaultAsync(poll => poll.PollId == id);

                return poll;
            });
        }

        public async Task VoteOption(Guid pollId, int optionId)
        {
            using var context = DbFactory.CreateDbContext();
            using var transaction = await context.Database.BeginTransactionAsync();

            try
            {
                var poll = await context.Polls
                        .Include(poll => poll.Options)
                        .SingleOrDefaultAsync(poll => poll.PollId == pollId);

                if (poll is not null)
                {
                    var option = poll.Options.Single(option => option.OptionId == optionId);
                    option.Votes += 1;

                    await context.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
}
