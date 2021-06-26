﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TrafficSignal.API.DbContexts;

namespace TrafficSignal.API.Migrations
{
    [DbContext(typeof(TrafficSignalDBContext))]
    [Migration("20210626094929_Made Status Date Time")]
    partial class MadeStatusDateTime
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TrafficSignal.Web.DomainModels.TrafficJunction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedOn");

                    b.Property<bool>("IsActive");

                    b.Property<DateTime?>("ModifiedOn");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("TrafficJunctions");
                });

            modelBuilder.Entity("TrafficSignal.Web.DomainModels.TrafficLight", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedOn");

                    b.Property<int>("Duration");

                    b.Property<int>("JunctionId");

                    b.Property<DateTime?>("ModifiedOn");

                    b.Property<int>("Name");

                    b.Property<int>("Order");

                    b.Property<DateTime?>("StatusChangeDateTime");

                    b.Property<int>("StatusId");

                    b.HasKey("Id");

                    b.HasIndex("JunctionId");

                    b.ToTable("TrafficLights");
                });

            modelBuilder.Entity("TrafficSignal.Web.DomainModels.TrafficLight", b =>
                {
                    b.HasOne("TrafficSignal.Web.DomainModels.TrafficJunction", "Junction")
                        .WithMany("Lights")
                        .HasForeignKey("JunctionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
