using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore;
using MyRemember.Domain.Entities.MyRemember;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyRemember.Domain.Entities.Auth;

namespace MyRemember.Application.Interfaces
{
    public interface IAuthDbContext
    {
        DbSet<AuthUser> AuthUser { get; set; }
        DbSet<AuthUserRefreshToken> AuthUserRefreshToken { get; set; }
        DbSet<AuthRole> AuthRole { get; set; }

        DatabaseFacade Database { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
