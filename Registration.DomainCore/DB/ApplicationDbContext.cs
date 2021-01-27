using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Registration.DomainModels.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Registration.DomainCore.DB
{
    public class ApplicationDbContext:IdentityUserContext<User,int>
    {
        public DbSet<UserInformation> UserInformations { get; set; }
        public ApplicationDbContext() { }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("Server=GIORGIOKRUADZE;Database=registration;Trusted_Connection=true;MultipleActiveResultSets=true;");
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
