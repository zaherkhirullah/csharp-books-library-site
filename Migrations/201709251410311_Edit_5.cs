namespace ZHYR_Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Edit_5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.books", "disLike", c => c.Int());
            
            DropColumn("dbo.books", "Favorite_id");
            DropForeignKey("dbo.books", "Favorites_Id", "dbo.Favorites");
            DropIndex("dbo.books", new[] { "Favorites_Id" });
            DropColumn("dbo.books", "Favorites_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.books", "Favorite_id", c => c.Int());
            DropColumn("dbo.books", "disLike");
        }
    }
}
