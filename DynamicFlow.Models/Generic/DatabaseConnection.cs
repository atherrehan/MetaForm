namespace DynamicFlow.Models.Generic
{
    public class DatabaseConnection
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
