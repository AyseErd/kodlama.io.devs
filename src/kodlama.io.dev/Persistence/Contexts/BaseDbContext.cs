using Core.Security.Entities;
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
        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }

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
            modelBuilder.Entity<User>(u =>
                {
                    u.ToTable("Users").HasKey(k => k.Id);
                    u.Property(p => p.Id).HasColumnName("Id");
                    u.Property(p => p.FirstName).HasColumnName("FirstName");
                    u.Property(p => p.LastName).HasColumnName("LastName");
                    u.Property(p => p.Email).HasColumnName("Email");
                    u.Property(p => p.PasswordSalt).HasColumnName("PasswordSalt");
                    u.Property(p => p.PasswordHash).HasColumnName("PasswordHash");
                    u.Property(p => p.Status).HasColumnName("Status");
                    u.Property(p => p.AuthenticatorType).HasColumnName("AuthenticatorType");
                    u.HasMany(p=>p.RefreshTokens);
                    u.HasMany(p => p.UserOperationClaims);
                }
            );
            modelBuilder.Entity<OperationClaim>(oc =>
            {
                oc.ToTable("OperationClaims").HasKey(k => k.Id);
                oc.Property(p => p.Id).HasColumnName("Id");
                oc.Property(p => p.Name).HasColumnName("Name");
            });
            modelBuilder.Entity<UserOperationClaim>(oc =>
            {
                oc.ToTable("UserOperationClaims").HasKey(k => k.Id);
                oc.Property(p => p.Id).HasColumnName("Id");
                oc.Property(p => p.UserId).HasColumnName("UserId");
                oc.Property(p => p.OperationClaimId).HasColumnName("OperationClaimId");
                oc.HasOne(p => p.User);
                oc.HasOne(p => p.OperationClaim);
            });
            modelBuilder.Entity<RefreshToken>(rt =>
            {
                rt.ToTable("RefreshTokens").HasKey(k => k.Id);
                rt.Property(p => p.Id).HasColumnName("Id");
                rt.Property(p => p.UserId).HasColumnName("UserId");
                rt.HasOne(p => p.User);
                rt.Property(p => p.Token).HasColumnName("Token");
                rt.Property(p => p.Expires).HasColumnName("Expires");
                rt.Property(p => p.Created).HasColumnName("Created");
                rt.Property(p => p.CreatedByIp).HasColumnName("CreatedByIp");
                rt.Property(p => p.Revoked).HasColumnName("Revoked");
                rt.Property(p => p.RevokedByIp).HasColumnName("RevokedByIp");
                rt.Property(p => p.ReplacedByToken).HasColumnName("ReplacedByToken");
                rt.Property(p => p.ReasonRevoked).HasColumnName("ReasonRevoked");
            });

            ProgLanguage[] progLanguageSeeds = { new(1, "C"), new(2, "C++"), new(3, "Java") , new(4, "C#"), new(5, "JavaScript") };
            modelBuilder.Entity<ProgLanguage>().HasData(progLanguageSeeds);
            LanguageFramework[] languageFrameworkEntitySeeds = { new(1, 3, "JSP", "3.1"), new(2, 4, "ASP.NET", "4.7") };
            modelBuilder.Entity<LanguageFramework>().HasData(languageFrameworkEntitySeeds);

            OperationClaim[] operationClaimsEntitySeeds = { new(1, "SystemAdmin"), new(2, "Admin") ,new(3,"User")};
            modelBuilder.Entity<OperationClaim>().HasData(operationClaimsEntitySeeds);
        }
    }
}
