namespace ZHYR_Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Edit_tables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        FullName = c.String(maxLength: 128),
                        Adress = c.String(maxLength: 256),
                        Gender = c.Boolean(nullable: false),
                        status = c.String(maxLength: 128),
                        avatar = c.String(maxLength: 256),
                        cover = c.String(maxLength: 256),
                        Created_at = c.DateTime(nullable: false),
                        Updated_at = c.DateTime(),
                        Deleted_at = c.DateTime(),
                        birth_date = c.DateTime(),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.books",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        book_name = c.String(nullable: false, maxLength: 50),
                        book_about = c.String(maxLength: 1000),
                        image = c.String(maxLength: 256),
                        book_path = c.String(maxLength: 256),
                        Created_at = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Updated_at = c.DateTime(),
                        Deleted_at = c.DateTime(),
                        Like = c.Int(nullable: false),
                        Favorite = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        author_id = c.Int(nullable: false),
                        category_id = c.Int(nullable: false),
                        Favorite_id = c.Int(),
                        Favorites_Id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.categories", t => t.category_id)
                .ForeignKey("dbo.Favorites", t => t.Favorites_Id)
                .ForeignKey("dbo.writers", t => t.author_id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.author_id)
                .Index(t => t.category_id)
                .Index(t => t.Favorites_Id);
            
            CreateTable(
                "dbo.categories",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        category_name = c.String(nullable: false, maxLength: 50),
                        category_about = c.String(maxLength: 1000),
                        image = c.String(maxLength: 256),
                        Created_at = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Updated_at = c.DateTime(),
                        Deleted_at = c.DateTime(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        image = c.String(maxLength: 256),
                        Title = c.String(),
                        content = c.String(nullable: false),
                        date = c.DateTime(),
                        Created_at = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Updated_at = c.DateTime(),
                        Deleted_at = c.DateTime(),
                        category_id = c.Int(),
                        Favorite_id = c.Int(),
                        UserId = c.Int(nullable: false),
                        AspNetUsers_Id = c.Int(),
                        categories_id = c.Int(),
                        Favorites_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.AspNetUsers_Id)
                .ForeignKey("dbo.categories", t => t.categories_id)
                .ForeignKey("dbo.Favorites", t => t.Favorites_Id)
                .Index(t => t.AspNetUsers_Id)
                .Index(t => t.categories_id)
                .Index(t => t.Favorites_Id);
            
            CreateTable(
                "dbo.comments",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        comment = c.String(nullable: false, maxLength: 1000),
                        image = c.String(maxLength: 256),
                        Created_at = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Updated_at = c.DateTime(),
                        Deleted_at = c.DateTime(),
                        BookId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        Post_Id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Posts", t => t.Post_Id)
                .ForeignKey("dbo.books", t => t.BookId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: false)
                .Index(t => t.BookId)
                .Index(t => t.UserId)
                .Index(t => t.Post_Id);
            
            CreateTable(
                "dbo.Likes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Liked = c.Boolean(nullable: false),
                        //User_Id = c.Int(nullable: false),
                        //Book_Id = c.Int(nullable: false),
                        //Post_Id = c.Int(nullable: false),
                        Created_at = c.DateTime(nullable: false),
                        Book_Id = c.Int(),
                        Post_Id = c.Int(),
                        User_Id = c.Int(),
                        comments_id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.books", t => t.Book_Id)
                .ForeignKey("dbo.Posts", t => t.Post_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .ForeignKey("dbo.comments", t => t.comments_id)
                .Index(t => t.Book_Id)
                .Index(t => t.Post_Id)
                .Index(t => t.User_Id)
                .Index(t => t.comments_id);
            
            CreateTable(
                "dbo.Favorites",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Favorited = c.Boolean(nullable: false),
                        //User_Id = c.Int(nullable: false),
                        Created_at = c.DateTime(nullable: false),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.writers",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        author_name = c.String(nullable: false, maxLength: 50),
                        author_about = c.String(),
                        image = c.String(maxLength: 256),
                        UserId = c.Int(nullable: false),
                        Created_at = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Updated_at = c.DateTime(),
                        Deleted_at = c.DateTime(),
                        birth_date = c.DateTime(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Followers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        //User_Id = c.Int(nullable: false),
                        Created_at = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Updated_at = c.DateTime(),
                        Deleted_at = c.DateTime(),
                    User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Followings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        //User_Id = c.Int(nullable: false),
                        Created_at = c.DateTime(nullable: false),
                         User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.images",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        image_name = c.String(nullable: false, maxLength: 50),
                        image_about = c.String(maxLength: 1000),
                        image = c.String(nullable: false, maxLength: 256),
                        Created_at = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Updated_at = c.DateTime(),
                        Deleted_at = c.DateTime(),
                        UserId = c.Int(nullable: false),
                        AspNetUsers_Id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.AspNetUsers", t => t.AspNetUsers_Id)
                .Index(t => t.AspNetUsers_Id);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(nullable: false),
                        email = c.String(nullable: false),
                        massege = c.String(nullable: false),
                        Created_at = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Duyurus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        image = c.String(maxLength: 256),
                        Title = c.String(),
                        content = c.String(nullable: false),
                        date = c.DateTime(),
                        Created_at = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Updated_at = c.DateTime(),
                        Deleted_at = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.feedbacks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(nullable: false),
                        Phone = c.String(),
                        email = c.String(nullable: false),
                        massege = c.String(nullable: false),
                        Created_at = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Moduls",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        image = c.String(maxLength: 256),
                        Title = c.String(),
                        content = c.String(nullable: false),
                        date = c.DateTime(),
                        Created_at = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Updated_at = c.DateTime(),
                        Deleted_at = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Referans",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        image = c.String(maxLength: 256),
                        Title = c.String(),
                        content = c.String(),
                        date = c.DateTime(),
                        Created_at = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Updated_at = c.DateTime(),
                        Deleted_at = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sliders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        image = c.String(maxLength: 256),
                        Title = c.String(),
                        content = c.String(),
                        f_date = c.DateTime(),
                        l_date = c.DateTime(),
                        Created_at = c.DateTime(nullable: false),
                        Updated_at = c.DateTime(),
                        Deleted_at = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        image = c.String(maxLength: 256),
                        FullName = c.String(),
                        Content = c.String(),
                        email = c.String(),
                        PhoneNumber = c.String(),
                        Adress = c.String(),
                        Gender = c.Boolean(nullable: false),
                        Tip = c.Int(nullable: false),
                        Created_at = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Updated_at = c.DateTime(),
                        Deleted_at = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        RoleId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.RoleId, t.UserId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.writers", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.images", "AspNetUsers_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Followings", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Followers", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.comments", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.categories", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.books", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.books", "author_id", "dbo.writers");
            DropForeignKey("dbo.comments", "BookId", "dbo.books");
            DropForeignKey("dbo.Favorites", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Posts", "Favorites_Id", "dbo.Favorites");
            DropForeignKey("dbo.books", "Favorites_Id", "dbo.Favorites");
            DropForeignKey("dbo.comments", "Post_Id", "dbo.Posts");
            DropForeignKey("dbo.Likes", "comments_id", "dbo.comments");
            DropForeignKey("dbo.Likes", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Likes", "User_Id", "dbo.Posts");
            DropForeignKey("dbo.Likes", "Book_id", "dbo.books");
            DropForeignKey("dbo.Posts", "categories_id", "dbo.categories");
            DropForeignKey("dbo.Posts", "AspNetUsers_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.books", "category_id", "dbo.categories");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.images", new[] { "AspNetUsers_Id" });
            DropIndex("dbo.Followings", new[] { "User_Id" });
            DropIndex("dbo.Followers", new[] { "User_Id" });
            DropIndex("dbo.writers", new[] { "UserId" });
            DropIndex("dbo.Favorites", new[] { "User_Id" });
            DropIndex("dbo.Likes", new[] { "comments_id" });
            DropIndex("dbo.Likes", new[] { "User_Id" });
            DropIndex("dbo.Likes", new[] { "User_Id" });
            DropIndex("dbo.Likes", new[] { "Book_id" });
            DropIndex("dbo.comments", new[] { "Post_Id" });
            DropIndex("dbo.comments", new[] { "UserId" });
            DropIndex("dbo.comments", new[] { "BookId" });
            DropIndex("dbo.Posts", new[] { "Favorites_Id" });
            DropIndex("dbo.Posts", new[] { "categories_id" });
            DropIndex("dbo.Posts", new[] { "AspNetUsers_Id" });
            DropIndex("dbo.categories", new[] { "UserId" });
            DropIndex("dbo.books", new[] { "Favorites_Id" });
            DropIndex("dbo.books", new[] { "category_id" });
            DropIndex("dbo.books", new[] { "author_id" });
            DropIndex("dbo.books", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.Teams");
            DropTable("dbo.Sliders");
            DropTable("dbo.Referans");
            DropTable("dbo.Moduls");
            DropTable("dbo.feedbacks");
            DropTable("dbo.Duyurus");
            DropTable("dbo.Contacts");
            DropTable("dbo.images");
            DropTable("dbo.Followings");
            DropTable("dbo.Followers");
            DropTable("dbo.writers");
            DropTable("dbo.Favorites");
            DropTable("dbo.Likes");
            DropTable("dbo.comments");
            DropTable("dbo.Posts");
            DropTable("dbo.categories");
            DropTable("dbo.books");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetRoles");
        }
    }
}
