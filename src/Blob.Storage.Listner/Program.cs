using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using StorageMailNotifier.Infrastructure.IoC;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureAppConfiguration((context, builder) =>
    {
        builder
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        .AddJsonFile($"appsettings.{context.HostingEnvironment.EnvironmentName}.json", optional: true)
        .AddEnvironmentVariables();
    })
    .ConfigureServices(services => services.AddServicesDependencies())
    .Build();

host.Run();