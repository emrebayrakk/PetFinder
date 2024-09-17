﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PetFinder.Infrastructure;

#nullable disable

namespace PetFinder.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("PetFinder.Domain.Species.Models.Breed", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)")
                        .HasColumnName("description");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)")
                        .HasColumnName("title");

                    b.Property<Guid>("species_id")
                        .HasColumnType("uuid")
                        .HasColumnName("species_id");

                    b.HasKey("Id")
                        .HasName("pk_breed");

                    b.HasIndex("species_id")
                        .HasDatabaseName("ix_breed_species_id");

                    b.ToTable("breed", (string)null);
                });

            modelBuilder.Entity("PetFinder.Domain.Species.Models.Species", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)")
                        .HasColumnName("title");

                    b.HasKey("Id")
                        .HasName("pk_species");

                    b.ToTable("species", (string)null);
                });

            modelBuilder.Entity("PetFinder.Domain.Volunteer.Models.Pet", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("AnimalType")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)")
                        .HasColumnName("animal_type");

                    b.Property<DateOnly>("BirthDate")
                        .HasColumnType("date")
                        .HasColumnName("birth_date");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("character varying(32)")
                        .HasColumnName("color");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("GeneralDescription")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("general_description");

                    b.Property<string>("HealthInformation")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("health_information");

                    b.Property<double>("Height")
                        .HasColumnType("double precision")
                        .HasColumnName("height");

                    b.Property<int>("HelpStatus")
                        .HasColumnType("integer")
                        .HasColumnName("help_status");

                    b.Property<bool>("IsCastrated")
                        .HasColumnType("boolean")
                        .HasColumnName("is_castrated");

                    b.Property<bool>("IsVaccinated")
                        .HasColumnType("boolean")
                        .HasColumnName("is_vaccinated");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)")
                        .HasColumnName("name");

                    b.Property<string>("OwnerPhoneNumber")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("character varying(16)")
                        .HasColumnName("owner_phone");

                    b.Property<double>("Weight")
                        .HasColumnType("double precision")
                        .HasColumnName("weight");

                    b.Property<Guid?>("volunteer_id")
                        .HasColumnType("uuid")
                        .HasColumnName("volunteer_id");

                    b.ComplexProperty<Dictionary<string, object>>("Address", "PetFinder.Domain.Volunteer.Models.Pet.Address#Address", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasMaxLength(64)
                                .HasColumnType("character varying(64)")
                                .HasColumnName("city");

                            b1.Property<string>("Country")
                                .IsRequired()
                                .HasMaxLength(64)
                                .HasColumnType("character varying(64)")
                                .HasColumnName("country");

                            b1.Property<string>("Description")
                                .HasMaxLength(64)
                                .HasColumnType("character varying(64)")
                                .HasColumnName("description");

                            b1.Property<string>("House")
                                .IsRequired()
                                .HasMaxLength(16)
                                .HasColumnType("character varying(16)")
                                .HasColumnName("house");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasMaxLength(64)
                                .HasColumnType("character varying(64)")
                                .HasColumnName("street");
                        });

                    b.ComplexProperty<Dictionary<string, object>>("SpeciesBreedObject", "PetFinder.Domain.Volunteer.Models.Pet.SpeciesBreedObject#SpeciesBreedObject", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<Guid>("BreedId")
                                .HasColumnType("uuid")
                                .HasColumnName("breed_id");

                            b1.Property<Guid>("SpeciesId")
                                .HasColumnType("uuid")
                                .HasColumnName("species_id");
                        });

                    b.HasKey("Id")
                        .HasName("pk_pets");

                    b.HasIndex("volunteer_id")
                        .HasDatabaseName("ix_pets_volunteer_id");

                    b.ToTable("pets", null, t =>
                        {
                            t.HasCheckConstraint("CK_Pet_height", "\"height\" > 0");

                            t.HasCheckConstraint("CK_Pet_weight", "\"weight\" > 0");
                        });
                });

            modelBuilder.Entity("PetFinder.Domain.Volunteer.Models.PetPhoto", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<bool>("IsMain")
                        .HasColumnType("boolean")
                        .HasColumnName("is_main");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("path");

                    b.Property<Guid?>("pet_id")
                        .HasColumnType("uuid")
                        .HasColumnName("pet_id");

                    b.HasKey("Id")
                        .HasName("pk_pet_photos");

                    b.HasIndex("pet_id")
                        .HasDatabaseName("ix_pet_photos_pet_id");

                    b.ToTable("pet_photos", (string)null);
                });

            modelBuilder.Entity("PetFinder.Domain.Volunteer.Models.Volunteer", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<int>("ExperienceYears")
                        .HasColumnType("integer")
                        .HasColumnName("experience_years");

                    b.ComplexProperty<Dictionary<string, object>>("Description", "PetFinder.Domain.Volunteer.Models.Volunteer.Description#VolunteerDescription", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(256)
                                .HasColumnType("character varying(256)")
                                .HasColumnName("description");
                        });

                    b.ComplexProperty<Dictionary<string, object>>("Email", "PetFinder.Domain.Volunteer.Models.Volunteer.Email#Email", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(256)
                                .HasColumnType("character varying(256)")
                                .HasColumnName("email");
                        });

                    b.ComplexProperty<Dictionary<string, object>>("PersonName", "PetFinder.Domain.Volunteer.Models.Volunteer.PersonName#PersonName", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("FirstName")
                                .IsRequired()
                                .HasMaxLength(32)
                                .HasColumnType("character varying(32)")
                                .HasColumnName("first_name");

                            b1.Property<string>("LastName")
                                .IsRequired()
                                .HasMaxLength(32)
                                .HasColumnType("character varying(32)")
                                .HasColumnName("last_name");

                            b1.Property<string>("MiddleName")
                                .HasMaxLength(32)
                                .HasColumnType("character varying(32)")
                                .HasColumnName("middle_name");
                        });

                    b.ComplexProperty<Dictionary<string, object>>("PhoneNumber", "PetFinder.Domain.Volunteer.Models.Volunteer.PhoneNumber#PhoneNumber", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(16)
                                .HasColumnType("character varying(16)")
                                .HasColumnName("phone_number");
                        });

                    b.HasKey("Id")
                        .HasName("pk_volunteers");

                    b.ToTable("volunteers", null, t =>
                        {
                            t.HasCheckConstraint("CK_Volunteer_experience_years", "\"experience_years\" >= 0");
                        });
                });

            modelBuilder.Entity("PetFinder.Domain.Species.Models.Breed", b =>
                {
                    b.HasOne("PetFinder.Domain.Species.Models.Species", "Species")
                        .WithMany("Breeds")
                        .HasForeignKey("species_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_breed_species_species_id");

                    b.Navigation("Species");
                });

            modelBuilder.Entity("PetFinder.Domain.Volunteer.Models.Pet", b =>
                {
                    b.HasOne("PetFinder.Domain.Volunteer.Models.Volunteer", null)
                        .WithMany("Pets")
                        .HasForeignKey("volunteer_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("fk_pets_volunteers_volunteer_id");
                });

            modelBuilder.Entity("PetFinder.Domain.Volunteer.Models.PetPhoto", b =>
                {
                    b.HasOne("PetFinder.Domain.Volunteer.Models.Pet", null)
                        .WithMany("Photos")
                        .HasForeignKey("pet_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("fk_pet_photos_pets_pet_id");
                });

            modelBuilder.Entity("PetFinder.Domain.Volunteer.Models.Volunteer", b =>
                {
                    b.OwnsMany("PetFinder.Domain.Volunteer.ValueObjects.AssistanceDetails", "AssistanceDetails", b1 =>
                        {
                            b1.Property<Guid>("VolunteerId")
                                .HasColumnType("uuid");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("integer");

                            b1.Property<string>("Description")
                                .IsRequired()
                                .HasMaxLength(256)
                                .HasColumnType("character varying(256)");

                            b1.Property<string>("Title")
                                .IsRequired()
                                .HasMaxLength(64)
                                .HasColumnType("character varying(64)");

                            b1.HasKey("VolunteerId", "Id")
                                .HasName("pk_volunteers");

                            b1.ToTable("volunteers");

                            b1.ToJson("assistance_details");

                            b1.WithOwner()
                                .HasForeignKey("VolunteerId")
                                .HasConstraintName("fk_volunteers_volunteers_volunteer_id");
                        });

                    b.OwnsMany("PetFinder.Domain.Volunteer.ValueObjects.SocialNetwork", "SocialNetworks", b1 =>
                        {
                            b1.Property<Guid>("VolunteerId")
                                .HasColumnType("uuid");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("integer");

                            b1.Property<string>("Title")
                                .IsRequired()
                                .HasMaxLength(32)
                                .HasColumnType("character varying(32)");

                            b1.Property<string>("Url")
                                .IsRequired()
                                .HasMaxLength(256)
                                .HasColumnType("character varying(256)");

                            b1.HasKey("VolunteerId", "Id")
                                .HasName("pk_volunteers");

                            b1.ToTable("volunteers");

                            b1.ToJson("social_networks");

                            b1.WithOwner()
                                .HasForeignKey("VolunteerId")
                                .HasConstraintName("fk_volunteers_volunteers_volunteer_id");
                        });

                    b.Navigation("AssistanceDetails");

                    b.Navigation("SocialNetworks");
                });

            modelBuilder.Entity("PetFinder.Domain.Species.Models.Species", b =>
                {
                    b.Navigation("Breeds");
                });

            modelBuilder.Entity("PetFinder.Domain.Volunteer.Models.Pet", b =>
                {
                    b.Navigation("Photos");
                });

            modelBuilder.Entity("PetFinder.Domain.Volunteer.Models.Volunteer", b =>
                {
                    b.Navigation("Pets");
                });
#pragma warning restore 612, 618
        }
    }
}
