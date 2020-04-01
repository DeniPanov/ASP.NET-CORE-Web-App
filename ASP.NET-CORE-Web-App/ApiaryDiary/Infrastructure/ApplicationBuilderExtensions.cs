namespace ApiaryDiary.Infrastructure
{
    using ApiaryDiary.Data;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseExceptionHandling(
            this IApplicationBuilder app,
            IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            return app;
        }

        public static IApplicationBuilder UseEndPoints(this IApplicationBuilder app)
        {
            return app.UseEndpoints(endpoints =>
                 {
                     endpoints.MapControllerRoute(
                         name: "default",
                         pattern: "{controller=Home}/{action=Index}/{id?}");

                     endpoints.MapRazorPages();
                 });
        }

        public static IApplicationBuilder SeedData(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetRequiredService<ApiaryDiaryDbContext>();

                if (env.IsDevelopment())
                {
                    dbContext.Database.Migrate();
                }

                 // new ApplicationDbContextSeeder().SeedAsync(dbContext, serviceScope.ServiceProvider).GetAwaiter().GetResult();
            }

            return app;
        }
    }
}
