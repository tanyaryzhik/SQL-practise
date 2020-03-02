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

            //MovieDirection model
            modelBuilder.Entity<MovieDirection>()
               .Property(m => m.MovieId)
               .HasColumnName("mov_id");
            modelBuilder.Entity<MovieDirection>()
                .Property(m => m.DirectorId)
                .HasColumnName("dir_id");

            //MovieCast model
            modelBuilder.Entity<MovieCast>()
               .Property(m => m.MovieId)
               .HasColumnName("mov_id");
            modelBuilder.Entity<MovieCast>()
                .Property(m => m.ActorId)
                .HasColumnName("act_id");
            modelBuilder.Entity<MovieCast>()
               .Property(m => m.Role)
               .HasColumnName("role")
               .HasMaxLength(30);

            //MovieGenre model
            modelBuilder.Entity<MovieGenre>()
               .Property(m => m.MovieId)
               .HasColumnName("mov_id");
            modelBuilder.Entity<MovieGenre>()
                .Property(m => m.GenreId)
                .HasColumnName("gen_id");

            //Rating model
            modelBuilder.Entity<Rating>()
               .Property(r => r.MovieId)
               .HasColumnName("mov_id");
            modelBuilder.Entity<Rating>()
                .Property(r => r.ReviewerId)
                .HasColumnName("rev_id");
            modelBuilder.Entity<Rating>()
                .Property(r => r.ReviewStars)
                .HasColumnName("rev_stars");
            modelBuilder.Entity<Rating>()
                .Property(r => r.NumberOfReviews)
                .HasColumnName("num_of_rev");

            //Many to many.
            modelBuilder.Entity<MovieGenre>().HasKey(mv => new { mv.MovieId, mv.GenreId });

            modelBuilder.Entity<MovieCast>().HasKey(mc => new { mc.MovieId, mc.ActorId });

            modelBuilder.Entity<MovieDirection>().HasKey(md => new { md.MovieId, md.DirectorId });

            modelBuilder.Entity<Rating>().HasKey(r => new { r.MovieId, r.ReviewerId });

            //One to many.
            modelBuilder.Entity<MovieDirection>().HasOne(md => md.Director)
                .WithMany(d => d.MovieDirections)
                .HasForeignKey(md => md.DirectorId);
        }
    }
}