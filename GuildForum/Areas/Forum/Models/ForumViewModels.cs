using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;

namespace GuildForum.Areas.Forum.Models
{
    public class ThreadListItem
    {
        public string Title { get; private set; }
        public ThreadReply LastPost { get; private set; }
        [Display(Name = "Number of Replies")]
        public int NumReplies { get; private set; }

        public ThreadListItem(Thread thread)
        {
            Title = thread.Title;
            LastPost = thread.Replies.OrderByDescending(r => r.PostDate).FirstOrDefault();
            NumReplies = thread.Replies.Count;
        }
    }

    public class ThreadListModel
    {
        public int ForumId { get; private set; }
        public string Title { get; private set; }
        public string SubTitle { get; private set; }
        public List<ThreadListItem> Threads { get; private set; }

        public ThreadListModel(Forum forum)
        {
            ForumId = forum.ID;
            Title = forum.Title;
            SubTitle = forum.SubTitle;
            Threads = new List<ThreadListItem>();
            foreach (Thread thread in forum.Threads.OrderBy(t => t.ID))
            {
                Threads.Add(new ThreadListItem(thread));
            }
        }
    }

    public class NewThreadModel
    {
        [Required, StringLength(60, MinimumLength = 5)]
        public string Title { get; set; }
        [Required, AllowHtml, DataType(DataType.Html), MinLength(5), UIHint("MarkdownEditor")]
        public string Content { get; set; }
    }
}