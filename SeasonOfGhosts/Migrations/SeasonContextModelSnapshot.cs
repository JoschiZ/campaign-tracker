﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SeasonOfGhosts.Db;

#nullable disable

namespace SeasonOfGhosts.Migrations
{
    [DbContext(typeof(SeasonContext))]
    partial class SeasonContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CharacterFaction", b =>
                {
                    b.Property<int>("CharactersId")
                        .HasColumnType("integer");

                    b.Property<int>("FactionsId")
                        .HasColumnType("integer");

                    b.HasKey("CharactersId", "FactionsId");

                    b.HasIndex("FactionsId");

                    b.ToTable("CharacterFaction");
                });

            modelBuilder.Entity("SeasonOfGhosts.Core.Campaigns.Campaign", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("character(10)")
                        .IsFixedLength();

                    b.Property<int>("CurrentSeason")
                        .HasColumnType("integer");

                    b.Property<int?>("MainSettlementId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)");

                    b.HasKey("Id");

                    b.HasIndex("MainSettlementId");

                    b.ToTable("Campaigns");
                });

            modelBuilder.Entity("SeasonOfGhosts.Core.Characters.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Attitude")
                        .HasColumnType("integer");

                    b.Property<int>("CampaignId")
                        .HasColumnType("integer");

                    b.Property<int>("Influence")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("ShortDescription")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.HasIndex("CampaignId");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("SeasonOfGhosts.Core.Characters.CharacterLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CharacterId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("LogType")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("character varying(13)");

                    b.Property<string>("Reason")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId");

                    b.ToTable("CharacterLog");

                    b.HasDiscriminator<string>("LogType").HasValue("CharacterLog");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("SeasonOfGhosts.Core.Factions.Faction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CampaignId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<int>("Reputation")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CampaignId");

                    b.ToTable("Factions");
                });

            modelBuilder.Entity("SeasonOfGhosts.Core.Factions.FactionLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Delta")
                        .HasColumnType("integer");

                    b.Property<int>("FactionId")
                        .HasColumnType("integer");

                    b.Property<string>("Reason")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.HasIndex("FactionId");

                    b.ToTable("FactionLogs");
                });

            modelBuilder.Entity("SeasonOfGhosts.Core.Settlements.Settlement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CampaignId")
                        .HasColumnType("integer");

                    b.Property<int>("Level")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<int>("Population")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CampaignId");

                    b.ToTable("Settlements");
                });

            modelBuilder.Entity("SeasonOfGhosts.Core.Settlements.SettlementLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Delta")
                        .HasColumnType("integer");

                    b.Property<string>("LogType")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("character varying(13)");

                    b.Property<string>("Reason")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<int>("SettlementId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("SettlementId");

                    b.ToTable("SettlementLogs");

                    b.HasDiscriminator<string>("LogType").HasValue("SettlementLog");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("SeasonOfGhosts.Core.Stats.Stat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CampaignId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<int>("Value")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CampaignId");

                    b.ToTable("Stats");
                });

            modelBuilder.Entity("SeasonOfGhosts.Core.Stats.StatLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Delta")
                        .HasColumnType("integer");

                    b.Property<string>("Reason")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int>("StatId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("StatId");

                    b.ToTable("StatLogs");
                });

            modelBuilder.Entity("SeasonOfGhosts.Core.Characters.CharacterAttitudeLog", b =>
                {
                    b.HasBaseType("SeasonOfGhosts.Core.Characters.CharacterLog");

                    b.Property<int>("NewAttitude")
                        .HasColumnType("integer");

                    b.HasDiscriminator().HasValue("attitude");
                });

            modelBuilder.Entity("SeasonOfGhosts.Core.Characters.CharacterInfluenceLog", b =>
                {
                    b.HasBaseType("SeasonOfGhosts.Core.Characters.CharacterLog");

                    b.Property<int>("Delta")
                        .HasColumnType("integer");

                    b.HasDiscriminator().HasValue("influence");
                });

            modelBuilder.Entity("SeasonOfGhosts.Core.Settlements.SettlementLevelLog", b =>
                {
                    b.HasBaseType("SeasonOfGhosts.Core.Settlements.SettlementLog");

                    b.HasDiscriminator().HasValue("level");
                });

            modelBuilder.Entity("SeasonOfGhosts.Core.Settlements.SettlementPopulationLog", b =>
                {
                    b.HasBaseType("SeasonOfGhosts.Core.Settlements.SettlementLog");

                    b.HasDiscriminator().HasValue("population");
                });

            modelBuilder.Entity("CharacterFaction", b =>
                {
                    b.HasOne("SeasonOfGhosts.Core.Characters.Character", null)
                        .WithMany()
                        .HasForeignKey("CharactersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SeasonOfGhosts.Core.Factions.Faction", null)
                        .WithMany()
                        .HasForeignKey("FactionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SeasonOfGhosts.Core.Campaigns.Campaign", b =>
                {
                    b.HasOne("SeasonOfGhosts.Core.Settlements.Settlement", "MainSettlement")
                        .WithMany()
                        .HasForeignKey("MainSettlementId");

                    b.Navigation("MainSettlement");
                });

            modelBuilder.Entity("SeasonOfGhosts.Core.Characters.Character", b =>
                {
                    b.HasOne("SeasonOfGhosts.Core.Campaigns.Campaign", "Campaign")
                        .WithMany("Characters")
                        .HasForeignKey("CampaignId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Campaign");
                });

            modelBuilder.Entity("SeasonOfGhosts.Core.Characters.CharacterLog", b =>
                {
                    b.HasOne("SeasonOfGhosts.Core.Characters.Character", "Character")
                        .WithMany("Log")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Character");
                });

            modelBuilder.Entity("SeasonOfGhosts.Core.Factions.Faction", b =>
                {
                    b.HasOne("SeasonOfGhosts.Core.Campaigns.Campaign", "Campaign")
                        .WithMany("Factions")
                        .HasForeignKey("CampaignId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Campaign");
                });

            modelBuilder.Entity("SeasonOfGhosts.Core.Factions.FactionLog", b =>
                {
                    b.HasOne("SeasonOfGhosts.Core.Factions.Faction", "Faction")
                        .WithMany("Log")
                        .HasForeignKey("FactionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Faction");
                });

            modelBuilder.Entity("SeasonOfGhosts.Core.Settlements.Settlement", b =>
                {
                    b.HasOne("SeasonOfGhosts.Core.Campaigns.Campaign", "Campaign")
                        .WithMany("Settlements")
                        .HasForeignKey("CampaignId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Campaign");
                });

            modelBuilder.Entity("SeasonOfGhosts.Core.Settlements.SettlementLog", b =>
                {
                    b.HasOne("SeasonOfGhosts.Core.Settlements.Settlement", "Settlement")
                        .WithMany("Log")
                        .HasForeignKey("SettlementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Settlement");
                });

            modelBuilder.Entity("SeasonOfGhosts.Core.Stats.Stat", b =>
                {
                    b.HasOne("SeasonOfGhosts.Core.Campaigns.Campaign", "Campaign")
                        .WithMany("Stats")
                        .HasForeignKey("CampaignId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Campaign");
                });

            modelBuilder.Entity("SeasonOfGhosts.Core.Stats.StatLog", b =>
                {
                    b.HasOne("SeasonOfGhosts.Core.Stats.Stat", "Stat")
                        .WithMany("Log")
                        .HasForeignKey("StatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Stat");
                });

            modelBuilder.Entity("SeasonOfGhosts.Core.Campaigns.Campaign", b =>
                {
                    b.Navigation("Characters");

                    b.Navigation("Factions");

                    b.Navigation("Settlements");

                    b.Navigation("Stats");
                });

            modelBuilder.Entity("SeasonOfGhosts.Core.Characters.Character", b =>
                {
                    b.Navigation("Log");
                });

            modelBuilder.Entity("SeasonOfGhosts.Core.Factions.Faction", b =>
                {
                    b.Navigation("Log");
                });

            modelBuilder.Entity("SeasonOfGhosts.Core.Settlements.Settlement", b =>
                {
                    b.Navigation("Log");
                });

            modelBuilder.Entity("SeasonOfGhosts.Core.Stats.Stat", b =>
                {
                    b.Navigation("Log");
                });
#pragma warning restore 612, 618
        }
    }
}
