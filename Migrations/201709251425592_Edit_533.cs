namespace ZHYR_Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Edit_533 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.books", "Favorites_Id", "dbo.Favorites");
            DropIndex("dbo.books", new[] { "Favorites_Id" });
            //DropColumn("dbo.books", "Favorites_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.books", "Favorites_Id", c => c.Int());
            CreateIndex("dbo.books", "Favorites_Id");
            AddForeignKey("dbo.books", "Favorites_Id", "dbo.Favorites", "Id");
        }
    }
}
