namespace GuildForum.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveUserDetails : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Articles", "UserDetails_UserID", "dbo.UserDetails");
            DropForeignKey("dbo.ThreadReplies", "UserDetails_UserID", "dbo.UserDetails");
            DropForeignKey("dbo.UserDetails", "UserID", "dbo.AspNetUsers");
            DropIndex("dbo.Articles", new[] { "UserDetails_UserID" });
            DropIndex("dbo.UserDetails", new[] { "UserID" });
            DropIndex("dbo.ThreadReplies", new[] { "UserDetails_UserID" });
            AddColumn("dbo.Articles", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String());
            AddColumn("dbo.ThreadReplies", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Articles", "ApplicationUser_Id");
            CreateIndex("dbo.ThreadReplies", "ApplicationUser_Id");
            AddForeignKey("dbo.Articles", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.ThreadReplies", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.Articles", "UserDetails_UserID");
            DropColumn("dbo.ThreadReplies", "UserDetails_UserID");
            DropTable("dbo.UserDetails");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserDetails",
                c => new
                    {
                        UserID = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.UserID);
            
            AddColumn("dbo.ThreadReplies", "UserDetails_UserID", c => c.String(maxLength: 128));
            AddColumn("dbo.Articles", "UserDetails_UserID", c => c.String(maxLength: 128));
            DropForeignKey("dbo.ThreadReplies", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Articles", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.ThreadReplies", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Articles", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.ThreadReplies", "ApplicationUser_Id");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
            DropColumn("dbo.Articles", "ApplicationUser_Id");
            CreateIndex("dbo.ThreadReplies", "UserDetails_UserID");
            CreateIndex("dbo.UserDetails", "UserID");
            CreateIndex("dbo.Articles", "UserDetails_UserID");
            AddForeignKey("dbo.UserDetails", "UserID", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.ThreadReplies", "UserDetails_UserID", "dbo.UserDetails", "UserID");
            AddForeignKey("dbo.Articles", "UserDetails_UserID", "dbo.UserDetails", "UserID");
        }
    }
}
