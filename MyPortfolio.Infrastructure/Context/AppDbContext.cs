
using Application.Contract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using MyPortfolio.Domain.Entities;

namespace MyPortfolio.Infrastructure.Context
{
    public class AppDbContext : DbContext, IContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<ProfileEntity> Profiles { get; set; }
        public DbSet<SkillEntity> Skills { get; set; }
        public DbSet<WorkExperienceEntity> WorkExperiences { get; set; }
        public DbSet<EducationEntity> Educations { get; set; }
        public DbSet<ProjectEntity> Projects { get; set; }
        public DbSet<ContactMessageEntity> ContactMessages { get; set; }
        public DbSet<AboutEntity> Abouts { get; set; }

        public DbSet<LanguageEntity> Languages { get; set; }
       

        public IExecutionStrategy CreateExecutionStrategy()
        {
            return Database.CreateExecutionStrategy();
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await Database.BeginTransactionAsync();
        }

        public void ClearTracker()
        {
            ChangeTracker.Clear();
        }

        public IQueryable<TEntity> GetQueryable<TEntity>() where TEntity : class
        {
            return Set<TEntity>().AsQueryable();
        }

        public DbSet<TEntity> Entity<TEntity>() where TEntity : class
        {
            return Set<TEntity>();
        }

        public async Task SaveChangesAsync()
        {
            await base.SaveChangesAsync();
        }
    }




}

