namespace SME.DynamicFlow.UI
{
    public static class AppConfig
    {
        public static string BaseUrl { get; set; } = string.Empty;
        public static void SetBaseUrl(string url)
        {
            BaseUrl = url;
        }
    }
}
