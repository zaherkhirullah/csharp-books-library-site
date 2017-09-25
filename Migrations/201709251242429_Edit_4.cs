namespace ZHYR_Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Edit_4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Likes", "Post_id", "dbo.Posts");
            DropForeignKey("dbo.Posts", "Favorites_Id", "dbo.Favorites");
            DropIndex("dbo.Posts", new[] { "Favorites_Id" });
            DropIndex("dbo.Likes", new[] { "Post_id" });
            DropColumn("dbo.Posts", "Favorite_id");
            DropColumn("dbo.Posts", "Favorites_Id");
            DropColumn("dbo.Likes", "Post_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Likes", "Post_id", c => c.Int(nullable: false));
            AddColumn("dbo.Posts", "Favorites_Id", c => c.Int());
            AddColumn("dbo.Posts", "Favorite_id", c => c.Int());
            CreateIndex("dbo.Likes", "Post_id");
            CreateIndex("dbo.Posts", "Favorites_Id");
            AddForeignKey("dbo.Posts", "Favorites_Id", "dbo.Favorites", "Id");
            AddForeignKey("dbo.Likes", "Post_id", "dbo.Posts", "Id", cascadeDelete: true);
        }
    }
}
