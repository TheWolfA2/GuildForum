namespace GuildForum.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateAppUser : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Articles", "Subtitle", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Articles", "Subtitle", c => c.String(maxLength: 5));
        }
    }
}
