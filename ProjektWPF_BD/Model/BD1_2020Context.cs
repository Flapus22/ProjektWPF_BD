using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ProjektWPF_BD.Model
{
    public partial class BD1_2020Context : DbContext
    {
        public BD1_2020Context()
        {
        }

        public BD1_2020Context(DbContextOptions<BD1_2020Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Dostawcy> Dostawcies { get; set; }
        public virtual DbSet<Kategorie> Kategories { get; set; }
        public virtual DbSet<Klienci> Kliencis { get; set; }
        public virtual DbSet<PozycjeZamówienium> PozycjeZamówienia { get; set; }
        public virtual DbSet<Pracownicy> Pracownicies { get; set; }
        public virtual DbSet<Produkty> Produkties { get; set; }
        public virtual DbSet<Spedytorzy> Spedytorzies { get; set; }

        public virtual DbSet<Zamówienium> Zamówienia { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-IPAEN72;Database=BD1_2020;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Polish_CI_AS");

            modelBuilder.Entity<Dostawcy>(entity =>
            {
                entity.HasKey(e => e.Iddostawcy);

                entity.ToTable("Dostawcy");

                entity.Property(e => e.Iddostawcy)
                    .ValueGeneratedNever()
                    .HasColumnName("IDdostawcy");

                entity.Property(e => e.Adres).HasMaxLength(60);

                entity.Property(e => e.Faks).HasMaxLength(24);

                entity.Property(e => e.KodPocztowy).HasMaxLength(10);

                entity.Property(e => e.Kraj).HasMaxLength(15);

                entity.Property(e => e.Miasto).HasMaxLength(15);

                entity.Property(e => e.NazwaFirmy)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.Przedstawiciel).HasMaxLength(30);

                entity.Property(e => e.Region).HasMaxLength(15);

                entity.Property(e => e.StanowiskoPrzedstawiciela).HasMaxLength(30);

                entity.Property(e => e.Telefon).HasMaxLength(24);
            });

            modelBuilder.Entity<Kategorie>(entity =>
            {
                entity.HasKey(e => e.Idkategorii);

                entity.ToTable("Kategorie");

                entity.Property(e => e.Idkategorii)
                    .ValueGeneratedNever()
                    .HasColumnName("IDkategorii");

                entity.Property(e => e.NazwaKategorii)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Rysunek).HasColumnType("image");
            });

            modelBuilder.Entity<Klienci>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Klienci");

                entity.Property(e => e.Adres).HasMaxLength(60);

                entity.Property(e => e.Faks).HasMaxLength(24);

                entity.Property(e => e.Idklienta)
                    .HasMaxLength(5)
                    .HasColumnName("IDklienta");

                entity.Property(e => e.KodPocztowy).HasMaxLength(10);

                entity.Property(e => e.Kraj).HasMaxLength(15);

                entity.Property(e => e.Miasto).HasMaxLength(15);

                entity.Property(e => e.NazwaFirmy)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.Przedstawiciel).HasMaxLength(30);

                entity.Property(e => e.Region).HasMaxLength(15);

                entity.Property(e => e.StanowiskoPrzedstawiciela).HasMaxLength(35);

                entity.Property(e => e.Telefon).HasMaxLength(24);
            });

            modelBuilder.Entity<PozycjeZamówienium>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.CenaJednostkowa).HasColumnType("money");

                entity.Property(e => e.Idproduktu).HasColumnName("IDproduktu");

                entity.Property(e => e.Idzamówienia).HasColumnName("IDzamówienia");
            });

            modelBuilder.Entity<Pracownicy>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Pracownicy");

                entity.Property(e => e.Adres).HasMaxLength(60);

                entity.Property(e => e.DataUrodzenia).HasColumnType("datetime");

                entity.Property(e => e.DataZatrudnienia).HasColumnType("datetime");

                entity.Property(e => e.Fotografia).HasColumnType("image");

                entity.Property(e => e.Idpracownika).HasColumnName("IDpracownika");

                entity.Property(e => e.Imię)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.KodPocztowy).HasMaxLength(10);

                entity.Property(e => e.Kraj).HasMaxLength(15);

                entity.Property(e => e.Miasto).HasMaxLength(15);

                entity.Property(e => e.Nazwisko)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Region).HasMaxLength(15);

                entity.Property(e => e.Stanowisko).HasMaxLength(40);

                entity.Property(e => e.TelefonDomowy).HasMaxLength(24);

                entity.Property(e => e.TelefonWewnętrzny).HasMaxLength(4);

                entity.Property(e => e.ZwrotGrzecznościowy).HasMaxLength(25);
            });

            modelBuilder.Entity<Produkty>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Produkty");

                entity.Property(e => e.CenaJednostkowa).HasColumnType("money");

                entity.Property(e => e.Iddostawcy).HasColumnName("IDdostawcy");

                entity.Property(e => e.Idkategorii).HasColumnName("IDkategorii");

                entity.Property(e => e.Idproduktu).HasColumnName("IDproduktu");

                entity.Property(e => e.IlośćJednostkowa).HasMaxLength(255);

                entity.Property(e => e.NazwaProduktu)
                    .IsRequired()
                    .HasMaxLength(40);
            });

            modelBuilder.Entity<Spedytorzy>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Spedytorzy");

                entity.Property(e => e.Idspedytora).HasColumnName("IDspedytora");

                entity.Property(e => e.NazwaFirmy)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.Telefon).HasMaxLength(24);
            });

            modelBuilder.Entity<Zamówienium>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.AdresOdbiorcy).HasMaxLength(60);

                entity.Property(e => e.DataWymagana).HasColumnType("datetime");

                entity.Property(e => e.DataWysyłki).HasColumnType("datetime");

                entity.Property(e => e.DataZamówienia).HasColumnType("datetime");

                entity.Property(e => e.Fracht).HasColumnType("money");

                entity.Property(e => e.Idklienta)
                    .IsRequired()
                    .HasMaxLength(5)
                    .HasColumnName("IDklienta");

                entity.Property(e => e.Idpracownika).HasColumnName("IDpracownika");

                entity.Property(e => e.Idspedytora).HasColumnName("IDspedytora");

                entity.Property(e => e.Idzamówienia).HasColumnName("IDzamówienia");

                entity.Property(e => e.KodPocztowyOdbiorcy).HasMaxLength(10);

                entity.Property(e => e.KrajOdbiorcy).HasMaxLength(15);

                entity.Property(e => e.MiastoOdbiorcy).HasMaxLength(15);

                entity.Property(e => e.NazwaOdbiorcy).HasMaxLength(40);

                entity.Property(e => e.RegionOdbiorcy).HasMaxLength(15);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
