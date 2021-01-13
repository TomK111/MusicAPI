using Microsoft.EntityFrameworkCore;
using MyMusic.Core.Models;
using MyMusic.Data.Configuration;
using System;

namespace MyMusic.Data
{
    public class MyDbContext : DbContext
    {
        public DbSet<Music> Musics { get; set; }
        public DbSet<Artist> Artists { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .ApplyConfiguration(new MusicConfiguration());

            builder
                .ApplyConfiguration(new ArtistConfiguration());
        }
    }
}
