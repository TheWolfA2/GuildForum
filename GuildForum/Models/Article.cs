using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GuildForum.Models
{
    public class Article
    {
        [Key]
        public int ID { get; set; }

        [Required, StringLength(150, MinimumLength = 5)]
        public string Title { get; set; }
        [StringLength(50, MinimumLength = 5)]
        public string Subtitle { get; set; }
        [Required, MinLength(5)]
        public string Content { get; set; }

        [Required, Display(Name = "Posting Date"), DataType(DataType.DateTime)]
        public DateTime PostDate { get; set; }
        [Required, ForeignKey("Author"), Display(Name = "Author")]
        public string AuthorID { get; set; }
        [Display(Name = "Date of Last Update"), DataType(DataType.DateTime)]
        public DateTime? EditDate { get; set; }
        [ForeignKey("EditAuthor"), Display(Name = "Author who last edited")]
        public string EditAuthorID { get; set; }

        #region Navigation properties
        public virtual ApplicationUser Author { get; set; }
        [Display(Name = "Edit Author")]
        public virtual ApplicationUser EditAuthor { get; set; }
        #endregion
    }
}