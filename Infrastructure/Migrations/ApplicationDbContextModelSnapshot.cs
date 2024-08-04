﻿// <auto-generated />
using System;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ActivityCareer", b =>
                {
                    b.Property<int>("ForeingActivitiesId")
                        .HasColumnType("integer");

                    b.Property<int>("ForeingCareersId")
                        .HasColumnType("integer");

                    b.HasKey("ForeingActivitiesId", "ForeingCareersId");

                    b.HasIndex("ForeingCareersId");

                    b.ToTable("ForeignActivityCareers", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Activity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ActivityStatus")
                        .HasColumnType("integer");

                    b.Property<string>("BannerLink")
                        .HasColumnType("text");

                    b.Property<int>("CoordinatorId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(350)
                        .HasColumnType("character varying(350)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Goals")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<DateTime>("LastRequestedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("LastReviewedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("MainActivities")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int>("RequestedById")
                        .HasColumnType("integer");

                    b.Property<int?>("ReviewedById")
                        .HasColumnType("integer");

                    b.Property<string>("ReviewerObservations")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("SupervisorId")
                        .HasColumnType("integer");

                    b.Property<int>("TotalSpots")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("CoordinatorId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("RequestedById");

                    b.HasIndex("ReviewedById");

                    b.HasIndex("Slug")
                        .IsUnique();

                    b.HasIndex("SupervisorId");

                    b.ToTable("Activities");
                });

            modelBuilder.Entity("Domain.Entities.ActivityOrganizer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ActivityId")
                        .HasColumnType("integer");

                    b.Property<int?>("CareerId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("OrganizationId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("ActivityId");

                    b.HasIndex("CareerId");

                    b.HasIndex("OrganizationId");

                    b.ToTable("ActivityOrganizers");
                });

            modelBuilder.Entity("Domain.Entities.ActivityScope", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ActivityId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Hours")
                        .HasColumnType("integer");

                    b.Property<int>("Scope")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("ActivityId");

                    b.ToTable("ActivityScopes");
                });

            modelBuilder.Entity("Domain.Entities.Career", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("FacultyId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("FacultyId");

                    b.ToTable("Careers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FacultyId = 1,
                            Name = "Ingeniería en Sistemas"
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FacultyId = 2,
                            Name = "Ingeniería Agroindustrial"
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FacultyId = 2,
                            Name = "Licenciatura en Comercio Internacional"
                        },
                        new
                        {
                            Id = 4,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FacultyId = 3,
                            Name = "Licenciatura en Desarrollo Local"
                        },
                        new
                        {
                            Id = 5,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FacultyId = 2,
                            Name = "Licenciatura en Administración de Empresas"
                        },
                        new
                        {
                            Id = 6,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FacultyId = 2,
                            Name = "Técnico en Administración de Empresas Cafetaleras"
                        },
                        new
                        {
                            Id = 7,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FacultyId = 1,
                            Name = "Técnico en Producción Agrícola"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Faculty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Faculties");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Ingeniería"
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Ciencias Económicas Administrativas y Contables"
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Ciencias Sociales"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Organization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Organizations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Pumas en Acción"
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Pumas Solidarios"
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "VOAE"
                        },
                        new
                        {
                            Id = 4,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Estudiantina"
                        });
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<long?>("AccountNumber")
                        .HasColumnType("bigint");

                    b.Property<int?>("CareerId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<DateTime?>("EmailConfirmationSentAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("EmailConfirmationToken")
                        .HasColumnType("text");

                    b.Property<DateTime?>("EmailConfirmationTokenExpiresAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("EmailConfirmedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Lastnames")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Names")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("ResetPasswordToken")
                        .HasColumnType("text");

                    b.Property<DateTime?>("ResetPasswordTokenExpiresAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("ResetPasswordTokenSentAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("AccountNumber")
                        .IsUnique()
                        .HasFilter("\"AccountNumber\" IS NOT NULL");

                    b.HasIndex("CareerId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("EmailConfirmationToken")
                        .IsUnique()
                        .HasFilter("\"EmailConfirmationToken\" IS NOT NULL");

                    b.HasIndex("ResetPasswordToken")
                        .IsUnique()
                        .HasFilter("\"ResetPasswordToken\" IS NOT NULL");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ActivityCareer", b =>
                {
                    b.HasOne("Domain.Entities.Activity", null)
                        .WithMany()
                        .HasForeignKey("ForeingActivitiesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Career", null)
                        .WithMany()
                        .HasForeignKey("ForeingCareersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Activity", b =>
                {
                    b.HasOne("Domain.Entities.User", "Coordinator")
                        .WithMany("CoordinatedActivities")
                        .HasForeignKey("CoordinatorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Domain.Entities.User", "RequestedBy")
                        .WithMany("RequestedActivities")
                        .HasForeignKey("RequestedById")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Domain.Entities.User", "ReviewedBy")
                        .WithMany("ReviewedActivities")
                        .HasForeignKey("ReviewedById")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Domain.Entities.User", "Supervisor")
                        .WithMany("SupervisedActivities")
                        .HasForeignKey("SupervisorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Coordinator");

                    b.Navigation("RequestedBy");

                    b.Navigation("ReviewedBy");

                    b.Navigation("Supervisor");
                });

            modelBuilder.Entity("Domain.Entities.ActivityOrganizer", b =>
                {
                    b.HasOne("Domain.Entities.Activity", "Activity")
                        .WithMany("Organizers")
                        .HasForeignKey("ActivityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Career", "Career")
                        .WithMany("Activities")
                        .HasForeignKey("CareerId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Domain.Entities.Organization", "Organization")
                        .WithMany("Activities")
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Activity");

                    b.Navigation("Career");

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("Domain.Entities.ActivityScope", b =>
                {
                    b.HasOne("Domain.Entities.Activity", "Activity")
                        .WithMany("Scopes")
                        .HasForeignKey("ActivityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Activity");
                });

            modelBuilder.Entity("Domain.Entities.Career", b =>
                {
                    b.HasOne("Domain.Entities.Faculty", "Faculty")
                        .WithMany("Careers")
                        .HasForeignKey("FacultyId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Faculty");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.HasOne("Domain.Entities.Career", "Career")
                        .WithMany("Users")
                        .HasForeignKey("CareerId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Career");
                });

            modelBuilder.Entity("Domain.Entities.Activity", b =>
                {
                    b.Navigation("Organizers");

                    b.Navigation("Scopes");
                });

            modelBuilder.Entity("Domain.Entities.Career", b =>
                {
                    b.Navigation("Activities");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("Domain.Entities.Faculty", b =>
                {
                    b.Navigation("Careers");
                });

            modelBuilder.Entity("Domain.Entities.Organization", b =>
                {
                    b.Navigation("Activities");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Navigation("CoordinatedActivities");

                    b.Navigation("RequestedActivities");

                    b.Navigation("ReviewedActivities");

                    b.Navigation("SupervisedActivities");
                });
#pragma warning restore 612, 618
        }
    }
}
