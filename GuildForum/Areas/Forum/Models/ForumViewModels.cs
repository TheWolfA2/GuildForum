using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuildForum.Areas.Forum.Models
{
    public class ThreadListItem
    {
        public string Title { get; private set; }
        public ThreadReply LastPost { get; private set; }
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
        public string Title { get; private set; }
        public string SubTitle { get; private set; }
        public List<ThreadListItem> Threads { get; private set; }

        public ThreadListModel(Forum forum)
        {
            Title = forum.Title;
            SubTitle = forum.SubTitle;
            Threads = new List<ThreadListItem>();
            foreach (Thread thread in forum.Threads.OrderBy(t => t.ID))
            {
                Threads.Add(new ThreadListItem(thread));
            }
        }
    }
}