namespace LinqConsoleApp.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EkstraklasaContext : DbContext
    {
        public EkstraklasaContext()
            : base("name=EkstraklasaContext")
        {
        }

        public virtual DbSet<Fanklub> Fanklub { get; set; }
        public virtual DbSet<Klub> Klub { get; set; }
        public virtual DbSet<Mecz> Mecz { get; set; }
        public virtual DbSet<Stadion> Stadion { get; set; }
        public virtual DbSet<Trener> Trener { get; set; }
        public virtual DbSet<Zawodnik> Zawodnik { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Fanklub>()
                .Property(e => e.Nazwa)
                .IsUnicode(false);

            modelBuilder.Entity<Klub>()
                .Property(e => e.Nazwa)
                .IsUnicode(false);

            modelBuilder.Entity<Klub>()
                .Property(e => e.Budzet_roczny)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Klub>()
                .HasMany(e => e.Fanklub)
                .WithOptional(e => e.Klub)
                .HasForeignKey(e => e.ID_Klub);

            modelBuilder.Entity<Klub>()
                .HasMany(e => e.Mecz)
                .WithRequired(e => e.Klub)
                .HasForeignKey(e => e.ID_Gosc)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Klub>()
                .HasMany(e => e.Mecz1)
                .WithRequired(e => e.Klub1)
                .HasForeignKey(e => e.ID_Gospodarz)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Klub>()
                .HasMany(e => e.Stadion)
                .WithOptional(e => e.Klub)
                .HasForeignKey(e => e.ID_Klub);

            modelBuilder.Entity<Klub>()
                .HasMany(e => e.Zawodnik)
                .WithOptional(e => e.Klub)
                .HasForeignKey(e => e.ID_Klub);

            modelBuilder.Entity<Mecz>()
                .Property(e => e.Wynik)
                .IsUnicode(false);

            modelBuilder.Entity<Stadion>()
                .Property(e => e.Nazwa)
                .IsUnicode(false);

            modelBuilder.Entity<Stadion>()
                .Property(e => e.Adres)
                .IsUnicode(false);

            modelBuilder.Entity<Trener>()
                .Property(e => e.Imie)
                .IsUnicode(false);

            modelBuilder.Entity<Trener>()
                .Property(e => e.Nazwisko)
                .IsUnicode(false);

            modelBuilder.Entity<Trener>()
                .HasMany(e => e.Klub)
                .WithRequired(e => e.Trener)
                .HasForeignKey(e => e.ID_Trener)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Zawodnik>()
                .Property(e => e.Imie)
                .IsUnicode(false);

            modelBuilder.Entity<Zawodnik>()
                .Property(e => e.Nazwisko)
                .IsUnicode(false);

            modelBuilder.Entity<Zawodnik>()
                .Property(e => e.Pozycja)
                .IsUnicode(false);

            modelBuilder.Entity<Zawodnik>()
                .Property(e => e.Pensja_roczna)
                .HasPrecision(19, 4);
        }
    }
}
