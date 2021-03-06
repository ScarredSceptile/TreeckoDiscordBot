// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TreeckoV2.Models;

namespace TreeckoV2.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210429193446_TempAddOldPokemon")]
    partial class TempAddOldPokemon
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.5");

            modelBuilder.Entity("TreeckoV2.Models.DiscordGuild", b =>
                {
                    b.Property<ulong>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Prefix")
                        .HasMaxLength(3)
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Guilds");
                });

            modelBuilder.Entity("TreeckoV2.Models.OldPokemon", b =>
                {
                    b.Property<int>("DexNr")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Atk")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Classification")
                        .HasColumnType("TEXT");

                    b.Property<int>("Def")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int>("HP")
                        .HasColumnType("INTEGER");

                    b.Property<float>("Height")
                        .HasColumnType("REAL");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Pic")
                        .HasColumnType("TEXT");

                    b.Property<string>("PicShiny")
                        .HasColumnType("TEXT");

                    b.Property<int>("SpAtk")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SpDef")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Spd")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Type")
                        .HasColumnType("TEXT");

                    b.Property<float>("Weight")
                        .HasColumnType("REAL");

                    b.Property<string>("japName")
                        .HasColumnType("TEXT");

                    b.HasKey("DexNr");

                    b.ToTable("OldPokemon");
                });

            modelBuilder.Entity("TreeckoV2.Models.PokedexEntry", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Game")
                        .HasColumnType("TEXT");

                    b.Property<int>("PokemonNr")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("PokemonNr");

                    b.ToTable("PokedexEntry");
                });

            modelBuilder.Entity("TreeckoV2.Models.Pokemon", b =>
                {
                    b.Property<int>("DexNr")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Classification")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Height")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Pic")
                        .HasColumnType("TEXT");

                    b.Property<string>("PicShiny")
                        .HasColumnType("TEXT");

                    b.Property<string>("Type")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Weight")
                        .HasColumnType("TEXT");

                    b.Property<string>("japName")
                        .HasColumnType("TEXT");

                    b.HasKey("DexNr");

                    b.ToTable("Pokemon");
                });

            modelBuilder.Entity("TreeckoV2.Models.PokemonAbilities", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Effect")
                        .HasColumnType("TEXT");

                    b.Property<string>("JapaneseName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Abilities");
                });

            modelBuilder.Entity("TreeckoV2.Models.PokemonMoveRelationEggMove", b =>
                {
                    b.Property<string>("Games")
                        .HasColumnType("TEXT");

                    b.Property<int>("MoveId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PokemonNr")
                        .HasColumnType("INTEGER");

                    b.HasIndex("MoveId");

                    b.HasIndex("PokemonNr");

                    b.ToTable("EggMoves");
                });

            modelBuilder.Entity("TreeckoV2.Models.PokemonMoveRelationLevelUp", b =>
                {
                    b.Property<string>("Games")
                        .HasColumnType("TEXT");

                    b.Property<int>("Level")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MoveId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PokemonNr")
                        .HasColumnType("INTEGER");

                    b.HasIndex("MoveId");

                    b.HasIndex("PokemonNr");

                    b.ToTable("LevelUpMoves");
                });

            modelBuilder.Entity("TreeckoV2.Models.PokemonMoveRelationTMHM", b =>
                {
                    b.Property<string>("Games")
                        .HasColumnType("TEXT");

                    b.Property<int>("MoveId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PokemonNr")
                        .HasColumnType("INTEGER");

                    b.HasIndex("MoveId");

                    b.HasIndex("PokemonNr");

                    b.ToTable("TMHMMoves");
                });

            modelBuilder.Entity("TreeckoV2.Models.PokemonMoveRelationTutor", b =>
                {
                    b.Property<string>("Games")
                        .HasColumnType("TEXT");

                    b.Property<int>("MoveId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PokemonNr")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Price")
                        .HasColumnType("INTEGER");

                    b.HasIndex("MoveId");

                    b.HasIndex("PokemonNr");

                    b.ToTable("TutorMoves");
                });

            modelBuilder.Entity("TreeckoV2.Models.PokemonMoves", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Accuracy")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int?>("Power")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PowerPoints")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecondaryEffect")
                        .HasColumnType("TEXT");

                    b.Property<int?>("SecondaryEffectRate")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.ToTable("Moves");
                });

            modelBuilder.Entity("TreeckoV2.Models.PokemonStats", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Attack")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Defense")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Generation")
                        .HasColumnType("TEXT");

                    b.Property<int>("HP")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PokemonNr")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Special_Attack")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Special_Defense")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Speed")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("PokemonNr");

                    b.ToTable("Stats");
                });

            modelBuilder.Entity("TreeckoV2.Models.PokedexEntry", b =>
                {
                    b.HasOne("TreeckoV2.Models.Pokemon", "Pokemon")
                        .WithMany()
                        .HasForeignKey("PokemonNr")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pokemon");
                });

            modelBuilder.Entity("TreeckoV2.Models.PokemonMoveRelationEggMove", b =>
                {
                    b.HasOne("TreeckoV2.Models.PokemonMoves", "Move")
                        .WithMany()
                        .HasForeignKey("MoveId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TreeckoV2.Models.Pokemon", "Pokemon")
                        .WithMany()
                        .HasForeignKey("PokemonNr")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Move");

                    b.Navigation("Pokemon");
                });

            modelBuilder.Entity("TreeckoV2.Models.PokemonMoveRelationLevelUp", b =>
                {
                    b.HasOne("TreeckoV2.Models.PokemonMoves", "Move")
                        .WithMany()
                        .HasForeignKey("MoveId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TreeckoV2.Models.Pokemon", "Pokemon")
                        .WithMany()
                        .HasForeignKey("PokemonNr")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Move");

                    b.Navigation("Pokemon");
                });

            modelBuilder.Entity("TreeckoV2.Models.PokemonMoveRelationTMHM", b =>
                {
                    b.HasOne("TreeckoV2.Models.PokemonMoves", "Move")
                        .WithMany()
                        .HasForeignKey("MoveId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TreeckoV2.Models.Pokemon", "Pokemon")
                        .WithMany()
                        .HasForeignKey("PokemonNr")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Move");

                    b.Navigation("Pokemon");
                });

            modelBuilder.Entity("TreeckoV2.Models.PokemonMoveRelationTutor", b =>
                {
                    b.HasOne("TreeckoV2.Models.PokemonMoves", "Move")
                        .WithMany()
                        .HasForeignKey("MoveId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TreeckoV2.Models.Pokemon", "Pokemon")
                        .WithMany()
                        .HasForeignKey("PokemonNr")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Move");

                    b.Navigation("Pokemon");
                });

            modelBuilder.Entity("TreeckoV2.Models.PokemonStats", b =>
                {
                    b.HasOne("TreeckoV2.Models.Pokemon", "Pokemon")
                        .WithMany()
                        .HasForeignKey("PokemonNr")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pokemon");
                });
#pragma warning restore 612, 618
        }
    }
}
