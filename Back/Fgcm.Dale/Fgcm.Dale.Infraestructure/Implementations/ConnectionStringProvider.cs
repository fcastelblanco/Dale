using Fgcm.Dale.Infraestructure.Definitions;

namespace Fgcm.Dale.Infraestructure.Implementations
{
    public class ConnectionStringProvider : IConnectionStringProvider
    {
        public ConnectionStringProvider(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public string ConnectionString { get; }
    }
}