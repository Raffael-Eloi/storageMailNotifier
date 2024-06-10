using Microsoft.Extensions.Hosting;
using StorageMailNotifier.Infrastructure.IoC;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureServices(services => services.AddServicesDependencies())
    .Build();

host.Run();