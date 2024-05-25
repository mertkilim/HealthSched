using HealthSched.Models.Identity;
using HealthSched.Models.Models.Abstract;
using HealthSched.Models.Models.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HealthSched.DAL.DbContexts.SqlServer
{
    public class SqlServerDbContext : IdentityDbContext<IdentityUser>
    {
        public SqlServerDbContext()
        {
            
        }

        public SqlServerDbContext(DbContextOptions<SqlServerDbContext> options) : base(options)
        {
            
        }

        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Policlinic> Policlinics { get; set; }
        public DbSet<Title> Titles { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=HealthSched;Trusted_Connection=True;Trust Server Certificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.Load("HealthSched.Models"));

            modelBuilder.Entity<Title>()
            .HasMany(t => t.Doctors)
            .WithOne(d => d.Title)
            .HasForeignKey(d => d.TitleId);
        }
    }
}
