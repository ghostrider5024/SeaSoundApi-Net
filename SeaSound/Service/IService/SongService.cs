using AutoMapper;
using SeaSound.Repository;
using SeaSound.Repository.IRepository;
using System.Linq.Expressions;

namespace SeaSound.Service.IService
{
    public class SongService : ISongService
    {
        private readonly IMapper _mapper;
        private readonly ISongRepository _songRepository;

        public SongService(IMapper mapper, ISongRepository songRepository)
        {
            _mapper = mapper;
            _songRepository = songRepository;
        }

        public async Task<Song?> AddObjectAsync(Song obj)
        {
            return await _songRepository.AddObjectAsync(obj);
        }

        public async Task<Song?> DeleteObjectSync(params object[] id)
        {
            return await _songRepository.DeleteObjectSync(id);
        }

        public async Task<List<Song>> GetAllObjectAsync(int pageNumber = -1, int pageSize = -1)
        {
            return await _songRepository.GetAllObjectAsync(pageNumber, pageSize);
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
            return await _songRepository.UpdateObjectAsync(obj);
        }
    }
}
