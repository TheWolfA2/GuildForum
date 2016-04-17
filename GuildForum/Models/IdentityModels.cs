using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuildForum.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        #region Custom columns
        [Display(Name = "FirstName")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Full Name"), NotMapped]
        public string FullName
        {
            get
            {
                string name = FirstName;
                if (!string.IsNullOrWhiteSpace(LastName))
                {
                    if (!string.IsNullOrWhiteSpace(name))
                    {
                        name += " ";
                    }
                    name += LastName;
                }
                if (string.IsNullOrWhiteSpace(name))
                {
                    return UserName;
                }
                else
                {
                    return name;
                }
            }
        }
        #endregion

        #region Navigation properties
        public virtual ICollection<Article> AuthoredArticles { get; set; }
        public virtual ICollection<ThreadReply> ThreadPosts { get; set; }
        #endregion

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<ForumSection> ForumSections { get; set; }
        public DbSet<Forum> Forums { get; set; }
        public DbSet<Thread> Threads { get; set; }
        public DbSet<ThreadReply> ThreadReplies { get; set; }
        public DbSet<Article> Articles { get; set; }
    }
}