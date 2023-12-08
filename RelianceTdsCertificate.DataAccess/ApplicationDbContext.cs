using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RelianceTdsCertificate.Models;
using static System.Net.WebRequestMethods;

namespace RelianceTdsCertificate.DataAccess
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        { 


        }

        public DbSet<Employee> LoginInfo { get; set; }

        public DbSet<Otp> OtpInfo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Otp>()
                .HasIndex(o => o.EmployeePanNumber)
                .IsUnique();
        }
    }
}
