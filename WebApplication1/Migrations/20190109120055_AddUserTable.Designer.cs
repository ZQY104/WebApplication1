﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication1.Models;

namespace WebApplication1.Migrations
{
    [DbContext(typeof(WebApplication1ScheduleContext))]
    [Migration("20190109120055_AddUserTable")]
    partial class AddUserTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApplication1.Models.Schedule", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PrivateSchedule");

                    b.Property<long>("PrivateScheduleSize");

                    b.Property<string>("PublicSchedule");

                    b.Property<long>("PublicScheduleSize");

                    b.Property<string>("Title");

                    b.Property<DateTime>("UploadeDT");

                    b.HasKey("ID");

                    b.ToTable("Schedule");
                });

            modelBuilder.Entity("WebApplication1.Models.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Link");

                    b.Property<string>("Name");

                    b.Property<string>("Sex");

                    b.HasKey("ID");

                    b.ToTable("User");
                });
#pragma warning restore 612, 618
        }
    }
}
