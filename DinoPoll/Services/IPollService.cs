using DinoPoll.Data;

namespace DinoPoll.Services
{
    public interface IPollService
    {
        Task CreatePoll(Poll poll);
        Task<Poll?> GetPoll(Guid id);
        Task VoteOption(Guid pollId, int optionId);
    }
}