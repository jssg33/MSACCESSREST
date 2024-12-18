using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WEBAPI.MODELSACCESS;

public partial class ModelContext : DbContext
{
    public ModelContext()
    {
    }

    public ModelContext(DbContextOptions<ModelContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Filter> Filters { get; set; }

    public virtual DbSet<Guardian> Guardians { get; set; }

    public virtual DbSet<GuardiansExtended> GuardiansExtendeds { get; set; }

    public virtual DbSet<Setting> Settings { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<StudentAttendance> StudentAttendances { get; set; }

    public virtual DbSet<StudentAttendanceCount> StudentAttendanceCounts { get; set; }

    public virtual DbSet<StudentAttendanceExtended> StudentAttendanceExtendeds { get; set; }

    public virtual DbSet<StudentsAndGuardian> StudentsAndGuardians { get; set; }

    public virtual DbSet<StudentsAndGuardiansExtended> StudentsAndGuardiansExtendeds { get; set; }

    public virtual DbSet<StudentsExtended> StudentsExtendeds { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseJet("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\stritzj\\Documents\\Database2.accdb");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Filter>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PrimaryKey");

            entity.HasIndex(e => e.FilterName, "Filter Name").IsUnique();

            entity.HasIndex(e => e.ObjectName, "ObjectName");

            entity.HasIndex(e => e.ObjectType, "ObjectType");

            entity.Property(e => e.Id)
                .HasColumnType("counter")
                .HasColumnName("ID");
            entity.Property(e => e.Default)
                .IsRequired()
                .HasDefaultValueSql("No")
                .HasColumnType("bit");
            entity.Property(e => e.FilterName)
                .HasMaxLength(50)
                .HasColumnName("Filter Name");
            entity.Property(e => e.FilterString).HasColumnName("Filter String");
            entity.Property(e => e.ObjectName).HasColumnName("Object Name");
            entity.Property(e => e.ObjectType).HasColumnName("Object Type");
            entity.Property(e => e.SortString).HasColumnName("Sort String");
        });

        modelBuilder.Entity<Guardian>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PrimaryKey");

            entity.HasIndex(e => e.Attachments, "Attachments_5EDFC92F1D5540339D027CEC2AC47767").IsUnique();

            entity.HasIndex(e => e.City, "City");

            entity.HasIndex(e => e.Company, "Company");

            entity.HasIndex(e => e.FirstName, "First Name");

            entity.HasIndex(e => e.LastName, "Last Name");

            entity.HasIndex(e => e.ZipPostalCode, "Postal Code");

            entity.HasIndex(e => e.StateProvince, "State/Province");

            entity.Property(e => e.Id)
                .HasColumnType("counter")
                .HasColumnName("ID");
            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.Attachments).HasColumnType("longchar");
            entity.Property(e => e.BusinessPhone)
                .HasMaxLength(25)
                .HasColumnName("Business Phone");
            entity.Property(e => e.City).HasMaxLength(50);
            entity.Property(e => e.Company).HasMaxLength(50);
            entity.Property(e => e.CountryRegion)
                .HasMaxLength(50)
                .HasColumnName("Country/Region");
            entity.Property(e => e.EMailAddress)
                .HasMaxLength(50)
                .HasColumnName("E-mail Address");
            entity.Property(e => e.FaxNumber)
                .HasMaxLength(25)
                .HasColumnName("Fax Number");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("First Name");
            entity.Property(e => e.HomePhone)
                .HasMaxLength(25)
                .HasColumnName("Home Phone");
            entity.Property(e => e.JobTitle)
                .HasMaxLength(50)
                .HasColumnName("Job Title");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("Last Name");
            entity.Property(e => e.MobilePhone)
                .HasMaxLength(25)
                .HasColumnName("Mobile Phone");
            entity.Property(e => e.StateProvince)
                .HasMaxLength(50)
                .HasColumnName("State/Province");
            entity.Property(e => e.WebPage).HasColumnName("Web Page");
            entity.Property(e => e.ZipPostalCode)
                .HasMaxLength(15)
                .HasColumnName("ZIP/Postal Code");
        });

        modelBuilder.Entity<GuardiansExtended>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Guardians Extended");

            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.BusinessPhone)
                .HasMaxLength(25)
                .HasColumnName("Business Phone");
            entity.Property(e => e.City).HasMaxLength(50);
            entity.Property(e => e.Company).HasMaxLength(50);
            entity.Property(e => e.CountryRegion)
                .HasMaxLength(50)
                .HasColumnName("Country/Region");
            entity.Property(e => e.EMailAddress)
                .HasMaxLength(50)
                .HasColumnName("E-mail Address");
            entity.Property(e => e.FaxNumber)
                .HasMaxLength(25)
                .HasColumnName("Fax Number");
            entity.Property(e => e.FileAs).HasColumnName("File As");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("First Name");
            entity.Property(e => e.GuardianName).HasColumnName("Guardian Name");
            entity.Property(e => e.HomePhone)
                .HasMaxLength(25)
                .HasColumnName("Home Phone");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("counter")
                .HasColumnName("ID");
            entity.Property(e => e.JobTitle)
                .HasMaxLength(50)
                .HasColumnName("Job Title");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("Last Name");
            entity.Property(e => e.MobilePhone)
                .HasMaxLength(25)
                .HasColumnName("Mobile Phone");
            entity.Property(e => e.StateProvince)
                .HasMaxLength(50)
                .HasColumnName("State/Province");
            entity.Property(e => e.WebPage).HasColumnName("Web Page");
            entity.Property(e => e.ZipPostalCode)
                .HasMaxLength(15)
                .HasColumnName("ZIP/Postal Code");
        });

        modelBuilder.Entity<Setting>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PrimaryKey");

            entity.Property(e => e.Id)
                .HasColumnType("counter")
                .HasColumnName("ID");
            entity.Property(e => e.ShowWelcome).HasColumnType("bit");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PrimaryKey");

            entity.HasIndex(e => e.Attachments, "Attachments_EF4FB5F7F31147BFBEB17CCA1CE3BE0A").IsUnique();

            entity.HasIndex(e => e.City, "City");

            entity.HasIndex(e => e.FirstName, "First Name");

            entity.HasIndex(e => e.LastName, "Last Name");

            entity.HasIndex(e => e.Level, "Level");

            entity.HasIndex(e => e.ZipPostalCode, "Postal Code");

            entity.HasIndex(e => e.Room, "Room");

            entity.HasIndex(e => e.SpecialCircumstances, "Special Circumstances_D8C66D28A2EC4F1F891F38D38A32ACFE").IsUnique();

            entity.HasIndex(e => e.StateProvince, "State/Province");

            entity.HasIndex(e => e.StudentId, "Student ID").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("counter")
                .HasColumnName("ID");
            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.Allergies).HasMaxLength(100);
            entity.Property(e => e.Attachments).HasColumnType("longchar");
            entity.Property(e => e.City).HasMaxLength(50);
            entity.Property(e => e.CountryRegion)
                .HasMaxLength(50)
                .HasColumnName("Country/Region");
            entity.Property(e => e.DateOfBirth).HasColumnName("Date of Birth");
            entity.Property(e => e.EMailAddress)
                .HasMaxLength(50)
                .HasColumnName("E-mail Address");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("First Name");
            entity.Property(e => e.HomePhone)
                .HasMaxLength(25)
                .HasColumnName("Home Phone");
            entity.Property(e => e.IdNumber)
                .HasMaxLength(255)
                .HasColumnName("ID Number");
            entity.Property(e => e.InsuranceCarrier)
                .HasMaxLength(255)
                .HasColumnName("Insurance Carrier");
            entity.Property(e => e.InsuranceNumber)
                .HasMaxLength(255)
                .HasColumnName("Insurance Number");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("Last Name");
            entity.Property(e => e.Level).HasMaxLength(30);
            entity.Property(e => e.Medications).HasMaxLength(100);
            entity.Property(e => e.MobilePhone)
                .HasMaxLength(25)
                .HasColumnName("Mobile Phone");
            entity.Property(e => e.PhysicianName)
                .HasMaxLength(50)
                .HasColumnName("Physician Name");
            entity.Property(e => e.PhysicianPhoneNumber)
                .HasMaxLength(50)
                .HasColumnName("Physician Phone Number");
            entity.Property(e => e.Room).HasMaxLength(20);
            entity.Property(e => e.SpecialCircumstances)
                .HasColumnType("longchar")
                .HasColumnName("Special Circumstances");
            entity.Property(e => e.StateProvince)
                .HasMaxLength(50)
                .HasColumnName("State/Province");
            entity.Property(e => e.StudentId)
                .HasMaxLength(20)
                .HasColumnName("Student ID");
            entity.Property(e => e.WebPage).HasColumnName("Web Page");
            entity.Property(e => e.ZipPostalCode)
                .HasMaxLength(15)
                .HasColumnName("ZIP/Postal Code");
        });

        modelBuilder.Entity<StudentAttendance>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PrimaryKey");

            entity.ToTable("Student Attendance");

            entity.HasIndex(e => e.Status, "Level");

            entity.HasIndex(e => e.Student, "Student");

            entity.Property(e => e.Id)
                .HasColumnType("counter")
                .HasColumnName("ID");
            entity.Property(e => e.AttendanceDate).HasColumnName("Attendance Date");
            entity.Property(e => e.Status).HasMaxLength(30);
        });

        modelBuilder.Entity<StudentAttendanceCount>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Student Attendance Count");

            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("First Name");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("counter")
                .HasColumnName("ID");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("Last Name");
            entity.Property(e => e.NumberOfDays).HasColumnName("Number of Days");
            entity.Property(e => e.Status)
                .HasMaxLength(30)
                .HasColumnName("status");
        });

        modelBuilder.Entity<StudentAttendanceExtended>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Student Attendance Extended");

            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.Allergies).HasMaxLength(100);
            entity.Property(e => e.AttendanceDate).HasColumnName("Attendance Date");
            entity.Property(e => e.City).HasMaxLength(50);
            entity.Property(e => e.CountryRegion)
                .HasMaxLength(50)
                .HasColumnName("Country/Region");
            entity.Property(e => e.DateOfBirth).HasColumnName("Date of Birth");
            entity.Property(e => e.EMailAddress)
                .HasMaxLength(50)
                .HasColumnName("E-mail Address");
            entity.Property(e => e.FileAs).HasColumnName("File As");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("First Name");
            entity.Property(e => e.HomePhone)
                .HasMaxLength(25)
                .HasColumnName("Home Phone");
            entity.Property(e => e.IdNumber)
                .HasMaxLength(255)
                .HasColumnName("ID Number");
            entity.Property(e => e.InsuranceCarrier)
                .HasMaxLength(255)
                .HasColumnName("Insurance Carrier");
            entity.Property(e => e.InsuranceNumber)
                .HasMaxLength(255)
                .HasColumnName("Insurance Number");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("Last Name");
            entity.Property(e => e.Level).HasMaxLength(30);
            entity.Property(e => e.Medications).HasMaxLength(100);
            entity.Property(e => e.MobilePhone)
                .HasMaxLength(25)
                .HasColumnName("Mobile Phone");
            entity.Property(e => e.PhysicianName)
                .HasMaxLength(50)
                .HasColumnName("Physician Name");
            entity.Property(e => e.PhysicianPhoneNumber)
                .HasMaxLength(50)
                .HasColumnName("Physician Phone Number");
            entity.Property(e => e.Room).HasMaxLength(20);
            entity.Property(e => e.SpecialCircumstances).HasColumnName("Special Circumstances");
            entity.Property(e => e.StateProvince)
                .HasMaxLength(50)
                .HasColumnName("State/Province");
            entity.Property(e => e.Status).HasMaxLength(30);
            entity.Property(e => e.StudentAttendanceId)
                .ValueGeneratedOnAdd()
                .HasColumnType("counter")
                .HasColumnName("Student Attendance.ID");
            entity.Property(e => e.StudentId)
                .HasMaxLength(20)
                .HasColumnName("Student ID");
            entity.Property(e => e.StudentName).HasColumnName("Student Name");
            entity.Property(e => e.StudentsId)
                .ValueGeneratedOnAdd()
                .HasColumnType("counter")
                .HasColumnName("Students.ID");
            entity.Property(e => e.WebPage).HasColumnName("Web Page");
            entity.Property(e => e.ZipPostalCode)
                .HasMaxLength(15)
                .HasColumnName("ZIP/Postal Code");
        });

        modelBuilder.Entity<StudentsAndGuardian>(entity =>
        {
            entity.HasKey(e => new { e.StudentId, e.GuardianId }).HasName("PrimaryKey");

            entity.ToTable("Students and Guardians");

            entity.HasIndex(e => e.GuardianId, "GuardianID");

            entity.HasIndex(e => e.Relationship, "Level");

            entity.HasIndex(e => e.StudentId, "StudentID");

            entity.Property(e => e.StudentId).HasColumnName("StudentID");
            entity.Property(e => e.GuardianId).HasColumnName("GuardianID");
            entity.Property(e => e.EmergencyContact)
                .HasColumnType("bit")
                .HasColumnName("Emergency Contact");
            entity.Property(e => e.Relationship).HasMaxLength(30);
        });

        modelBuilder.Entity<StudentsAndGuardiansExtended>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Students and Guardians Extended");

            entity.Property(e => e.BusinessPhone)
                .HasMaxLength(25)
                .HasColumnName("Business Phone");
            entity.Property(e => e.EMailAddress)
                .HasMaxLength(50)
                .HasColumnName("E-mail Address");
            entity.Property(e => e.EmergencyContact)
                .HasColumnType("bit")
                .HasColumnName("Emergency Contact");
            entity.Property(e => e.GuardianId).HasColumnName("GuardianID");
            entity.Property(e => e.GuardianName).HasColumnName("Guardian Name");
            entity.Property(e => e.HomePhone)
                .HasMaxLength(25)
                .HasColumnName("Home Phone");
            entity.Property(e => e.MobilePhone)
                .HasMaxLength(25)
                .HasColumnName("Mobile Phone");
            entity.Property(e => e.Relationship).HasMaxLength(30);
            entity.Property(e => e.StudentId).HasColumnName("StudentID");
            entity.Property(e => e.StudentName).HasColumnName("Student Name");
        });

        modelBuilder.Entity<StudentsExtended>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Students Extended");

            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.Allergies).HasMaxLength(100);
            entity.Property(e => e.City).HasMaxLength(50);
            entity.Property(e => e.CountryRegion)
                .HasMaxLength(50)
                .HasColumnName("Country/Region");
            entity.Property(e => e.DateOfBirth).HasColumnName("Date of Birth");
            entity.Property(e => e.EMailAddress)
                .HasMaxLength(50)
                .HasColumnName("E-mail Address");
            entity.Property(e => e.FileAs).HasColumnName("File As");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("First Name");
            entity.Property(e => e.HomePhone)
                .HasMaxLength(25)
                .HasColumnName("Home Phone");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("counter")
                .HasColumnName("ID");
            entity.Property(e => e.IdNumber)
                .HasMaxLength(255)
                .HasColumnName("ID Number");
            entity.Property(e => e.InsuranceCarrier)
                .HasMaxLength(255)
                .HasColumnName("Insurance Carrier");
            entity.Property(e => e.InsuranceNumber)
                .HasMaxLength(255)
                .HasColumnName("Insurance Number");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("Last Name");
            entity.Property(e => e.Level).HasMaxLength(30);
            entity.Property(e => e.Medications).HasMaxLength(100);
            entity.Property(e => e.MobilePhone)
                .HasMaxLength(25)
                .HasColumnName("Mobile Phone");
            entity.Property(e => e.PhysicianName)
                .HasMaxLength(50)
                .HasColumnName("Physician Name");
            entity.Property(e => e.PhysicianPhoneNumber)
                .HasMaxLength(50)
                .HasColumnName("Physician Phone Number");
            entity.Property(e => e.Room).HasMaxLength(20);
            entity.Property(e => e.SpecialCircumstances).HasColumnName("Special Circumstances");
            entity.Property(e => e.StateProvince)
                .HasMaxLength(50)
                .HasColumnName("State/Province");
            entity.Property(e => e.StudentId)
                .HasMaxLength(20)
                .HasColumnName("Student ID");
            entity.Property(e => e.StudentName).HasColumnName("Student Name");
            entity.Property(e => e.WebPage).HasColumnName("Web Page");
            entity.Property(e => e.ZipPostalCode)
                .HasMaxLength(15)
                .HasColumnName("ZIP/Postal Code");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
