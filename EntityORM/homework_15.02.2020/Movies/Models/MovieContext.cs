using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movies.Models
{
    public class MovieContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Database=Movies;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Actor model.
            modelBuilder.Entity<Actor>()
                .Property(a => a.ActorId)
                .HasColumnName("act_id")
                .IsRequired();

            modelBuilder.Entity<Actor>()
                .Property(a => a.FirstName)
                .HasColumnName("act_fname")
                .HasMaxLength(20);

            modelBuilder.Entity<Actor>()
                .Property(a => a.LastName)
                .HasColumnName("act_lname")
                .HasMaxLength(20);

            modelBuilder.Entity<Actor>()
                .Property(a => a.Gender)
                .HasColumnName("act_gender")
                .HasMaxLength(1);

            //modelBuilder.Entity<Actor>()
            //    .HasMany<MovieCast>(a => a.MovieCasts)
            //    .WithOne(mc => mc.)

            //Director model.
            modelBuilder.Entity<Director>()
                .Property(d => d.DirectorId)
                .HasColumnName("dir_id")
                .IsRequired();

            modelBuilder.Entity<Director>()
                .Property(d => d.DirFirstName)
                .HasColumnName("dir_fname")
                .HasMaxLength(20);

            modelBuilder.Entity<Director>()
                .Property(d => d.DirLastName)
                .HasColumnName("dir_lname")
                .HasMaxLength(20);

            //Reviewer model.
            modelBuilder.Entity<Reviewer>()
               .Property(r => r.ReviewerId)
               .HasColumnName("rev_id")
               .IsRequired();

            modelBuilder.Entity<Reviewer>()
                .Property(r => r.ReviewerName)
                .HasColumnName("rev_name")
                .HasMaxLength(30);

            //Genre model.
            modelBuilder.Entity<Genre>()
               .Property(g => g.GenreId)
               .HasColumnName("gen_id")
               .IsRequired();

            modelBuilder.Entity<Genre>()
                .Property(g => g.GenreTitle)
                .HasColumnName("gen_title")
                .HasMaxLength(20);

            //Movie model.
            modelBuilder.Entity<Movie>()
                .Property(m => m.MovieId)
                .HasColumnName("mov_id")
                .IsRequired();
            modelBuilder.Entity<Movie>()
                .Property(m => m.MovieTitle)
                .HasColumnName("mov_title")
                .HasMaxLength(50);
            modelBuilder.Entity<Movie>()
                .Property(m => m.Time)
                .HasColumnName("mov_time");
            modelBuilder.Entity<Movie>()
                .Property(m => m.Year)
                .HasColumnName("mov_year");
            modelBuilder.Entity<Movie>()
                .Property(m => m.Language)
                .HasColumnName("mov_lang")
                .HasMaxLength(50);
            modelBuilder.Entity<Movie>()
                .Property(m => m.DateOfRelease)
                .HasColumnName("mov_dt_rel");
            modelBuilder.Entity<Movie>()
                .Property(m => m.CountryOfRelease)
                .HasColumnName("mov_rel_country")
                .HasMaxLength(5);
        }
    }
}
