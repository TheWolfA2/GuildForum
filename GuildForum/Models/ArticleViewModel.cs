using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GuildForum.Models
{
    public class LoreArticleViewModel
    {
        [Required, StringLength(150, MinimumLength = 5)]
        public string Title { get; set; }
        [StringLength(5, MinimumLength = 50)]
        public string SubTitle { get; set; }
        [Required, MinLength(5)]
        public string Content { get; set; }
    }
}