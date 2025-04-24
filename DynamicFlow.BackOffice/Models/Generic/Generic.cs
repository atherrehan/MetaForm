namespace DynamicFlow.BackOffice.Models.Generic
{
    public class KeyValueGeneric
    {
        public int? Key { get; set; }
        public string Value { get; set; } = string.Empty;
    }
    public class KeyValueStringGeneric
    {
        public string Key { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
    }
    public class GenericResponse
    {
        public string ResponseCode { get; set; } = string.Empty;
        public string ResponseMessage { get; set; } = string.Empty;
    }
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
    public class ApiHeaders
    {
        public string Key { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
    }
    public enum RequestType
    {
        GET = 1,
        POST = 2
    }
}
