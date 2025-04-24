namespace DynamicFlow.Models.Generic
{
    public class CacheConfigurations
    {
        public int AbsoluteExpirationTime { get; set; } = 30;
        public int SlidingExpiration { get; set; } = 30;
    }
   
}
