namespace ApiaryDiary.Infrastructure
{
    using Microsoft.AspNetCore.Builder;

    public static class ApplicationBuilderExtensions
    {
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
