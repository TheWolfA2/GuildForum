using System.Web.Mvc;

namespace GuildForum.Areas.Forum
{
    public class ForumAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Forum";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Forum_default",
                "Forum/{action}/{id}",
                new {controller = "Forums", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "GuildForum.Areas.Forum.Controllers" }
            );
        }
    }
}