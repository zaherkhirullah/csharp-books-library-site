namespace ZHYR_Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Edittonullableincommentstable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.comments", "post_id", "dbo.Posts");
            DropIndex("dbo.comments", new[] { "post_id" });
            AlterColumn("dbo.comments", "post_id", c => c.Int());
            CreateIndex("dbo.comments", "post_id");
            AddForeignKey("dbo.comments", "post_id", "dbo.Posts", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.comments", "post_id", "dbo.Posts");
            DropIndex("dbo.comments", new[] { "post_id" });
            AlterColumn("dbo.comments", "post_id", c => c.Int(nullable: false));
            CreateIndex("dbo.comments", "post_id");
            AddForeignKey("dbo.comments", "post_id", "dbo.Posts", "Id", cascadeDelete: true);
        }
    }
}
