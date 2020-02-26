namespace ApiaryDiary.Data
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

    using ApiaryDiary.Data.Models;

    public class ApiaryDiaryDbContext : IdentityDbContext
    {
        public ApiaryDiaryDbContext(DbContextOptions<ApiaryDiaryDbContext> options)
            : base(options)
        {
        }

        public DbSet<Apiary> Apiaries { get; set; }
        public DbSet<Beehive> Beehives { get; set; }
        public DbSet<Inspection> Inspections { get; set; }
        public DbSet<LocationInfo> Locations { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<QueenBee> QueenBees { get; set; }
        public DbSet<Statistics> Statistics { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
