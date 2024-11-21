﻿// <auto-generated />
using System;
using COVID_vaccination_patient_system.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace COVID_vaccination_patient_system.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241121150733_SeedPatientTable")]
    partial class SeedPatientTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("COVID_vaccination_patient_system.Models.Patient", b =>
                {
                    b.Property<int>("PatientID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PatientID"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VaccinationStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PatientID");

                    b.ToTable("Patients");

                    b.HasData(
                        new
                        {
                            PatientID = 1,
                            Age = 32,
                            Gender = "Male",
                            Name = "Umair Khan",
                            VaccinationStatus = "Unvaccinated"
                        },
                        new
                        {
                            PatientID = 2,
                            Age = 42,
                            Gender = "Male",
                            Name = "Harry Brown",
                            VaccinationStatus = "Unvaccinated"
                        },
                        new
                        {
                            PatientID = 3,
                            Age = 28,
                            Gender = "Female",
                            Name = "Margaret Taylor",
                            VaccinationStatus = "Unvaccinated"
                        });
                });

            modelBuilder.Entity("COVID_vaccination_patient_system.Models.Vaccination", b =>
                {
                    b.Property<int>("VaccinationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VaccinationID"));

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Dose")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PatientID")
                        .HasColumnType("int");

                    b.HasKey("VaccinationID");

                    b.HasIndex("PatientID");

                    b.ToTable("Vaccinations");
                });

            modelBuilder.Entity("COVID_vaccination_patient_system.Models.Vaccination", b =>
                {
                    b.HasOne("COVID_vaccination_patient_system.Models.Patient", "Patient")
                        .WithMany("Vaccinations")
                        .HasForeignKey("PatientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("COVID_vaccination_patient_system.Models.Patient", b =>
                {
                    b.Navigation("Vaccinations");
                });
#pragma warning restore 612, 618
        }
    }
}
