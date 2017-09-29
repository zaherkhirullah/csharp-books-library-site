namespace ZHYR_Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addreplayes : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.comments", "Post_Id", "dbo.Posts");
            DropForeignKey("dbo.Likes", "comments_id", "dbo.comments");
            DropIndex("dbo.comments", new[] { "Post_Id" });
            DropIndex("dbo.Likes", new[] { "comments_id" });
            RenameColumn(table: "dbo.Likes", name: "comments_id", newName: "comment_Id");
            CreateTable(
                "dbo.Replayes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        comment = c.String(nullable: false, maxLength: 1000),
                        image = c.String(maxLength: 256),
                        Created_at = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Updated_at = c.DateTime(),
                        Deleted_at = c.DateTime(),
                        comment_Id = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: false)
                .ForeignKey("dbo.comments", t => t.comment_Id, cascadeDelete: false)
                .Index(t => t.comment_Id)
                .Index(t => t.UserId);
            
            AddColumn("dbo.Likes", "post_id", c => c.Int(nullable: true));
            AddColumn("dbo.Likes", "Replay_Id", c => c.Int(nullable: true));
            AlterColumn("dbo.comments", "post_id", c => c.Int());
            AlterColumn("dbo.Likes", "comment_Id", c => c.Int());
            CreateIndex("dbo.comments", "post_id");
            CreateIndex("dbo.Likes", "comment_Id");
            CreateIndex("dbo.Likes", "post_id");
            CreateIndex("dbo.Likes", "Replay_Id");
            AddForeignKey("dbo.Likes", "post_id", "dbo.Posts", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Likes", "Replay_Id", "dbo.Replayes", "id", cascadeDelete: true);
            AddForeignKey("dbo.comments", "post_id", "dbo.Posts", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Likes", "comment_Id", "dbo.comments", "id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Likes", "comment_Id", "dbo.comments");
            DropForeignKey("dbo.comments", "post_id", "dbo.Posts");
            DropForeignKey("dbo.Likes", "Replay_Id", "dbo.Replayes");
            DropForeignKey("dbo.Replayes", "comment_Id", "dbo.comments");
            DropForeignKey("dbo.Replayes", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Likes", "post_id", "dbo.Posts");
            DropIndex("dbo.Replayes", new[] { "UserId" });
            DropIndex("dbo.Replayes", new[] { "comment_Id" });
            DropIndex("dbo.Likes", new[] { "Replay_Id" });
            DropIndex("dbo.Likes", new[] { "post_id" });
            DropIndex("dbo.Likes", new[] { "comment_Id" });
            DropIndex("dbo.comments", new[] { "post_id" });
            AlterColumn("dbo.Likes", "comment_Id", c => c.Int());
            AlterColumn("dbo.comments", "post_id", c => c.Int());
            DropColumn("dbo.Likes", "Replay_Id");
            DropColumn("dbo.Likes", "post_id");
            DropTable("dbo.Replayes");
            RenameColumn(table: "dbo.Likes", name: "comment_Id", newName: "comments_id");
            CreateIndex("dbo.Likes", "comments_id");
            CreateIndex("dbo.comments", "Post_Id");
            AddForeignKey("dbo.Likes", "comments_id", "dbo.comments", "id");
            AddForeignKey("dbo.comments", "Post_Id", "dbo.Posts", "Id");
        }
    }
}
