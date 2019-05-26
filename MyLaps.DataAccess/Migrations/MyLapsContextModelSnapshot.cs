﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyLaps.DataAccess;

namespace MyLaps.DataAccess.Migrations
{
    [DbContext(typeof(MyLapsContext))]
    partial class MyLapsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity("MyLaps.DataAccess.Entities.CorralEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CriteriaType");

                    b.Property<int?>("Gender");

                    b.Property<int?>("MaxAge");

                    b.Property<int>("MaxElements");

                    b.Property<int?>("MaxRaceTime");

                    b.Property<int?>("MinAge");

                    b.Property<int?>("MinRaceTime");

                    b.Property<string>("Name");

                    b.Property<int>("RunnerCount");

                    b.Property<int>("StartBIBNumber");

                    b.HasKey("Id");

                    b.ToTable("Corrals");
                });

            modelBuilder.Entity("MyLaps.DataAccess.Entities.RunnerEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Age");

                    b.Property<int>("BIBNumber");

                    b.Property<int?>("CorralId");

                    b.Property<int>("Gender");

                    b.Property<int>("RaceTime");

                    b.HasKey("Id");

                    b.ToTable("Runners");
                });
#pragma warning restore 612, 618
        }
    }
}
