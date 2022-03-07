using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Registration.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Registration.DataAccessLayer.DB
{
    public class ApplicationDbContext: IdentityDbContext<User,UserRole,int>
    {
        public DbSet<UserInformation> UserInformations { get; set; }
        public ApplicationDbContext() { }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("Server=registration.mssql.somee.com;Database=registration;User Id=testStep_SQLLogin_3;password=yqeqdu94oi;Trusted_Connection=False;MultipleActiveResultSets=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasOne(o => o.GeneralInformation)
                .WithOne(o => o.User)
                .HasForeignKey<UserInformation>(o => o.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
