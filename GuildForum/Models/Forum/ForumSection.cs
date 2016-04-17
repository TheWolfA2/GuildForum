using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GuildForum.Models
{
    public class ForumSection
    {
        #region Columns
        [Key]
        public int ID { get; set; }
        [MinLength(5), Required]
        public string Title { get; set; }
        [Index(IsUnique = true), Required]
        public int SortOrder { get; set; }
        #endregion

        #region Navigation Properties
        public virtual ICollection<Forum> Forums { get; set; }
        #endregion
    }
}