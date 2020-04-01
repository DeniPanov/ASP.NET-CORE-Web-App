using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(ApiaryDiary.Areas.Identity.IdentityHostingStartup))]

namespace ApiaryDiary.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
            });
        }
    }
}
