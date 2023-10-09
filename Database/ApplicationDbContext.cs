using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WebAppMvcProject
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("name=ApplicationDbContext")
        {
        }

        public virtual DbSet<StudentInfo> StudentInfoes { get; set; }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentInfo>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<StudentInfo>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<StudentInfo>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<StudentInfo>()
                .Property(e => e.Address)
                .IsUnicode(false);
        }

        public System.Data.Entity.DbSet<WebAppMvcProject.ViewModel.StudentInfoVM> StudentInfoVMs { get; set; }
    }
}
