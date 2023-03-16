namespace WebApplication1.Services
{
    public class SystemTime : ISystemTime
    {
        public DateTime GetCurrent()
        {
            return DateTime.Now;
        }
    }
}
