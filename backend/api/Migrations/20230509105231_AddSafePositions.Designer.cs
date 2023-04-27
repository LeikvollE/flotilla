﻿// <auto-generated />
using System;
using Api.Database.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Api.Migrations
{
    [DbContext(typeof(FlotillaDbContext))]
    [Migration("20230509105231_AddSafePositions")]
    partial class AddSafePositions
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Api.Database.Models.AssetDeck", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AssetCode")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("DeckName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("AssetCode", "DeckName")
                        .IsUnique();

                    b.ToTable("AssetDecks");
                });

            modelBuilder.Entity("Api.Database.Models.Mission", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AssetCode")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Comment")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Description")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTimeOffset>("DesiredStartTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("EchoMissionId")
                        .HasMaxLength(200)
                        .HasColumnType("int");

                    b.Property<DateTimeOffset?>("EndTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<TimeSpan?>("EstimatedDuration")
                        .HasColumnType("time");

                    b.Property<string>("IsarMissionId")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("RobotId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTimeOffset?>("StartTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("StatusReason")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RobotId");

                    b.ToTable("Missions");
                });

            modelBuilder.Entity("Api.Database.Models.Robot", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<float>("BatteryLevel")
                        .HasColumnType("real");

                    b.Property<string>("CurrentMissionId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Enabled")
                        .HasColumnType("bit");

                    b.Property<string>("Host")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("IsarId")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("ModelId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("Port")
                        .HasColumnType("int");

                    b.Property<float?>("PressureLevel")
                        .HasColumnType("real");

                    b.Property<string>("SerialNumber")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ModelId");

                    b.ToTable("Robots");
                });

            modelBuilder.Entity("Api.Database.Models.RobotModel", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<float?>("BatteryWarningThreshold")
                        .HasColumnType("real");

                    b.Property<float?>("LowerPressureWarningThreshold")
                        .HasColumnType("real");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(56)");

                    b.Property<float?>("UpperPressureWarningThreshold")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("Type")
                        .IsUnique();

                    b.ToTable("RobotModels");
                });

            modelBuilder.Entity("Api.Database.Models.SafePosition", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AssetDeckId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("AssetDeckId");

                    b.ToTable("SafePosition");
                });

            modelBuilder.Entity("Api.Database.Models.AssetDeck", b =>
                {
                    b.OwnsOne("Api.Database.Models.Pose", "DefaultLocalizationPose", b1 =>
                        {
                            b1.Property<string>("AssetDeckId")
                                .HasColumnType("nvarchar(450)");

                            b1.HasKey("AssetDeckId");

                            b1.ToTable("AssetDecks");

                            b1.WithOwner()
                                .HasForeignKey("AssetDeckId");

                            b1.OwnsOne("Api.Database.Models.Orientation", "Orientation", b2 =>
                                {
                                    b2.Property<string>("PoseAssetDeckId")
                                        .HasColumnType("nvarchar(450)");

                                    b2.Property<float>("W")
                                        .HasColumnType("real");

                                    b2.Property<float>("X")
                                        .HasColumnType("real");

                                    b2.Property<float>("Y")
                                        .HasColumnType("real");

                                    b2.Property<float>("Z")
                                        .HasColumnType("real");

                                    b2.HasKey("PoseAssetDeckId");

                                    b2.ToTable("AssetDecks");

                                    b2.WithOwner()
                                        .HasForeignKey("PoseAssetDeckId");
                                });

                            b1.OwnsOne("Api.Database.Models.Position", "Position", b2 =>
                                {
                                    b2.Property<string>("PoseAssetDeckId")
                                        .HasColumnType("nvarchar(450)");

                                    b2.Property<float>("X")
                                        .HasColumnType("real");

                                    b2.Property<float>("Y")
                                        .HasColumnType("real");

                                    b2.Property<float>("Z")
                                        .HasColumnType("real");

                                    b2.HasKey("PoseAssetDeckId");

                                    b2.ToTable("AssetDecks");

                                    b2.WithOwner()
                                        .HasForeignKey("PoseAssetDeckId");
                                });

                            b1.Navigation("Orientation")
                                .IsRequired();

                            b1.Navigation("Position")
                                .IsRequired();
                        });

                    b.Navigation("DefaultLocalizationPose")
                        .IsRequired();
                });

            modelBuilder.Entity("Api.Database.Models.Mission", b =>
                {
                    b.HasOne("Api.Database.Models.Robot", "Robot")
                        .WithMany()
                        .HasForeignKey("RobotId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Api.Database.Models.MissionMap", "Map", b1 =>
                        {
                            b1.Property<string>("MissionId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<string>("MapName")
                                .IsRequired()
                                .HasMaxLength(200)
                                .HasColumnType("nvarchar(200)");

                            b1.HasKey("MissionId");

                            b1.ToTable("Missions");

                            b1.WithOwner()
                                .HasForeignKey("MissionId");

                            b1.OwnsOne("Api.Database.Models.Boundary", "Boundary", b2 =>
                                {
                                    b2.Property<string>("MissionMapMissionId")
                                        .HasColumnType("nvarchar(450)");

                                    b2.Property<double>("X1")
                                        .HasColumnType("float");

                                    b2.Property<double>("X2")
                                        .HasColumnType("float");

                                    b2.Property<double>("Y1")
                                        .HasColumnType("float");

                                    b2.Property<double>("Y2")
                                        .HasColumnType("float");

                                    b2.Property<double>("Z1")
                                        .HasColumnType("float");

                                    b2.Property<double>("Z2")
                                        .HasColumnType("float");

                                    b2.HasKey("MissionMapMissionId");

                                    b2.ToTable("Missions");

                                    b2.WithOwner()
                                        .HasForeignKey("MissionMapMissionId");
                                });

                            b1.OwnsOne("Api.Database.Models.TransformationMatrices", "TransformationMatrices", b2 =>
                                {
                                    b2.Property<string>("MissionMapMissionId")
                                        .HasColumnType("nvarchar(450)");

                                    b2.Property<double>("C1")
                                        .HasColumnType("float");

                                    b2.Property<double>("C2")
                                        .HasColumnType("float");

                                    b2.Property<double>("D1")
                                        .HasColumnType("float");

                                    b2.Property<double>("D2")
                                        .HasColumnType("float");

                                    b2.HasKey("MissionMapMissionId");

                                    b2.ToTable("Missions");

                                    b2.WithOwner()
                                        .HasForeignKey("MissionMapMissionId");
                                });

                            b1.Navigation("Boundary")
                                .IsRequired();

                            b1.Navigation("TransformationMatrices")
                                .IsRequired();
                        });

                    b.OwnsMany("Api.Database.Models.MissionTask", "Tasks", b1 =>
                        {
                            b1.Property<string>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("nvarchar(450)");

                            b1.Property<string>("Description")
                                .HasMaxLength(500)
                                .HasColumnType("nvarchar(500)");

                            b1.Property<int?>("EchoPoseId")
                                .HasColumnType("int");

                            b1.Property<string>("EchoTagLink")
                                .HasMaxLength(200)
                                .HasColumnType("nvarchar(200)");

                            b1.Property<DateTimeOffset?>("EndTime")
                                .HasColumnType("datetimeoffset");

                            b1.Property<string>("IsarTaskId")
                                .HasMaxLength(200)
                                .HasColumnType("nvarchar(200)");

                            b1.Property<string>("MissionId")
                                .IsRequired()
                                .HasColumnType("nvarchar(450)");

                            b1.Property<DateTimeOffset?>("StartTime")
                                .HasColumnType("datetimeoffset");

                            b1.Property<int>("Status")
                                .HasColumnType("int");

                            b1.Property<string>("TagId")
                                .HasMaxLength(200)
                                .HasColumnType("nvarchar(200)");

                            b1.Property<int>("TaskOrder")
                                .HasColumnType("int");

                            b1.HasKey("Id");

                            b1.HasIndex("MissionId");

                            b1.ToTable("MissionTask");

                            b1.WithOwner()
                                .HasForeignKey("MissionId");

                            b1.OwnsMany("Api.Database.Models.Inspection", "Inspections", b2 =>
                                {
                                    b2.Property<string>("Id")
                                        .ValueGeneratedOnAdd()
                                        .HasColumnType("nvarchar(450)");

                                    b2.Property<string>("AnalysisTypes")
                                        .HasMaxLength(250)
                                        .HasColumnType("nvarchar(250)");

                                    b2.Property<DateTimeOffset?>("EndTime")
                                        .HasColumnType("datetimeoffset");

                                    b2.Property<int>("InspectionType")
                                        .HasColumnType("int");

                                    b2.Property<string>("InspectionUrl")
                                        .HasMaxLength(250)
                                        .HasColumnType("nvarchar(250)");

                                    b2.Property<string>("IsarStepId")
                                        .HasMaxLength(200)
                                        .HasColumnType("nvarchar(200)");

                                    b2.Property<string>("MissionTaskId")
                                        .IsRequired()
                                        .HasColumnType("nvarchar(450)");

                                    b2.Property<DateTimeOffset?>("StartTime")
                                        .HasColumnType("datetimeoffset");

                                    b2.Property<int>("Status")
                                        .HasColumnType("int");

                                    b2.Property<float?>("VideoDuration")
                                        .HasColumnType("real");

                                    b2.HasKey("Id");

                                    b2.HasIndex("MissionTaskId");

                                    b2.ToTable("Inspection");

                                    b2.WithOwner()
                                        .HasForeignKey("MissionTaskId");
                                });

                            b1.OwnsOne("Api.Database.Models.Position", "InspectionTarget", b2 =>
                                {
                                    b2.Property<string>("MissionTaskId")
                                        .HasColumnType("nvarchar(450)");

                                    b2.Property<float>("X")
                                        .HasColumnType("real");

                                    b2.Property<float>("Y")
                                        .HasColumnType("real");

                                    b2.Property<float>("Z")
                                        .HasColumnType("real");

                                    b2.HasKey("MissionTaskId");

                                    b2.ToTable("MissionTask");

                                    b2.WithOwner()
                                        .HasForeignKey("MissionTaskId");
                                });

                            b1.OwnsOne("Api.Database.Models.Pose", "RobotPose", b2 =>
                                {
                                    b2.Property<string>("MissionTaskId")
                                        .HasColumnType("nvarchar(450)");

                                    b2.HasKey("MissionTaskId");

                                    b2.ToTable("MissionTask");

                                    b2.WithOwner()
                                        .HasForeignKey("MissionTaskId");

                                    b2.OwnsOne("Api.Database.Models.Orientation", "Orientation", b3 =>
                                        {
                                            b3.Property<string>("PoseMissionTaskId")
                                                .HasColumnType("nvarchar(450)");

                                            b3.Property<float>("W")
                                                .HasColumnType("real");

                                            b3.Property<float>("X")
                                                .HasColumnType("real");

                                            b3.Property<float>("Y")
                                                .HasColumnType("real");

                                            b3.Property<float>("Z")
                                                .HasColumnType("real");

                                            b3.HasKey("PoseMissionTaskId");

                                            b3.ToTable("MissionTask");

                                            b3.WithOwner()
                                                .HasForeignKey("PoseMissionTaskId");
                                        });

                                    b2.OwnsOne("Api.Database.Models.Position", "Position", b3 =>
                                        {
                                            b3.Property<string>("PoseMissionTaskId")
                                                .HasColumnType("nvarchar(450)");

                                            b3.Property<float>("X")
                                                .HasColumnType("real");

                                            b3.Property<float>("Y")
                                                .HasColumnType("real");

                                            b3.Property<float>("Z")
                                                .HasColumnType("real");

                                            b3.HasKey("PoseMissionTaskId");

                                            b3.ToTable("MissionTask");

                                            b3.WithOwner()
                                                .HasForeignKey("PoseMissionTaskId");
                                        });

                                    b2.Navigation("Orientation")
                                        .IsRequired();

                                    b2.Navigation("Position")
                                        .IsRequired();
                                });

                            b1.Navigation("InspectionTarget")
                                .IsRequired();

                            b1.Navigation("Inspections");

                            b1.Navigation("RobotPose")
                                .IsRequired();
                        });

                    b.Navigation("Map");

                    b.Navigation("Robot");

                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("Api.Database.Models.Robot", b =>
                {
                    b.HasOne("Api.Database.Models.RobotModel", "Model")
                        .WithMany()
                        .HasForeignKey("ModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Api.Database.Models.Pose", "Pose", b1 =>
                        {
                            b1.Property<string>("RobotId")
                                .HasColumnType("nvarchar(450)");

                            b1.HasKey("RobotId");

                            b1.ToTable("Robots");

                            b1.WithOwner()
                                .HasForeignKey("RobotId");

                            b1.OwnsOne("Api.Database.Models.Orientation", "Orientation", b2 =>
                                {
                                    b2.Property<string>("PoseRobotId")
                                        .HasColumnType("nvarchar(450)");

                                    b2.Property<float>("W")
                                        .HasColumnType("real");

                                    b2.Property<float>("X")
                                        .HasColumnType("real");

                                    b2.Property<float>("Y")
                                        .HasColumnType("real");

                                    b2.Property<float>("Z")
                                        .HasColumnType("real");

                                    b2.HasKey("PoseRobotId");

                                    b2.ToTable("Robots");

                                    b2.WithOwner()
                                        .HasForeignKey("PoseRobotId");
                                });

                            b1.OwnsOne("Api.Database.Models.Position", "Position", b2 =>
                                {
                                    b2.Property<string>("PoseRobotId")
                                        .HasColumnType("nvarchar(450)");

                                    b2.Property<float>("X")
                                        .HasColumnType("real");

                                    b2.Property<float>("Y")
                                        .HasColumnType("real");

                                    b2.Property<float>("Z")
                                        .HasColumnType("real");

                                    b2.HasKey("PoseRobotId");

                                    b2.ToTable("Robots");

                                    b2.WithOwner()
                                        .HasForeignKey("PoseRobotId");
                                });

                            b1.Navigation("Orientation")
                                .IsRequired();

                            b1.Navigation("Position")
                                .IsRequired();
                        });

                    b.OwnsMany("Api.Database.Models.VideoStream", "VideoStreams", b1 =>
                        {
                            b1.Property<string>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("nvarchar(450)");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasMaxLength(200)
                                .HasColumnType("nvarchar(200)");

                            b1.Property<string>("RobotId")
                                .IsRequired()
                                .HasColumnType("nvarchar(450)");

                            b1.Property<bool>("ShouldRotate270Clockwise")
                                .HasColumnType("bit");

                            b1.Property<string>("Type")
                                .IsRequired()
                                .HasMaxLength(64)
                                .HasColumnType("nvarchar(64)");

                            b1.Property<string>("Url")
                                .IsRequired()
                                .HasMaxLength(200)
                                .HasColumnType("nvarchar(200)");

                            b1.HasKey("Id");

                            b1.HasIndex("RobotId");

                            b1.ToTable("VideoStream");

                            b1.WithOwner()
                                .HasForeignKey("RobotId");
                        });

                    b.Navigation("Model");

                    b.Navigation("Pose")
                        .IsRequired();

                    b.Navigation("VideoStreams");
                });

            modelBuilder.Entity("Api.Database.Models.SafePosition", b =>
                {
                    b.HasOne("Api.Database.Models.AssetDeck", null)
                        .WithMany("SafePositions")
                        .HasForeignKey("AssetDeckId");

                    b.OwnsOne("Api.Database.Models.Pose", "Pose", b1 =>
                        {
                            b1.Property<string>("SafePositionId")
                                .HasColumnType("nvarchar(450)");

                            b1.HasKey("SafePositionId");

                            b1.ToTable("SafePosition");

                            b1.WithOwner()
                                .HasForeignKey("SafePositionId");

                            b1.OwnsOne("Api.Database.Models.Orientation", "Orientation", b2 =>
                                {
                                    b2.Property<string>("PoseSafePositionId")
                                        .HasColumnType("nvarchar(450)");

                                    b2.Property<float>("W")
                                        .HasColumnType("real");

                                    b2.Property<float>("X")
                                        .HasColumnType("real");

                                    b2.Property<float>("Y")
                                        .HasColumnType("real");

                                    b2.Property<float>("Z")
                                        .HasColumnType("real");

                                    b2.HasKey("PoseSafePositionId");

                                    b2.ToTable("SafePosition");

                                    b2.WithOwner()
                                        .HasForeignKey("PoseSafePositionId");
                                });

                            b1.OwnsOne("Api.Database.Models.Position", "Position", b2 =>
                                {
                                    b2.Property<string>("PoseSafePositionId")
                                        .HasColumnType("nvarchar(450)");

                                    b2.Property<float>("X")
                                        .HasColumnType("real");

                                    b2.Property<float>("Y")
                                        .HasColumnType("real");

                                    b2.Property<float>("Z")
                                        .HasColumnType("real");

                                    b2.HasKey("PoseSafePositionId");

                                    b2.ToTable("SafePosition");

                                    b2.WithOwner()
                                        .HasForeignKey("PoseSafePositionId");
                                });

                            b1.Navigation("Orientation")
                                .IsRequired();

                            b1.Navigation("Position")
                                .IsRequired();
                        });

                    b.Navigation("Pose")
                        .IsRequired();
                });

            modelBuilder.Entity("Api.Database.Models.AssetDeck", b =>
                {
                    b.Navigation("SafePositions");
                });
#pragma warning restore 612, 618
        }
    }
}
