using Microsoft.EntityFrameworkCore;
using SeaSound.Repository.IRepository;
using System.Linq.Expressions;

namespace SeaSound.Repository
{
    public class SongRepository : BaseRepository<Song>, ISongRepository
    {
        public async Task<Song?> AddObjectAsync(Song obj)
        {
            obj.DeleteDate = null;
            return await AddAsync(obj);
        }

        public async Task<Song?> DeleteObjectSync(params object[] id)
        {
            var obj = await GetByIdAsync(id);
            if (obj == null)
                return null;
        
            obj.DeleteDate = DateTimeOffset.Now;
            await UpdateObjectAsync(obj);
            return obj;
        }

        public async Task<List<Song>> GetAllObjectAsync(int pageNumber = -1, int pageSize = -1)
        {
            if (pageNumber > -1 && pageSize > -1)
                return await GetAllAsync().Result.Where(t => t.DeleteDate == null)
                    .Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            else
                return await GetAllAsync().Result.Where(t => t.DeleteDate == null).ToListAsync();
        }

        public Task<Song?> GetObjectAsync(params object[] id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Song>> SearchObjectAsync(Expression<Func<Song, bool>> predicate = null, int pageNumber = -1, int pageSize = -1)
        {
            throw new NotImplementedException();
        }

        public async Task<Song?> UpdateObjectAsync(Song obj)
        {
            return await UpdateAsync(obj);
        }
    }
}
