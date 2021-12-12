using Airport.Data;
using Microsoft.EntityFrameworkCore;

namespace AirportFinalProject.Services.Flight.Creator
{
    public class ContextFactory
    {
        private readonly string _connectionString;
        public ContextFactory(string connectionString)
        {
            _connectionString = connectionString;
        }
        public ProjectContext CreateDBContext()
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlServer(_connectionString).Options;
            return new ProjectContext(options);
        }
    }
}