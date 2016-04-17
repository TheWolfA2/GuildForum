namespace GuildForum.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ArticleClass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 150),
                        SubTitle = c.String(maxLength: 5),
                        Content = c.String(nullable: false),
                        PostDate = c.DateTime(nullable: false),
                        AuthorID = c.String(nullable: false, maxLength: 128),
                        EditDate = c.DateTime(nullable: false),
                        EditAuthorID = c.String(maxLength: 128),
                        UserDetails_UserID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.UserDetails", t => t.UserDetails_UserID)
                .ForeignKey("dbo.AspNetUsers", t => t.AuthorID, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.EditAuthorID)
                .Index(t => t.AuthorID)
                .Index(t => t.EditAuthorID)
                .Index(t => t.UserDetails_UserID);
            
            CreateTable(
                "dbo.UserDetails",
                c => new
                    {
                        UserID = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.UserID)
                .ForeignKey("dbo.AspNetUsers", t => t.UserID)
                .Index(t => t.UserID);
            
            AddColumn("dbo.ThreadReplies", "UserDetails_UserID", c => c.String(maxLength: 128));
            CreateIndex("dbo.ThreadReplies", "UserDetails_UserID");
            AddForeignKey("dbo.ThreadReplies", "UserDetails_UserID", "dbo.UserDetails", "UserID");
            DropColumn("dbo.AspNetUsers", "Details_FirstName");
            DropColumn("dbo.AspNetUsers", "Details_LastName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Details_LastName", c => c.String());
            AddColumn("dbo.AspNetUsers", "Details_FirstName", c => c.String());
            DropForeignKey("dbo.Articles", "EditAuthorID", "dbo.AspNetUsers");
            DropForeignKey("dbo.Articles", "AuthorID", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserDetails", "UserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.ThreadReplies", "UserDetails_UserID", "dbo.UserDetails");
            DropForeignKey("dbo.Articles", "UserDetails_UserID", "dbo.UserDetails");
            DropIndex("dbo.ThreadReplies", new[] { "UserDetails_UserID" });
            DropIndex("dbo.UserDetails", new[] { "UserID" });
            DropIndex("dbo.Articles", new[] { "UserDetails_UserID" });
            DropIndex("dbo.Articles", new[] { "EditAuthorID" });
            DropIndex("dbo.Articles", new[] { "AuthorID" });
            DropColumn("dbo.ThreadReplies", "UserDetails_UserID");
            DropTable("dbo.UserDetails");
            DropTable("dbo.Articles");
        }
    }
}
