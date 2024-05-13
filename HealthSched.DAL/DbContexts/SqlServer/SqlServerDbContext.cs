using HealthSched.Models.Models.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HealthSched.DAL.DbContexts.SqlServer
{
    public class SqlServerDbContext : DbContext
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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=HealthSched;Trusted_Connection=True;Trust Server Certificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.Load("HealthSched.Models"));
        }
    }
}
