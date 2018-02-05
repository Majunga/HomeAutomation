using HomeAutomationServer.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
