using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamTool.Models.Entities;
using TeamTool.Models.Interfaces;

namespace TeamTool.Models
{
    public class DbInitializer
    {

        public static async void Initialize(IContext context)
        {
            await context.Database.EnsureCreatedAsync();

            // Seed data  

            var teamMember = new TeamMember();

            var member = new Member
            {
                Background = "Developer",
                ImagePath = "",
                Name = "Thor",
                Skill = "Development",
                TeamMembers = new List<TeamMember>()
            };

            var member2 = new Member
            {
                Background = "Consultant",
                ImagePath = "~/images/Michael.PNG",
                Name = "Michael",
                Skill = "Business, Development & Consultancy",
                TeamMembers = new List<TeamMember>()
            };

            var member3 = new Member
            {
                Background = "Consultant",
                ImagePath = "~/images/Patrick.PNG",
                Name = "Patrick",
                Skill = "Development & Marketing",
                TeamMembers = new List<TeamMember>()
            };

            var member4 = new Member
            {
                Background = "Developer",
                ImagePath = "~/images/Travis.PNG",
                Name = "Travis",
                Skill = "Laravel ",
                TeamMembers = new List<TeamMember>()
            };

            var members = new List<Member>();
            members.Add(member);
            members.Add(member2);
            members.Add(member3);
            members.Add(member4);

            var team = new Team
            {
                Name = "Super Team",
                Background = "Super Team Background",
                Contact = "Team Contact Details",
                Projects = new List<Project>(),
                TeamMembers = new List<TeamMember>() 
            };

            var project = new Project
            {
                Name = "Super Project",
                Description = "Super Project Description",
                IsApproved = false
            };

            team.Projects.Add(project);
           
            if (!context.Members.Any())
            {
                context.Members.AddRange(members);
                await context.SaveChangesAsync();
            }

            if (!context.Teams.Any())
            {
                context.Teams.Add(team);
                await context.SaveChangesAsync();
            }

            if (!context.Projects.Any())
            {
                context.Projects.Add(project);
                await context.SaveChangesAsync();
            }

            if (!context.Teams.Any() || !context.Members.Any())
            {
                context.Teams.First(t => t.Id == team.Id).TeamMembers.Add(teamMember);
                context.Members.First(m => m.Id == member.Id).TeamMembers.Add(teamMember);
                await context.SaveChangesAsync();
            }
            
        }

    }
}
