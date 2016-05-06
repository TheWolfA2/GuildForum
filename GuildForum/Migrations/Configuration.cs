namespace GuildForum.Migrations
{
    using GuildForum.Areas.Forum.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;

    internal sealed class Configuration : DbMigrationsConfiguration<GuildForum.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(GuildForum.Models.ApplicationDbContext context)
        {
            try
            {
                #region Forum Section upsert
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
                },
                new ForumSection
                {
                    ID = 6,
                    Title = "Lore",
                    SortOrder = 6,
                }
                });
                #endregion

                #region Forum Upsert
                context.Forums.AddOrUpdate(new Forum[]
                {
                new Forum
                {
                    ID = 1,
                    Title = "Officer's Lounge",
                    SubTitle = "Officers only area for discussion",
                    ForumSectionID = 1
                },
                new Forum
                {
                    ID = 2,
                    Title = "General Discussion",
                    SubTitle = "General Discussion - Open to everyone!",
                    ForumSectionID = 2,
                },
                new Forum
                {
                    ID = 3,
                    Title = "Recruitment",
                    SubTitle = "Applications for recruitment, and instructions on how to go about them are found here",
                    ForumSectionID = 2,
                },
                new Forum
                {
                    ID = 4,
                    Title = "News!",
                    ForumSectionID = 2
                },
                new Forum
                {
                    ID = 5,
                    Title = "Dossiers of Selama",
                    SubTitle = "Profiles for members go here. Read and learn about about follow guildmates and share your character's story",
                    ForumSectionID = 3
                },
                new Forum
                {
                    ID = 6,
                    Title = "Creativity Corner",
                    ForumSectionID = 4
                },
                new Forum
                {
                    ID = 7,
                    Title = "Dossiers",
                    ForumSectionID = 4
                },
                new Forum
                {
                    ID = 8,
                    Title = "Admin/Council Discussion",
                    ForumSectionID = 5
                },
                new Forum
                {
                    ID = 9,
                    Title = "Horde",
                    ForumSectionID = 6
                },
                new Forum
                {
                    ID = 10,
                    Title = "Alliance",
                    ForumSectionID = 6,
                },
                new Forum
                {
                    ID = 11,
                    Title = "Dragons",
                    ForumSectionID = 6,
                }
                });
                #endregion

                #region Threads
                context.Threads.AddOrUpdate(new Thread[]
                {
                new Thread
                {
                    ID = 1,
                    Title = "Preface",
                    ForumID = 9,
                    PostDate = DateTime.Now,
                    AuthorID = "4a4f2328-fe08-4e4e-ba77-2c0fe0bf0067",
                    Content = "Other sample text"
                },
                new Thread
                {
                    ID = 2,
                    Title = "Lady Liadrin",
                    ForumID = 9,
                    PostDate = DateTime.Now,
                    AuthorID = "4a4f2328-fe08-4e4e-ba77-2c0fe0bf0067",
                    Content = "Sample text"
                }
                });
                #endregion

                context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                var outputLines = new List<string>();
                foreach (var eve in e.EntityValidationErrors)
                {
                    outputLines.Add(string.Format(
                        "{0}: Entity of type \"{1}\" in state \"{2}\" has the following validation errors:",
                        DateTime.Now, eve.Entry.Entity.GetType().Name, eve.Entry.State));
                    foreach (var ve in eve.ValidationErrors)
                    {
                        outputLines.Add(string.Format(
                            "- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage));
                    }
                }
                //Write to file
                System.IO.File.AppendAllLines(@"C:\errors.txt", outputLines);
                throw;

                // Showing it on screen
                throw new Exception(string.Join(",", outputLines.ToArray()));
            }
        }
    }
}
