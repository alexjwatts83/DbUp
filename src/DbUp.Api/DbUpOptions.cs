namespace DbUp.Api
{
    internal class DbUpOptions
    {
        public string DbConnectionString { get; set; }
        public string MasterDb { get; set; }
        public string MainDbName { get; set; }
    }
}
