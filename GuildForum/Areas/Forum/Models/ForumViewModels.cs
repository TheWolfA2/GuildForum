using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuildForum.Areas.Forum.Models
{
    public class ForumIndexModel
    {
        public IEnumerable<ForumSection> ForumSections { get; set; }
    }
}