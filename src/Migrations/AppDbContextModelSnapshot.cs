﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using backend_challenge.context;

#nullable disable

namespace backend_challenge.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.11");

            modelBuilder.Entity("backend_challenge.Modules.hero.repository.Hero", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("image")
                        .HasColumnType("TEXT");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("Heroes");
                });

            modelBuilder.Entity("backend_challenge.Modules.heroSuperPower.repository.HeroSuperpower", b =>
                {
                    b.Property<Guid>("HeroId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("SuperpowerId")
                        .HasColumnType("TEXT");

                    b.HasKey("HeroId", "SuperpowerId");

                    b.HasIndex("SuperpowerId");

                    b.ToTable("HeroSuperpowers");
                });

            modelBuilder.Entity("backend_challenge.Modules.superpower.repository.Superpower", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("Heroid")
                        .HasColumnType("TEXT");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.HasIndex("Heroid");

                    b.ToTable("SuperPowers");

                    b.HasData(
                        new
                        {
                            id = new Guid("9fb6500b-c7fc-4681-8574-197330792c46"),
                            name = "Super Strength"
                        },
                        new
                        {
                            id = new Guid("09702387-0f1c-4b11-af45-f93aab2c0ed3"),
                            name = "Super Speed"
                        },
                        new
                        {
                            id = new Guid("444072c0-3f51-494c-bf72-979e35a88fb9"),
                            name = "Flight"
                        },
                        new
                        {
                            id = new Guid("83864131-d564-4e7f-9250-8bb2d1d96f20"),
                            name = "Teleportation"
                        },
                        new
                        {
                            id = new Guid("ea5c545c-bca6-41fd-8b82-7875a1b7b1c3"),
                            name = "Telekinesis"
                        },
                        new
                        {
                            id = new Guid("89b75b4c-1c0f-4fa1-83fd-9602339cb0dd"),
                            name = "Mind Control"
                        },
                        new
                        {
                            id = new Guid("e6c13a5c-9625-48d0-9bd9-c91435f3361e"),
                            name = "Invisibility"
                        },
                        new
                        {
                            id = new Guid("cef07ac2-3f3b-4ba2-adfd-d603f5db1ca6"),
                            name = "Healing"
                        });
                });

            modelBuilder.Entity("backend_challenge.Modules.uniformColor.repository.UniformColor", b =>
                {
                    b.Property<Guid>("id")
                        .HasColumnType("TEXT");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("UniformColors");

                    b.HasData(
                        new
                        {
                            id = new Guid("1c628125-6eb0-42f8-872a-59cac063775e"),
                            name = "Red"
                        },
                        new
                        {
                            id = new Guid("4e767aa0-81f5-45a9-aaf6-11a9d9fea1e3"),
                            name = "Blue"
                        },
                        new
                        {
                            id = new Guid("3a490cf4-c716-4abe-8b0d-2d74751a99e8"),
                            name = "Green"
                        },
                        new
                        {
                            id = new Guid("3588576e-36e2-4c60-9027-40e843592526"),
                            name = "Yellow"
                        },
                        new
                        {
                            id = new Guid("ac5607a2-3ece-42bc-9460-727310e1c133"),
                            name = "Orange"
                        },
                        new
                        {
                            id = new Guid("d703951f-117b-4357-89ba-8deeee852eee"),
                            name = "Purple"
                        },
                        new
                        {
                            id = new Guid("c14713bb-777d-472a-9d5d-6113ad78ef2c"),
                            name = "Black"
                        },
                        new
                        {
                            id = new Guid("dab280fa-7437-4685-b0b5-b6beee271a74"),
                            name = "White"
                        });
                });

            modelBuilder.Entity("backend_challenge.Modules.heroSuperPower.repository.HeroSuperpower", b =>
                {
                    b.HasOne("backend_challenge.Modules.hero.repository.Hero", "Hero")
                        .WithMany()
                        .HasForeignKey("HeroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("backend_challenge.Modules.superpower.repository.Superpower", "Superpower")
                        .WithMany("HeroSuperpowers")
                        .HasForeignKey("SuperpowerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hero");

                    b.Navigation("Superpower");
                });

            modelBuilder.Entity("backend_challenge.Modules.superpower.repository.Superpower", b =>
                {
                    b.HasOne("backend_challenge.Modules.hero.repository.Hero", null)
                        .WithMany("Superpowers")
                        .HasForeignKey("Heroid");
                });

            modelBuilder.Entity("backend_challenge.Modules.uniformColor.repository.UniformColor", b =>
                {
                    b.HasOne("backend_challenge.Modules.hero.repository.Hero", "Hero")
                        .WithOne("UniformColor")
                        .HasForeignKey("backend_challenge.Modules.uniformColor.repository.UniformColor", "id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hero");
                });

            modelBuilder.Entity("backend_challenge.Modules.hero.repository.Hero", b =>
                {
                    b.Navigation("Superpowers");

                    b.Navigation("UniformColor")
                        .IsRequired();
                });

            modelBuilder.Entity("backend_challenge.Modules.superpower.repository.Superpower", b =>
                {
                    b.Navigation("HeroSuperpowers");
                });
#pragma warning restore 612, 618
        }
    }
}
