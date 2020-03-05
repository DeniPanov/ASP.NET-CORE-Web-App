namespace ApiaryDiary.Data
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

    using ApiaryDiary.Data.Models;

    public class ApiaryDiaryDbContext : IdentityDbContext<ApplicationUser>
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
        public DbSet<ApplicationUser> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Apiary>(entity =>
            {
                entity.HasMany(b => b.Beehives)
                    .WithOne(a => a.Apiary)
                    .HasForeignKey(a => a.ApiaryId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<Apiary>(entity =>
            {
                entity.HasMany(l => l.Locations)
                    .WithOne(a => a.Apiary)
                    .HasForeignKey(a => a.ApiaryId)
                    .OnDelete(DeleteBehavior.Restrict);

            });
            
            builder.Entity<Beehive>(entity =>
            {
                entity.HasMany(i => i.Inspections)
                    .WithOne(b => b.Beehive)
                    .HasForeignKey(b => b.BeehiveId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<Beehive>(entity =>
            {
                entity.HasMany(s => s.Statistics)
                    .WithOne(b => b.Beehive)
                    .HasForeignKey(b => b.BeehiveId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<Beehive>(entity =>
            {
                entity.HasMany(q => q.QueenBees)
                    .WithOne(b => b.Beehive)
                    .HasForeignKey(b => b.BeehiveId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            //builder.Entity<IdentityUser>(entity =>
            //{
            //    entity.HasMany(a => a.QueenBees)
            //        .WithOne(b => b.Beehive)
            //        .HasForeignKey(b => b.BeehiveId)
            //        .OnDelete(DeleteBehavior.Restrict);
            //});
        }
    }
}
