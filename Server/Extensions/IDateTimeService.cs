namespace Server.Extensions
{
    public interface IDateTimeService
    {
        DateTime NowUtc { get; }
    }

    public class DateTimeService : IDateTimeService
    {
        public DateTime NowUtc => DateTime.UtcNow;
    }
}
