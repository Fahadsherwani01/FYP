using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FYP.Models
{
    public partial class userDetailContext : DbContext
    {
        public virtual DbSet<Admins> Admins { get; set; }
        public virtual DbSet<MedicalHistory> MedicalHistory { get; set; }
        public virtual DbSet<PrescriptionDetail> PrescriptionDetail { get; set; }
        public virtual DbSet<Reports> Reports { get; set; }
        public virtual DbSet<Tbladminmedicationrecord> Tbladminmedicationrecord { get; set; }
        public virtual DbSet<tableForChild> tableForChild { get; set; }
        public virtual DbSet<tableForWomen> tableForWomen { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Email> Email { get; set; }
        public virtual DbSet<feedback> feedback { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=userDetail;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admins>(entity =>
            {
                entity.ToTable("admins");

                entity.Property(e => e.Email).HasColumnName("Email");

            });

            modelBuilder.Entity<MedicalHistory>(entity =>
            {
                entity.ToTable("medicalHistory");

                //entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.MdId).HasColumnName("mdID");

                entity.Property(e => e.PrescriptionId).HasColumnName("prescriptionID");

                entity.Property(e => e.ReportId).HasColumnName("reportID");

               
            });

            modelBuilder.Entity<PrescriptionDetail>(entity =>
            {
                entity.ToTable("prescriptionDetail");

               // entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.PrescriptionId).HasColumnName("prescriptionID");

                entity.Property(e => e._1medicinePerDay).HasColumnName("1medicinePerDay");

                entity.Property(e => e._2medicinePerDay).HasColumnName("2medicinePerDay");

                entity.Property(e => e._3medicinePerDay).HasColumnName("3medicinePerDay");
            });

            modelBuilder.Entity<Reports>(entity =>
            {
               // entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.BloodTest).HasColumnName("bloodTest");

                entity.Property(e => e.Hivtest).HasColumnName("HIVtest");

                entity.Property(e => e.ReportId).HasColumnName("reportID");

                entity.Property(e => e.UrineTest).HasColumnName("urineTest");
            });

            modelBuilder.Entity<Tbladminmedicationrecord>(entity =>
            {
                entity.ToTable("tbladminmedicationrecord");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Bloodpresure)
                    .HasColumnName("bloodpresure")
                    .HasMaxLength(50);

                entity.Property(e => e.Bodypart)
                    .HasColumnName("bodypart")
                    .HasMaxLength(50);

                entity.Property(e => e.Diet).HasColumnName("diet");

                entity.Property(e => e.Disease)
                    .HasColumnName("disease")
                    .HasMaxLength(50);

                entity.Property(e => e.Dosage)
                    .HasColumnName("dosage")
                    .HasMaxLength(100);

                entity.Property(e => e.Gender)
                    .HasColumnName("gender")
                    .HasMaxLength(50);

                entity.Property(e => e.Generalsymptoms).HasColumnName("generalsymptoms");

                entity.Property(e => e.Heartbeat)
                    .HasColumnName("heartbeat")
                    .HasMaxLength(50);

                entity.Property(e => e.Medicine)
                    .HasColumnName("medicine")
                    .HasMaxLength(100);

                entity.Property(e => e.Precautions).HasColumnName("precautions");

                entity.Property(e => e.Temprature)
                    .HasColumnName("temprature")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Email>(entity =>
            {
                entity.Property(e => e.Read).HasMaxLength(50);
            });


            modelBuilder.Entity<tableForChild>(entity =>
            {
                entity.ToTable("tableForChild");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Bloodpresure)
                    .HasColumnName("bloodpresure")
                    .HasMaxLength(50);

                entity.Property(e => e.Bodypart)
                    .HasColumnName("bodypart")
                    .HasMaxLength(50);

                entity.Property(e => e.Diet).HasColumnName("diet");

                entity.Property(e => e.Disease)
                    .HasColumnName("disease")
                    .HasMaxLength(50);

                entity.Property(e => e.Dosage)
                    .HasColumnName("dosage")
                    .HasMaxLength(100);

                entity.Property(e => e.Gender)
                    .HasColumnName("gender")
                    .HasMaxLength(50);

                entity.Property(e => e.Generalsymptoms).HasColumnName("generalsymptoms");

                entity.Property(e => e.Heartbeat)
                    .HasColumnName("heartbeat")
                    .HasMaxLength(50);

                entity.Property(e => e.Medicine)
                    .HasColumnName("medicine")
                    .HasMaxLength(100);

                entity.Property(e => e.Precautions).HasColumnName("precautions");

                entity.Property(e => e.Temprature)
                    .HasColumnName("temprature")
                    .HasMaxLength(50);
            });




            modelBuilder.Entity<tableForWomen>(entity =>
            {
                entity.ToTable("tableForWomen");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Bloodpresure)
                    .HasColumnName("bloodpresure")
                    .HasMaxLength(50);

                entity.Property(e => e.Bodypart)
                    .HasColumnName("bodypart")
                    .HasMaxLength(50);

                entity.Property(e => e.Diet).HasColumnName("diet");

                entity.Property(e => e.Disease)
                    .HasColumnName("disease")
                    .HasMaxLength(50);

                entity.Property(e => e.Dosage)
                    .HasColumnName("dosage")
                    .HasMaxLength(100);

                entity.Property(e => e.Gender)
                    .HasColumnName("gender")
                    .HasMaxLength(50);

                entity.Property(e => e.Generalsymptoms).HasColumnName("generalsymptoms");

                entity.Property(e => e.Heartbeat)
                    .HasColumnName("heartbeat")
                    .HasMaxLength(50);

                entity.Property(e => e.Medicine)
                    .HasColumnName("medicine")
                    .HasMaxLength(100);

                entity.Property(e => e.Precautions).HasColumnName("precautions");

                entity.Property(e => e.Temprature)
                    .HasColumnName("temprature")
                    .HasMaxLength(50);
            });







            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.id).HasColumnName("id");

                entity.Property(e => e.DateOfBirth)
                    .HasColumnName("dateOfBirth")
                    .HasColumnType("date");

                entity.Property(e => e.Gander).HasMaxLength(50);

                entity.Property(e => e.MdId).HasColumnName("mdID");

                entity.Property(e => e.ProfilePic).HasColumnName("profilePic");

                entity.Property(e => e.UserName).HasColumnName("userName");

                entity.Property(e => e.Address).HasColumnName("address");

                entity.Property(e => e.Admin).HasMaxLength(50);
            });

            modelBuilder.Entity<feedback>(entity =>
            {
                entity.ToTable("feedback");

                //entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Comment).HasColumnName("comment");

                entity.Property(e => e.Date).HasColumnName("date");

                entity.Property(e => e.Name).HasMaxLength(50);
            });


        }
    }
}