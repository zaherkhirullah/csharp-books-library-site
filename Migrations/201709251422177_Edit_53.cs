namespace ZHYR_Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Edit_53 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.books", "favorited", c => c.Int(nullable: false));
            DropColumn("dbo.books", "favorite");
        }
        
        public override void Down()
        {
            AddColumn("dbo.books", "favorite", c => c.Int(nullable: false));
            DropColumn("dbo.books", "favorited");
        }
    }
}
