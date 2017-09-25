namespace ZHYR_Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Edit_3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Likes", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Likes", "Book_id", "dbo.books");
            DropForeignKey("dbo.Likes", "posts_Id", "dbo.Posts");
            DropIndex("dbo.Likes", new[] { "User_Id" });
            DropIndex("dbo.Likes", new[] { "Book_id" });
            DropIndex("dbo.Likes", new[] { "posts_Id" });

            RenameColumn(table: "dbo.Likes", name: "User_Id", newName: "UserId");
            RenameColumn(table: "dbo.Likes", name: "Book_Id", newName: "Book_id");
            RenameColumn(table: "dbo.Likes", name: "posts_Id", newName: "Post_id");
            AlterColumn("dbo.Likes", "UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.Likes", "Book_id", c => c.Int());
            AlterColumn("dbo.Likes", "Post_id", c => c.Int());
            CreateIndex("dbo.Likes", "UserId");
            CreateIndex("dbo.Likes", "Book_id");
            CreateIndex("dbo.Likes", "Post_id");
            AddForeignKey("dbo.Likes", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Likes", "Book_id", "dbo.books", "id", cascadeDelete: false);
            AddForeignKey("dbo.Likes", "Post_id", "dbo.Posts", "Id", cascadeDelete: false);
         
        }
        
        public override void Down()
        {
            AddColumn("dbo.Likes", "User_Id", c => c.Int(nullable: false));
            DropForeignKey("dbo.Likes", "Post_id", "dbo.Posts");
            DropForeignKey("dbo.Likes", "Book_id", "dbo.books");
            DropForeignKey("dbo.Likes", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Likes", new[] { "Post_id" });
            DropIndex("dbo.Likes", new[] { "Book_id" });
            DropIndex("dbo.Likes", new[] { "UserId" });
            AlterColumn("dbo.Likes", "Post_id", c => c.Int());
            AlterColumn("dbo.Likes", "Book_id", c => c.Int());
            AlterColumn("dbo.Likes", "UserId", c => c.Int());
            RenameColumn(table: "dbo.Likes", name: "Post_id", newName: "posts_Id");
            RenameColumn(table: "dbo.Likes", name: "Book_id", newName: "books_id");
            RenameColumn(table: "dbo.Likes", name: "UserId", newName: "AspNetUsers_Id");
            AddColumn("dbo.Likes", "Post_Id", c => c.Int(nullable: false));
            AddColumn("dbo.Likes", "Book_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Likes", "posts_Id");
            CreateIndex("dbo.Likes", "books_id");
            CreateIndex("dbo.Likes", "AspNetUsers_Id");
            AddForeignKey("dbo.Likes", "posts_Id", "dbo.Posts", "Id");
            AddForeignKey("dbo.Likes", "books_id", "dbo.books", "id");
            AddForeignKey("dbo.Likes", "AspNetUsers_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
