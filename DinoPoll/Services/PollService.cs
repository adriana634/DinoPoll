using DinoPoll.Data;
using Microsoft.EntityFrameworkCore;

namespace DinoPoll.Services
{
    public class PollService : IPollService
    {
        private readonly IDbContextFactory<DinoPollContext> DbFactory;

        public PollService(IDbContextFactory<DinoPollContext> dbFactory)
        {
            DbFactory = dbFactory;
        }

        public async Task CreatePoll(Poll poll)
        {
            using var context = DbFactory.CreateDbContext();

            context.Polls.Add(poll);
            await context.SaveChangesAsync();
        }
    }
}
