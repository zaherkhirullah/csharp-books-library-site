namespace ZHYR_Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Edittonullableinlikestable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Likes", "Book_id", "dbo.books");
            DropForeignKey("dbo.Likes", "post_id", "dbo.Posts");
            DropForeignKey("dbo.Likes", "comment_Id", "dbo.comments");
            DropForeignKey("dbo.Likes", "Replay_Id", "dbo.Replayes");
            DropIndex("dbo.Likes", new[] { "Book_id" });
            DropIndex("dbo.Likes", new[] { "comment_Id" });
            DropIndex("dbo.Likes", new[] { "post_id" });
            DropIndex("dbo.Likes", new[] { "Replay_Id" });
            AlterColumn("dbo.Likes", "Book_id", c => c.Int());
            AlterColumn("dbo.Likes", "comment_Id", c => c.Int());
            AlterColumn("dbo.Likes", "post_id", c => c.Int());
            AlterColumn("dbo.Likes", "Replay_Id", c => c.Int());
            CreateIndex("dbo.Likes", "Book_id");
            CreateIndex("dbo.Likes", "comment_Id");
            CreateIndex("dbo.Likes", "post_id");
            CreateIndex("dbo.Likes", "Replay_Id");
            AddForeignKey("dbo.Likes", "Book_id", "dbo.books", "id");
            AddForeignKey("dbo.Likes", "post_id", "dbo.Posts", "Id");
            AddForeignKey("dbo.Likes", "comment_Id", "dbo.comments", "id");
            AddForeignKey("dbo.Likes", "Replay_Id", "dbo.Replayes", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Likes", "Replay_Id", "dbo.Replayes");
            DropForeignKey("dbo.Likes", "comment_Id", "dbo.comments");
            DropForeignKey("dbo.Likes", "post_id", "dbo.Posts");
            DropForeignKey("dbo.Likes", "Book_id", "dbo.books");
            DropIndex("dbo.Likes", new[] { "Replay_Id" });
            DropIndex("dbo.Likes", new[] { "post_id" });
            DropIndex("dbo.Likes", new[] { "comment_Id" });
            DropIndex("dbo.Likes", new[] { "Book_id" });
            AlterColumn("dbo.Likes", "Replay_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Likes", "post_id", c => c.Int(nullable: false));
            AlterColumn("dbo.Likes", "comment_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Likes", "Book_id", c => c.Int(nullable: false));
            CreateIndex("dbo.Likes", "Replay_Id");
            CreateIndex("dbo.Likes", "post_id");
            CreateIndex("dbo.Likes", "comment_Id");
            CreateIndex("dbo.Likes", "Book_id");
            AddForeignKey("dbo.Likes", "Replay_Id", "dbo.Replayes", "id", cascadeDelete: true);
            AddForeignKey("dbo.Likes", "comment_Id", "dbo.comments", "id", cascadeDelete: true);
            AddForeignKey("dbo.Likes", "post_id", "dbo.Posts", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Likes", "Book_id", "dbo.books", "id", cascadeDelete: true);
        }
    }
}
