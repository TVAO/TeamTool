using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TeamTool.Models.Entities;
using TeamTool.Models.Interfaces;

namespace TeamTool.Models
{
    public class TeamContext : DbContext, IContext
    {

        public TeamContext(DbContextOptions<TeamContext> options) : base(options)
        {
        }

        // Entities part of data model represented as sets (tables)
        public DbSet<Member> Members { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Team> Teams { get; set; }

        // TODO Review Delete Behavior 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Create singular table names
            modelBuilder.Entity<Member>().ToTable("Member");
            modelBuilder.Entity<Project>().ToTable("Project");
            modelBuilder.Entity<Team>().ToTable("Team");

            // Map relationships 
            modelBuilder.Entity<Project>()
                .HasOne(p => p.Team)
                .WithMany(t => t.Projects);

            // Map TeamMember association table (join of Team and Member)   
            modelBuilder.Entity<TeamMember>()
                .HasKey(t => new {t.TeamId, t.MemberId});

            modelBuilder.Entity<TeamMember>()
                .HasOne(pt => pt.Team)
                .WithMany(p => p.TeamMembers)
                .HasForeignKey(pt => pt.TeamId);

            modelBuilder.Entity<TeamMember>()
                .HasOne(pt => pt.Member)
                .WithMany(t => t.TeamMembers)
                .HasForeignKey(pt => pt.MemberId);

            // Enable cascade delete on teams with team members 
            modelBuilder.Entity<Team>()
                .HasMany(t => t.TeamMembers)
                .WithOne(tm => tm.Team)
                .OnDelete(DeleteBehavior.Cascade); // NB: Delete associated team members but not members themselves 

            modelBuilder.Entity<Team>()
                .HasMany(t => t.Projects)
                .WithOne(p => p.Team)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
