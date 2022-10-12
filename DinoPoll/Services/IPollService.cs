using DinoPoll.Data;

namespace DinoPoll.Services
{
    public interface IPollService
    {
        Task CreatePoll(Poll poll);
    }
}