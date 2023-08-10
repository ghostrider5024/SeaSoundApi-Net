using Microsoft.EntityFrameworkCore;
using SeaSound.Repository.IRepository;
using SeaSound.Repository.Model;
using System.Linq.Expressions;

namespace SeaSound.Repository
{
    public class SongAlbumRepository : BaseRepository<SongAlbum>, ISongAlbumRepository
    {
        public async Task<SongAlbum?> AddObjectAsync(SongAlbum obj)
        {
            obj.DeleteDate = null;
            return await AddAsync(obj);
        }

        public async Task<SongAlbum?> DeleteObjectSync(params object[] id)
        {
            var obj = await GetByIdAsync(id);
            if (obj == null)
                return null;

            obj.DeleteDate = DateTimeOffset.Now;
            await UpdateObjectAsync(obj);
            return obj;
        }

        public async Task<List<SongAlbum>> GetAllObjectAsync(int pageNumber = -1, int pageSize = -1)
        {
            //var temp = await GetAllAsync().Result.Where(t => t.DeleteDate == null)
            //        .Include(t=>t.SongArtists).Include(t=>t.SongPlaylists).Include(t=>t.SongAlbums).ToListAsync();
            if (pageNumber > -1 && pageSize > -1)
                return await GetAllAsync().Result.Where(t => t.DeleteDate == null)
                    .Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            else
                return await GetAllAsync().Result.Where(t => t.DeleteDate == null).ToListAsync();
        }

        public Task<SongAlbum?> GetObjectAsync(params object[] id)
        {
            throw new NotImplementedException();
        }

        public Task<List<SongAlbum>> SearchObjectAsync(Expression<Func<SongAlbum, bool>> predicate = null, int pageNumber = -1, int pageSize = -1)
        {
            throw new NotImplementedException();
        }

        public async Task<SongAlbum?> UpdateObjectAsync(SongAlbum obj)
        {
            return await UpdateAsync(obj);
        }
    }
}
