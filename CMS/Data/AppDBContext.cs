using AMS.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace AMS.Data
{
    public class AppDBContext : DbContext 
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        
        }

        // Tables
        //public DbSet<Company> Companies { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Lookup> Lookup { get; set; }

        //public DbSet<UserRole> UserRoles { get; set; }
        //public DbSet<UserAppointment> UserAppointments { get; set; }

        // Relations
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Company>(entity =>
            //{
            //    entity.HasKey(c => c.CompanyID);
            //});

            modelBuilder.Entity<Branch>(entity =>
            {
                entity.HasKey(c => c.BranchID);
                //entity.HasOne(c => c.Company).WithMany(c => c.Branches);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(c => c.UserID);
                entity.HasOne(c => c.Role).WithMany(c => c.Users);

                //entity.HasOne(c => c.Branch).WithMany(c => c.Users);
            });

            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.HasKey(c => c.AppointmentID);
                //entity.HasOne(c => c.Branch).WithMany(c => c.Appointments);
                entity.HasOne(c => c.User).WithMany(c => c.Appointments);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(c => c.RoleID);
            });

            //modelBuilder.Entity<UserRole>(entity =>
            //{
            //    entity.HasKey(c => c.UserRoleID);
            //    entity.HasOne(c => c.Role).WithMany(c => c.UserRoles);
            //    entity.HasOne(c => c.User).WithMany(c => c.UserRoles);
            //});

            //modelBuilder.Entity<UserAppointment>(entity =>
            //{
            //    entity.HasKey(c => c.UserAppointmentID);
            //    entity.HasOne(c => c.Appointment).WithMany(c => c.UserAppointments);
            //    entity.HasOne(c => c.User).WithMany(c => c.UserAppointments);

            //});

            modelBuilder.Entity<Lookup>(entity =>
            {
                entity.HasKey(c => new { c.LookupMajorID, c.LookupMinorID});
            });
        }

    }
}
