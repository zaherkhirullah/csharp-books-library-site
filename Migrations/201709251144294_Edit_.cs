namespace ZHYR_Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Edit_ : DbMigration
    {
        public override void Up()
        {
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
            DropForeignKey("dbo.Likes", "Book_Id", "dbo.books");
            DropIndex("dbo.Likes", new[] { "Book_Id" });
            RenameColumn(table: "dbo.Likes", name: "User_Id", newName: "AspNetUsers_Id");
            RenameIndex(table: "dbo.Likes", name: "IX_User_Id", newName: "IX_AspNetUsers_Id");
            AddColumn("dbo.Likes", "books_id", c => c.Int());
            AlterColumn("dbo.Likes", "Book_Id", c => c.Int());
            CreateIndex("dbo.Likes", "books_id");
            AddForeignKey("dbo.Likes", "books_id", "dbo.books", "id");

        }
    }
}
