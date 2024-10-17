using Microsoft.EntityFrameworkCore;
using MyRemember.Application.Interfaces;
using MyRemember.Domain.Entities.Auth;
using MyRemember.Domain.Entities.MyRemember;
using MyRemember.Infrastructure.Data.MyRemember;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyRemember.Infrastructure.Data.Auth
{
    public partial class AuthDbContext : DbContext, IAuthDbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {
        }

        public virtual DbSet<AuthUser> AuthUser { get; set; } = null!;
        public virtual DbSet<AuthUserRefreshToken> AuthUserRefreshToken { get; set; } = null!;
        public virtual DbSet<AuthRole> AuthRole { get; set; } = null!;


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
