namespace DynamicFlow.Service.Common.Generic
{
    public class CacheConfiguraiton
    {
        public int AbsoluteExpirationTime { get; set; } = 30;
        public int SlidingExpiration { get; set; } = 30;
    }
}
