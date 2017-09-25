namespace ZHYR_Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_reD_nd_downloD_TOO_BOOK : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.books", "downloaded", c => c.Int());

            AddColumn("dbo.books", "Readed", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.books", "Readed");
            DropColumn("dbo.books", "downloaded");
        }
    }
}
