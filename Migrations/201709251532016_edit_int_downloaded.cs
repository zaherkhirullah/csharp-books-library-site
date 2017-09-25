namespace ZHYR_Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edit_int_downloaded : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.books", "downloaded");
            DropColumn("dbo.books", "Readed");
            DropColumn("dbo.books", "disLike");
            AddColumn("dbo.books", "downloaded", c => c.Int(nullable: false));
            AddColumn("dbo.books", "Readed", c => c.Int(nullable: false));
 
            AddColumn("dbo.books", "disLike", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.books", "downloaded");
            DropColumn("dbo.books", "Readed");
            DropColumn("dbo.books", "disLike");
            AddColumn("dbo.books", "downloaded", c => c.Int());
            AddColumn("dbo.books", "Readed", c => c.Int());
            AddColumn("dbo.books", "disLike", c => c.Int());

        }
    }
}
