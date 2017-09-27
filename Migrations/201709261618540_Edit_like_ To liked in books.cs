namespace ZHYR_Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Edit_like_Tolikedinbooks : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.books", "Liked", c => c.Int(nullable: false));
            DropColumn("dbo.books", "Like");
        }
        
        public override void Down()
        {
            AddColumn("dbo.books", "Like", c => c.Int(nullable: false));
            DropColumn("dbo.books", "Liked");
        }
    }
}
