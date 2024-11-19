using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using MyRemember.Application.Interfaces;
using MyRemember.Domain.Entities.MyRemember;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyRemember.Persistence
{
    public partial class MyRememberDbContext : DbContext, IMyRememberDbContext
    {
        public MyRememberDbContext(DbContextOptions<MyRememberDbContext> options) : base(options)
        {
        }

        public DbSet<MrTask> MrTasks { get; set; } = null!;

        //public DatabaseFacade Database => throw new NotImplementedException();

        //public Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        //{
        //    throw new NotImplementedException();
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
