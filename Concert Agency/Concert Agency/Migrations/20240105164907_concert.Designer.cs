﻿// <auto-generated />
using System;
using Concert_Agency;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Concert_Agency.Migrations
{
    [DbContext(typeof(ConcertContext))]
    [Migration("20240105164907_concert")]
    partial class concert
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Concert_Agency.Artist", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PassportData")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Artist");
                });

            modelBuilder.Entity("Concert_Agency.Concert", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("ConcertDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ConcertName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("VenueId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("VenueId");

                    b.ToTable("Concert");
                });

            modelBuilder.Entity("Concert_Agency.ConcertArtist", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ArtistId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ConcertId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ArtistId");

                    b.HasIndex("ConcertId");

                    b.ToTable("ConcertArtist");
                });

            modelBuilder.Entity("Concert_Agency.ConcertManager", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("ConcertDuties")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("ConcertId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ManagerId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ConcertId");

                    b.HasIndex("ManagerId");

                    b.ToTable("ConcertManager");
                });

            modelBuilder.Entity("Concert_Agency.ConcertOrganization", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<double>("FinalReceipt")
                        .HasColumnType("double precision");

                    b.Property<Guid>("ID_Concert")
                        .HasColumnType("uuid");

                    b.Property<Guid>("VenueId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ID_Concert")
                        .IsUnique();

                    b.HasIndex("VenueId");

                    b.ToTable("ConcertOrganization");
                });

            modelBuilder.Entity("Concert_Agency.Manager", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PassportData")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Manager");
                });

            modelBuilder.Entity("Concert_Agency.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ArtistId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ManagerId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("OrderNum")
                        .HasColumnType("bigint");

                    b.Property<string>("OrderStatus")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ArtistId");

                    b.HasIndex("ManagerId");

                    b.HasIndex("OrderNum")
                        .IsUnique();

                    b.ToTable("Order");
                });

            modelBuilder.Entity("Concert_Agency.OrganizationalRequest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("OrganizationParameters")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("TechnicalParametersId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("VenueId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("TechnicalParametersId");

                    b.HasIndex("VenueId");

                    b.ToTable("OrganizationalRequest");
                });

            modelBuilder.Entity("Concert_Agency.Rider", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ArtistId")
                        .HasColumnType("uuid");

                    b.Property<string>("Requirements")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("RiderDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("ArtistId");

                    b.ToTable("Rider");
                });

            modelBuilder.Entity("Concert_Agency.RiderRequest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("RiderId")
                        .HasColumnType("uuid");

                    b.Property<string>("RiderParameters")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("TechnicalParametersId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("RiderId");

                    b.HasIndex("TechnicalParametersId");

                    b.ToTable("RiderRequest");
                });

            modelBuilder.Entity("Concert_Agency.TechnicalParameters", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("AttributeParameters")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("TechnicalParameter");
                });

            modelBuilder.Entity("Concert_Agency.Ticket", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ConcertId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("buyDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("typePrice")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ConcertId");

                    b.ToTable("Ticket");
                });

            modelBuilder.Entity("Concert_Agency.Venue", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("VenueName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("VenueName", "City", "Country")
                        .IsUnique();

                    b.ToTable("Venue");
                });

            modelBuilder.Entity("Concert_Agency.Concert", b =>
                {
                    b.HasOne("Concert_Agency.Venue", "Venue")
                        .WithMany()
                        .HasForeignKey("VenueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Venue");
                });

            modelBuilder.Entity("Concert_Agency.ConcertArtist", b =>
                {
                    b.HasOne("Concert_Agency.Artist", "Artist")
                        .WithMany("ConcertArtists")
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Concert_Agency.Concert", "Concert")
                        .WithMany("ConcertArtists")
                        .HasForeignKey("ConcertId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Artist");

                    b.Navigation("Concert");
                });

            modelBuilder.Entity("Concert_Agency.ConcertManager", b =>
                {
                    b.HasOne("Concert_Agency.Concert", "Concert")
                        .WithMany("ConcertManagers")
                        .HasForeignKey("ConcertId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Concert_Agency.Manager", "Manager")
                        .WithMany("ConcertManagers")
                        .HasForeignKey("ManagerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Concert");

                    b.Navigation("Manager");
                });

            modelBuilder.Entity("Concert_Agency.ConcertOrganization", b =>
                {
                    b.HasOne("Concert_Agency.Concert", "Concert")
                        .WithOne("ConcertOrganization")
                        .HasForeignKey("Concert_Agency.ConcertOrganization", "ID_Concert")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Concert_Agency.Venue", "Venue")
                        .WithMany("ConcertOrganizations")
                        .HasForeignKey("VenueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Concert");

                    b.Navigation("Venue");
                });

            modelBuilder.Entity("Concert_Agency.Order", b =>
                {
                    b.HasOne("Concert_Agency.Artist", "Artist")
                        .WithMany("Orders")
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Concert_Agency.Manager", "Manager")
                        .WithMany("Orders")
                        .HasForeignKey("ManagerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Artist");

                    b.Navigation("Manager");
                });

            modelBuilder.Entity("Concert_Agency.OrganizationalRequest", b =>
                {
                    b.HasOne("Concert_Agency.TechnicalParameters", "TechnicalParameters")
                        .WithMany()
                        .HasForeignKey("TechnicalParametersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Concert_Agency.Venue", "Venue")
                        .WithMany("OrganizationalRequests")
                        .HasForeignKey("VenueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TechnicalParameters");

                    b.Navigation("Venue");
                });

            modelBuilder.Entity("Concert_Agency.Rider", b =>
                {
                    b.HasOne("Concert_Agency.Artist", "Artist")
                        .WithMany("Riders")
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Artist");
                });

            modelBuilder.Entity("Concert_Agency.RiderRequest", b =>
                {
                    b.HasOne("Concert_Agency.Rider", "Rider")
                        .WithMany("RidersRequests")
                        .HasForeignKey("RiderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Concert_Agency.TechnicalParameters", "TechnicalParameters")
                        .WithMany()
                        .HasForeignKey("TechnicalParametersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rider");

                    b.Navigation("TechnicalParameters");
                });

            modelBuilder.Entity("Concert_Agency.Ticket", b =>
                {
                    b.HasOne("Concert_Agency.Concert", "Concert")
                        .WithMany("Tickets")
                        .HasForeignKey("ConcertId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Concert");
                });

            modelBuilder.Entity("Concert_Agency.Artist", b =>
                {
                    b.Navigation("ConcertArtists");

                    b.Navigation("Orders");

                    b.Navigation("Riders");
                });

            modelBuilder.Entity("Concert_Agency.Concert", b =>
                {
                    b.Navigation("ConcertArtists");

                    b.Navigation("ConcertManagers");

                    b.Navigation("ConcertOrganization")
                        .IsRequired();

                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("Concert_Agency.Manager", b =>
                {
                    b.Navigation("ConcertManagers");

                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Concert_Agency.Rider", b =>
                {
                    b.Navigation("RidersRequests");
                });

            modelBuilder.Entity("Concert_Agency.Venue", b =>
                {
                    b.Navigation("ConcertOrganizations");

                    b.Navigation("OrganizationalRequests");
                });
#pragma warning restore 612, 618
        }
    }
}