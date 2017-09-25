namespace ZHYR_Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Edit_5333 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.books", "Like", c => c.Int());
            AlterColumn("dbo.books", "disLike", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.books", "disLike", c => c.Int(nullable: false));
            AlterColumn("dbo.books", "Like", c => c.Int(nullable: false));
        }
    }
}
