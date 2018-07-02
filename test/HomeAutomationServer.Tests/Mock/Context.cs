using HomeAutomationServer.Data;
using HomeAutomationServer.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeAutomationServer.Tests.Mock
{
    public class Context 
    {
        public ApplicationDbContext CreateContext(string inMemoryName)
        {
            var options = OptionsBuilder(inMemoryName);
            return new ApplicationDbContext(options.Options);
        }
        private DbContextOptionsBuilder<ApplicationDbContext> OptionsBuilder(string inMemoryName)
        {
            return new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(inMemoryName);
        }

        public async Task CleanDb(ApplicationDbContext context)
        {
            await context.Database.EnsureDeletedAsync();
            await context.Database.EnsureCreatedAsync();
        }
    }
}
