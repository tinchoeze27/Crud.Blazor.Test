namespace Blazor.Crud.Mappers
{
    public class ConnectionDB
    {
        public ConnectionDB(string connectionString) => ConnectionString = connectionString;
        public string ConnectionString { get; }
    }
}
