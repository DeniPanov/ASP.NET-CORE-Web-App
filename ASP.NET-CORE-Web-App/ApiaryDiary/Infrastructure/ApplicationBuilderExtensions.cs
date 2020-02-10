namespace ApiaryDiary.Infrastructure
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
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
    }
}
