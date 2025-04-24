namespace DynamicFlow.Service.Common.Generic
{
    public class ServiceDatabaseConnection
    {
        public string DefaultConnectionString
        {
            get
            {
                return _DataBaseConnectionString;
            }
            set
            {
                _DataBaseConnectionString = value;
            }
        }

        private string _DataBaseConnectionString = string.Empty;
    }
}
