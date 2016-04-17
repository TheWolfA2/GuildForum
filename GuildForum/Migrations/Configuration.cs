namespace GuildForum.Migrations
{
    using GuildForum.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GuildForum.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(GuildForum.Models.ApplicationDbContext context)
        {
            #region Forum Sections
            context.ForumSections.AddOrUpdate(new ForumSection[]
            {
                new ForumSection
                {
                    ID = 1,
                    Title = "Officers Section",
                    SortOrder = 1,
                },
                new ForumSection
                {
                    ID = 2,
                    Title = "General Section",
                    SortOrder = 2,
                },
                new ForumSection
                {
                    ID = 3,
                    Title = "Members Only",
                    SortOrder = 3,
                },
                new ForumSection
                {
                    ID = 4,
                    Title = "Eastern Kingdom Liberators",
                    SortOrder = 4,
                },
                new ForumSection
                {
                    ID = 5,
                    Title = "Admin Section",
                    SortOrder = 5,
                }
            });
            #endregion
            context.Forums.AddOrUpdate(new Forum[]
            {
                new Forum
                {
                    Title = "Officer's Lounge",
                    SubTitle = "Officers only area for discussion",
                    ForumSectionID = 1
                },
                new Forum
                {
                    Title = "General Discussion",
                    SubTitle = "General Discussion - Open to everyone!",
                    ForumSectionID = 2,
                },
                new Forum
                {
                    Title = "Recruitment",
                    SubTitle = "Applications for recruitment, and instructions on how to go about them are found here",
                    ForumSectionID = 2,
                },
                new Forum
                {
                    Title = "News!",
                    ForumSectionID = 2
                },
                new Forum
                {
                    Title = "Dossiers of Selama",
                    SubTitle = "Profiles for members go here. Read and learn about about follow guildmates and share your character's story",
                    ForumSectionID = 3
                },
                new Forum
                {
                    Title = "Creativity Corner",
                    ForumSectionID = 4
                },
                new Forum
                {
                    Title = "Dossiers",
                    ForumSectionID = 4
                },
                new Forum
                {
                    Title = "Admin/Council Discussion",
                    ForumSectionID = 5
                }
            });
        }
    }
}
