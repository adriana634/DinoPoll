using AutoMapper;
using DinoPoll.Data;
using DinoPoll.Forms;

namespace DinoPoll.Mapper
{
    public class PollProfile : Profile
    {
        public PollProfile()
        {
            CreateMap<NewOption, Option>();
            CreateMap<NewPoll, Poll>()
                .AfterMap((src, dest) =>
                {
                    byte order = 1;
                    
                    foreach (var option in dest.Options)
                    {
                        option.Order = order++;
                    }
                });
        }
    }
}
