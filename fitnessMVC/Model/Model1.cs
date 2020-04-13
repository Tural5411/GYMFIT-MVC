namespace fitnessMVC.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=BlogDB")
        {
        }

        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<tbl_admin> tbl_admin { get; set; }
        public virtual DbSet<tbl_color3> tbl_color3 { get; set; }
        public virtual DbSet<tbl_companyName> tbl_companyName { get; set; }
        public virtual DbSet<tbl_contact> tbl_contact { get; set; }
        public virtual DbSet<tbl_corusel> tbl_corusel { get; set; }
        public virtual DbSet<tbl_link> tbl_link { get; set; }
        public virtual DbSet<tbl_mainPost> tbl_mainPost { get; set; }
        public virtual DbSet<tbl_mansoryPhoto> tbl_mansoryPhoto { get; set; }
        public virtual DbSet<tbl_parallax> tbl_parallax { get; set; }
        public virtual DbSet<tbl_parallax2> tbl_parallax2 { get; set; }
        public virtual DbSet<tbl_post_category> tbl_post_category { get; set; }
        public virtual DbSet<tbl_slider> tbl_slider { get; set; }
        public virtual DbSet<tbl_tag> tbl_tag { get; set; }
        public virtual DbSet<tbl_trend> tbl_trend { get; set; }
        public virtual DbSet<tbl_user> tbl_user { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tbl_post_category>()
                .HasMany(e => e.tbl_corusel)
                .WithOptional(e => e.tbl_post_category)
                .HasForeignKey(e => e.CategoryId);

            modelBuilder.Entity<tbl_post_category>()
                .HasMany(e => e.tbl_mainPost)
                .WithOptional(e => e.tbl_post_category)
                .HasForeignKey(e => e.CategoryId);

            modelBuilder.Entity<tbl_post_category>()
                .HasMany(e => e.tbl_trend)
                .WithOptional(e => e.tbl_post_category)
                .HasForeignKey(e => e.CategoryId);

            modelBuilder.Entity<tbl_user>()
                .HasMany(e => e.tbl_corusel)
                .WithOptional(e => e.tbl_user)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<tbl_user>()
                .HasMany(e => e.tbl_mainPost)
                .WithOptional(e => e.tbl_user)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<tbl_user>()
                .HasMany(e => e.tbl_trend)
                .WithOptional(e => e.tbl_user)
                .HasForeignKey(e => e.UserId);
        }
    }
}
