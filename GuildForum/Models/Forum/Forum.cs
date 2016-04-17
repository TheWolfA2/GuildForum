using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GuildForum.Models
{
    public class Forum
    {
        #region Columns
        [Key]
        public int ID { get; set; }
        [MinLength(5), Required]
        public string Title { get; set; }
        public string SubTitle { get; set; }
        [ForeignKey("ForumSection")]
        public int ForumSectionID { get; set; }
        #endregion

        #region
        [NotMapped]
        public Thread LatestThread
        {
            get
            {
                if (Threads == null)
                {
                    return null;
                }
                return Threads.FirstOrDefault();
            }
        }
        #endregion

        #region Navigation properties
        public virtual ForumSection ForumSection { get; set; }
        public virtual ICollection<Thread> Threads { get; set; }
        public virtual ICollection<Thread> PinnedThreads { get; set; }
        #endregion
    }
}