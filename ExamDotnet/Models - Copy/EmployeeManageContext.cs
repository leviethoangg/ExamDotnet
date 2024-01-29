using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ExamDotnet.Models;

public partial class EmployeeManageContext : DbContext
{
    public EmployeeManageContext()
    {
    }

    public EmployeeManageContext(DbContextOptions<EmployeeManageContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=SANGPC\\SANG;Database=EmployeeManage;Trusted_Connection=True;encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DepartmentId).HasName("PK__Departme__C223242250B26882");

            entity.ToTable("Department");

            entity.Property(e => e.DepartmentId).HasColumnName("department_id");
            entity.Property(e => e.DepartmentCode)
                .HasMaxLength(50)
                .HasColumnName("department_code");
            entity.Property(e => e.DepartmentName)
                .HasMaxLength(255)
                .HasColumnName("department_name");
            entity.Property(e => e.Location)
                .HasMaxLength(255)
                .HasColumnName("location");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__Employee__C52E0BA8E1B4BFD3");

            entity.ToTable("Employee");

            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.DepartmentId).HasColumnName("department_id");
            entity.Property(e => e.EmployeeCode)
                .HasMaxLength(50)
                .HasColumnName("employee_code");
            entity.Property(e => e.EmployeeName)
                .HasMaxLength(255)
                .HasColumnName("employee_name");
            entity.Property(e => e.Rank)
                .HasMaxLength(50)
                .HasColumnName("rank");

            entity.HasOne(d => d.Department).WithMany(p => p.Employees)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK__Employee__depart__3C69FB99");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
