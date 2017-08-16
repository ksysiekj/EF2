using EF2.Api.Data.Entities;
using EF2.Api.Data.Extensions;
using Microsoft.EntityFrameworkCore;

namespace EF2.Api.Data
{
    public class AdventureWorksDbContext : DbContext
    {
        public AdventureWorksDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // table
            modelBuilder.Entity<Employee>().ToTable("Employee", "HumanResources");

            // keys
            modelBuilder.Entity<Employee>().HasKey(t => t.EmployeeID);

            // Properties
            modelBuilder.Entity<Employee>().Property(t => t.EmployeeID)
                .HasColumnName("BusinessEntityID")
                .ValueGeneratedOnAdd()
                .IsRequired();
            modelBuilder.Entity<Employee>().Property(t => t.NationalIDNumber)
                .HasColumnName("NationalIDNumber")
                .HasMaxLength(15)
                .IsRequired();
            modelBuilder.Entity<Employee>().Property(t => t.Title)
                .HasColumnName("JobTitle")
                .HasMaxLength(50)
                .IsRequired();
            modelBuilder.Entity<Employee>().Property(t => t.BirthDate)
                .HasColumnName("BirthDate")
                .IsRequired();
            modelBuilder.Entity<Employee>().Property(t => t.MaritalStatus)
                .HasColumnName("MaritalStatus")
                .HasMaxLength(1)
                .IsRequired();
            modelBuilder.Entity<Employee>().Property(t => t.Gender)
                .HasColumnName("Gender")
                .HasMaxLength(1)
                .IsRequired();
            modelBuilder.Entity<Employee>().Property(t => t.HireDate)
                .HasColumnName("HireDate")
                .IsRequired();
            modelBuilder.Entity<Employee>().Property(t => t.SalariedFlag)
                .HasColumnName("SalariedFlag")
                .IsRequired();
            modelBuilder.Entity<Employee>().Property(t => t.VacationHours)
                .HasColumnName("VacationHours")
                .IsRequired();
            modelBuilder.Entity<Employee>().Property(t => t.SickLeaveHours)
                .HasColumnName("SickLeaveHours")
                .IsRequired();
            modelBuilder.Entity<Employee>().Property(t => t.IsActive)
                .HasColumnName("CurrentFlag")
                .IsRequired();
            modelBuilder.Entity<Employee>().Property(t => t.Rowguid)
                .HasColumnName("rowguid")
                .IsRequired();
            modelBuilder.Entity<Employee>().Property(t => t.ModifiedDate)
                .HasColumnName("ModifiedDate")
                .IsRequired();

            //  modelBuilder.Entity<Employee>().HasQueryFilter(t => t.IsActive);


            // table
            modelBuilder.Entity<JobCandidate>().ToTable("JobCandidate", "HumanResources");

            // keys
            modelBuilder.Entity<JobCandidate>().HasKey(t => t.JobCandidateID);

            // Properties
            modelBuilder.Entity<JobCandidate>().Property(t => t.JobCandidateID)
                .HasColumnName("JobCandidateID")
                .ValueGeneratedOnAdd()
                .IsRequired();
            modelBuilder.Entity<JobCandidate>().Property(t => t.EmployeeID)
                .HasColumnName("BusinessEntityID")
                ;
            modelBuilder.Entity<JobCandidate>().Property(t => t.Resume)
                .HasColumnName("Resume")
                .HasColumnType("xml")
                ;
            modelBuilder.Entity<JobCandidate>().Property(t => t.ModifiedDate)
                .HasColumnName("ModifiedDate")
                .IsRequired();

            // Relationships
            modelBuilder.Entity<JobCandidate>().HasOne(t => t.Employee)
                .WithMany(t => t.JobCandidates)
                .HasForeignKey(d => d.EmployeeID)
                .OnDelete(DeleteBehavior.Restrict);


            // table
            modelBuilder.Entity<Vendor>().ToTable("Vendor", "Purchasing");

            // keys
            modelBuilder.Entity<Vendor>().HasKey(t => t.VendorID);

            // Properties
            modelBuilder.Entity<Vendor>().Property(t => t.VendorID)
                .HasColumnName("BusinessEntityID")
                .ValueGeneratedOnAdd()
                .IsRequired();
            modelBuilder.Entity<Vendor>().Property(t => t.AccountNumber)
                .HasColumnName("AccountNumber")
                .HasMaxLength(15)
                .IsRequired();
            modelBuilder.Entity<Vendor>().Property(t => t.Name)
                .HasColumnName("Name")
                .HasMaxLength(50)
                .IsRequired();
            modelBuilder.Entity<Vendor>().Property(t => t.CreditRating)
                .HasColumnName("CreditRating")
                .IsRequired();
            modelBuilder.Entity<Vendor>().Property(t => t.PreferredVendorStatus)
                .HasColumnName("PreferredVendorStatus")
                .IsRequired();
            modelBuilder.Entity<Vendor>().Property(t => t.IsActive)
                .HasColumnName("ActiveFlag")
                .IsRequired();
            modelBuilder.Entity<Vendor>().Property(t => t.PurchasingWebServiceURL)
                .HasColumnName("PurchasingWebServiceURL")
                .HasMaxLength(1024)
                ;
            modelBuilder.Entity<Vendor>().Property(t => t.ModifiedDate)
                .HasColumnName("ModifiedDate")
                .IsRequired();


            modelBuilder.SetActiveableQueryFilters();

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<JobCandidate> JobCandidates { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
    }
}
