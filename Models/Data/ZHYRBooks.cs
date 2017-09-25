namespace ZHYR_Library.Models.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ZHYRBooks : DbContext
    {
        public ZHYRBooks(): base("name=ZHYRBooks")
        {
        }

        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<books> books { get; set; }
        public virtual DbSet<categories> categories { get; set; }
        public virtual DbSet<comments> comments { get; set; }
        public virtual DbSet<images> images { get; set; }
        public virtual DbSet<writers> writers { get; set; }

        public virtual DbSet<Team> Team { get; set; }
        public virtual DbSet<Slider> Slider { get; set; }
        public virtual DbSet<Referans> Referans { get; set; }
        public virtual DbSet<Post> Post { get; set; }
        public virtual DbSet<Modul> Modul { get; set; }
        public virtual DbSet<feedback> feedback { get; set; }
        public virtual DbSet<Duyuru> Duyuru { get; set; }
        public virtual DbSet<Contacts> Contacts { get; set; }
        public virtual DbSet<Likes> Likes { get; set; }
        public virtual DbSet<Favorites> Favorites { get; set; }
        public virtual DbSet<Followers> Followers { get; set; }
        public virtual DbSet<Following> Following { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRoles>()
                .HasMany(e => e.AspNetUsers)
                .WithMany(e => e.AspNetRoles)
                .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.AspNetUserClaims)
                .WithRequired(e => e.AspNetUsers)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.AspNetUserLogins)
                .WithRequired(e => e.AspNetUsers)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.books)
                .WithRequired(e => e.AspNetUsers)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.categories)
                .WithRequired(e => e.AspNetUsers)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.writers)
                .WithRequired(e => e.AspNetUsers)
                .HasForeignKey(e => e.UserId);


            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.comments)
                .WithRequired(e => e.AspNetUsers)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<books>()
               .HasMany(e => e.comments)
               .WithRequired(e => e.books)
               .HasForeignKey(e => e.BookId);

            modelBuilder.Entity<categories>()
                .HasMany(e => e.books)
                .WithRequired(e => e.categories)
                .HasForeignKey(e => e.category_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<writers>()
                .HasMany(e => e.books)
                .WithRequired(e => e.writers)
                   .HasForeignKey(e => e.author_id)
                .WillCascadeOnDelete(false);



        }
    }
}
