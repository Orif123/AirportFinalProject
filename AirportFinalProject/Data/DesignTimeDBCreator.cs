using Airport.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace AirportFinalProject.Data
{
    class DesignTimeDBCreator: IDesignTimeDbContextFactory<ProjectContext>
    {
        public ProjectContext CreateDbContext(string[] args)
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlServer("Server=DESKTOP-EKQUKID;Database=AirportData;Trusted_Connection=True;").Options;
            return new ProjectContext(options);

        }
    }
}
