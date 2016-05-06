using System.Web.Mvc;

namespace GuildForum.Areas.Lore
{
    public class LoreAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Lore";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Lore_default",
                "Lore/{controller}/{action}/{id}",
                new { action = "Preface", id = UrlParameter.Optional }
            );
        }
    }
}