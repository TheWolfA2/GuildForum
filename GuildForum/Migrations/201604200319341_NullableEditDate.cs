namespace GuildForum.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NullableEditDate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Articles", "EditDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Articles", "EditDate", c => c.DateTime(nullable: false));
        }
    }
}
