using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Persistence.Contexts
{
    public class BaseDbContext : DbContext
    {
        protected IConfiguration Configuration { get; set; }
        public DbSet<ProgLanguage> ProgrammingLanguages { get; set; }
        public DbSet<LanguageFramework> LanguageFrameworks { get; set; }

        public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            //if (!optionsBuilder.IsConfigured)
            //    base.OnConfiguring(
            //        optionsBuilder.UseSqlServer(Configuration.GetConnectionString("SomeConnectionString")));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProgLanguage>(a =>
            {
                a.ToTable("ProgrammingLanguages").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.Name).HasColumnName("Name");
                a.HasMany(p=>p.LanguageFrameworks);
            });


            modelBuilder.Entity<LanguageFramework>(a =>
            {
                a.ToTable("LanguageFrameworks").HasKey(k => k.Id);
                a.Property(l => l.Id).HasColumnName("Id");
                a.Property(l => l.ProgrammingLanguageId).HasColumnName("ProgrammingLanguageId");
                a.Property(l => l.Name).HasColumnName("Name");
                a.Property(l => l.Version).HasColumnName("Version").IsRequired(false);
                a.HasOne(l => l.ProgrammingLanguage);
            });


            ProgLanguage[] progLanguageSeeds = { new(1, "C"), new(2, "C++"), new(3, "Java") , new(4, "C#"), new(5, "JavaScript") };
            modelBuilder.Entity<ProgLanguage>().HasData(progLanguageSeeds);
            LanguageFramework[] languageFrameworkEntitySeeds = { new(1, 3, "JSP", "3.1"), new(2, 4, "ASP.NET", "4.7") };
            modelBuilder.Entity<LanguageFramework>().HasData(languageFrameworkEntitySeeds);
        }
    }
}
