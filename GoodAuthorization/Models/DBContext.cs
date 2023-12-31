﻿using Microsoft.EntityFrameworkCore;


namespace qwewr.Models
{
    public partial class DBContext : DbContext
    {
        public DBContext()
        {
        }

        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {
        }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlServer("Data Source=DESKTOP-QFRCAHK;" +
				"Initial Catalog=badDataBase;" +
				"Integrated Security=True;");
			}
		}

		public virtual DbSet<Caphatable2> Caphatable2 { get; set; }
        public virtual DbSet<KapchaTable> KapchaTable { get; set; }
        public virtual DbSet<UserTable> UserTable { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Caphatable2>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("caphatable2");

                entity.Property(e => e.KapchaText)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .HasColumnName("kapchaText")
                    .IsFixedLength();
            });

            modelBuilder.Entity<KapchaTable>(entity =>
            {   
                entity.HasNoKey();

                entity.ToTable("kapchaTable");

                entity.Property(e => e.Capcha)
                    .IsRequired()
                    .HasColumnName("capcha");

                entity.Property(e => e.Text)
                    .HasMaxLength(10)
                    .HasColumnName("text")
                    .IsFixedLength();
            });

            modelBuilder.Entity<UserTable>(entity =>
            {
				entity.HasKey(e => e.Logun);

				entity.ToTable("user_table");

                entity.Property(e => e.Logun)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("logun")
                    .IsFixedLength();

                entity.Property(e => e.Parol)
                    .HasMaxLength(4000)
                    .HasColumnName("parol")
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}