using Clinic_Management_System.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_Management_System.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; }

        public DbSet<Doctor> Doctors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=RUBAIYAT\\SQLEXPRESS;Database=ClinicDB;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}
