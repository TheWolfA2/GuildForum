using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GuildForum.Models
{
    public class Thread
    {
        #region Columns
        [Key]
        public int ID { get; set; }
        [StringLength(60, MinimumLength = 5), Required]
        public string Title { get; set; }
        [DataType(DataType.DateTime), Required]
        public DateTime PostDate { get; set; }
        [MinLength(5), Required]
        public string Content { get; set; }
        [ForeignKey("Forum"), Required]
        public int ForumID { get; set; }
        #endregion

        #region Navigation properties
        public virtual Forum Forum { get; set; }
        public virtual ICollection<ThreadReply> Replies { get; set; }
        #endregion
    }
}