namespace ZHYR_Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddlikedreadedToposts : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "Liked", c => c.Int(nullable: false));
            AddColumn("dbo.Posts", "disLike", c => c.Int(nullable: false));
            AddColumn("dbo.Posts", "Readed", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "Readed");
            DropColumn("dbo.Posts", "disLike");
            DropColumn("dbo.Posts", "Liked");
        }
    }
}
