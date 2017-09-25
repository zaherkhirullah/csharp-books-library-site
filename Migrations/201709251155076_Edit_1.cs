namespace ZHYR_Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Edit_1 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Likes", name: "Post_Id", newName: "posts_Id");
            RenameIndex(table: "dbo.Likes", name: "IX_Post_Id", newName: "IX_posts_Id");

            DropForeignKey("dbo.Likes", "books_id", "dbo.books");
            DropIndex("dbo.Likes", new[] { "books_id" });
            AlterColumn("dbo.Likes", "Book_Id", c => c.Int());
            DropColumn("dbo.Likes", "books_id");
            RenameIndex(table: "dbo.Likes", name: "IX_AspNetUsers_Id", newName: "IX_User_Id");
            RenameColumn(table: "dbo.Likes", name: "AspNetUsers_Id", newName: "User_Id");
            CreateIndex("dbo.Likes", "Book_Id");
            AddForeignKey("dbo.Likes", "Book_Id", "dbo.books", "id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Likes", name: "IX_posts_Id", newName: "IX_Post_Id1");
            RenameColumn(table: "dbo.Likes", name: "posts_Id", newName: "Post_Id1");
        }
    }
}
