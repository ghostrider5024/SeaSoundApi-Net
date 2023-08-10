using AutoMapper;
using SeaSound.Repository.IRepository;
using SeaSound.Repository.Model;
using SeaSound.Service.IService;
using System.Linq.Expressions;

namespace SeaSound.Service
{
    public class SongAlbumService : ISongAlbumService
    {
        private readonly IMapper _mapper;
        private readonly ISongAlbumRepository _SongAlbumRepository;

        public SongAlbumService(IMapper mapper, ISongAlbumRepository SongAlbumRepository)
        {
            _mapper = mapper;
            _SongAlbumRepository = SongAlbumRepository;
        }

        public async Task<SongAlbum?> AddObjectAsync(SongAlbum obj)
        {
            return await _SongAlbumRepository.AddObjectAsync(obj);
        }

        public async Task<SongAlbum?> DeleteObjectSync(params object[] id)
        {
            return await _SongAlbumRepository.DeleteObjectSync(id);
        }

        public async Task<List<SongAlbum>> GetAllObjectAsync(int pageNumber = -1, int pageSize = -1)
        {
            return await _SongAlbumRepository.GetAllObjectAsync(pageNumber, pageSize);
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
            return await _SongAlbumRepository.UpdateObjectAsync(obj);
        }
    }
}
