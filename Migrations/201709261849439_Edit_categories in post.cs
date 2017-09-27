namespace ZHYR_Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Edit_categoriesinpost : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Posts", "AspNetUsers_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Posts", "categories_id", "dbo.categories");
            DropIndex("dbo.Posts", new[] { "AspNetUsers_Id" });
            DropIndex("dbo.Posts", new[] { "categories_id" });
            DropColumn("dbo.Posts", "UserId");
            DropColumn("dbo.Posts", "category_id");
            RenameColumn(table: "dbo.Posts", name: "AspNetUsers_Id", newName: "UserId");
            RenameColumn(table: "dbo.Posts", name: "categories_id", newName: "category_id");
            AlterColumn("dbo.Posts", "category_id", c => c.Int(nullable: false));
            AlterColumn("dbo.Posts", "UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.Posts", "category_id", c => c.Int(nullable: false));
            CreateIndex("dbo.Posts", "category_id");
            CreateIndex("dbo.Posts", "UserId");
            AddForeignKey("dbo.Posts", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Posts", "category_id", "dbo.categories", "id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "category_id", "dbo.categories");
            DropForeignKey("dbo.Posts", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Posts", new[] { "UserId" });
            DropIndex("dbo.Posts", new[] { "category_id" });
            AlterColumn("dbo.Posts", "category_id", c => c.Int());
            AlterColumn("dbo.Posts", "UserId", c => c.Int());
            AlterColumn("dbo.Posts", "category_id", c => c.Int());
            RenameColumn(table: "dbo.Posts", name: "category_id", newName: "categories_id");
            RenameColumn(table: "dbo.Posts", name: "UserId", newName: "AspNetUsers_Id");
            AddColumn("dbo.Posts", "category_id", c => c.Int());
            AddColumn("dbo.Posts", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Posts", "categories_id");
            CreateIndex("dbo.Posts", "AspNetUsers_Id");
            AddForeignKey("dbo.Posts", "categories_id", "dbo.categories", "id");
            AddForeignKey("dbo.Posts", "AspNetUsers_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
