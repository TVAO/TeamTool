using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using TeamTool.Models.Entities;

namespace TeamTool.Models.Interfaces
{
    public interface IContext : IDisposable
    {
        DbSet<Member> Members { get; set; }

        DbSet<Project> Projects { get; set; }

        DbSet<Team> Teams { get; set; }
        DatabaseFacade Database { get; }

        DbSet<T> Set<T>() where T : class;

        Task<int> SaveChangesAsync(CancellationToken token = default(CancellationToken));
    }
}
