namespace HomeAutomationLibraryTests.Mocks
{
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;
    using global::HomeAutomationClient;
    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc.Testing;

    public class MockWebApplicationFactory<TStartup>
        : WebApplicationFactory<Startup>
    {
    }
}
