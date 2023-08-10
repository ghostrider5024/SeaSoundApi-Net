using Microsoft.EntityFrameworkCore;
using SeaSound.Repository.IRepository;
using SeaSound.Repository.Model;
using System.Linq.Expressions;

namespace SeaSound.Repository
{
    public class AlbumRepository : BaseRepository<Album>, IAlbumRepository
    {
        public async Task<Album?> AddObjectAsync(Album obj)
        {
            obj.DeleteDate = null;
            return await AddAsync(obj);
        }

        public async Task<Album?> DeleteObjectSync(params object[] id)
        {
            var obj = await GetByIdAsync(id);
            if (obj == null)
                return null;

            obj.DeleteDate = DateTimeOffset.Now;
            await UpdateObjectAsync(obj);
            return obj;
        }

        public async Task<List<Album>> GetAllObjectAsync(int pageNumber = -1, int pageSize = -1)
        {
            if (pageNumber > -1 && pageSize > -1)
                return await GetAllAsync().Result.Where(t => t.DeleteDate == null)
                    .Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            else
                return await GetAllAsync().Result.Where(t => t.DeleteDate == null).ToListAsync();
        }

        public Task<Album?> GetObjectAsync(params object[] id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Album>> SearchObjectAsync(Expression<Func<Album, bool>> predicate = null, int pageNumber = -1, int pageSize = -1)
        {
            throw new NotImplementedException();
        }

        public async Task<Album?> UpdateObjectAsync(Album obj)
        {
            return await UpdateAsync(obj);
        }
    }
}
