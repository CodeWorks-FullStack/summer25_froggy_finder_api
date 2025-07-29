using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace froggy_finder_api;

public class Program
{
  // NOTE entry point
  public static void Main(string[] args)
  {
    CreateHostBuilder(args).Build().Run();
  }

  public static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
    .ConfigureWebHostDefaults(webBuilder =>
    {
      webBuilder.UseStartup<Startup>();
    });
}

