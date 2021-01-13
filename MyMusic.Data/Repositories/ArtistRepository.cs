using Microsoft.EntityFrameworkCore;
using MyMusic.Core.Models;
using MyMusic.Core.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyMusic.Data.Repositories
{
   public class ArtistRepository:Repository<Artist>, IArtistRepository
    {
        private MyDbContext MyDbContext
        {
            get { return Context as MyDbContext; }
        }

        public ArtistRepository(MyDbContext context)
            : base(context)
        { }

        public async Task<IEnumerable<Artist>> GetAllWithMusicAsync()
        {
            return await MyDbContext.Artists
                .Include(a => a.Musics)
                .ToListAsync();
        }

        public Task<Artist> GetAllWithMusicsAsync(int id)
        {
            return MyDbContext.Artists
                .Include(a => a.Musics)
                .SingleOrDefaultAsync(a => a.Id == id);
        }

        async Task<IEnumerable<Artist>> IArtistRepository.GetAllWithMusicsAsync()
        {
            return await MyDbContext.Artists
                .Include(a => a.Musics)
                .ToListAsync();
        }
       
        Task<Artist> IArtistRepository.GetWithMusicsByIdAsync(int id)
        {
            return MyDbContext.Artists
                .Include(a => a.Musics)
                .SingleOrDefaultAsync(a => a.Id == id);
        }

    }
}
