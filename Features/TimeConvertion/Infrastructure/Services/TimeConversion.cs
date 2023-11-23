using VerticalSliceArch.Domain.DTOs;

namespace VerticalSliceArch.Features.TimeConvertion.Infrastructure.Services
{
    public class TimeConversionService : ITimeConversionService
    {
        public TimeDto ConvertSeconds(int seconds)
        {
            var minutes = seconds / 60;
            var hours = minutes / 60;
            return new TimeDto()
            {
                Hours = hours,
                Minutes = minutes % 60,
                Seconds = seconds % 60
            };
        }
    }

    public interface ITimeConversionService
    {
        TimeDto ConvertSeconds(int seconds);
    }
}