using AutoMapper;
using SeaSound.Repository.IRepository;
using SeaSound.Repository.Model;
using SeaSound.Service.IService;
using System.Linq.Expressions;

namespace SeaSound.Service
{
    public class AlbumService : IAlbumService
    {
        private readonly IMapper _mapper;
        private readonly IAlbumRepository _AlbumRepository;

        public AlbumService(IMapper mapper, IAlbumRepository AlbumRepository)
        {
            _mapper = mapper;
            _AlbumRepository = AlbumRepository;
        }

        public async Task<Album?> AddObjectAsync(Album obj)
        {
            return await _AlbumRepository.AddObjectAsync(obj);
        }

        public async Task<Album?> DeleteObjectSync(params object[] id)
        {
            return await _AlbumRepository.DeleteObjectSync(id);
        }

        public async Task<List<Album>> GetAllObjectAsync(int pageNumber = -1, int pageSize = -1)
        {
            return await _AlbumRepository.GetAllObjectAsync(pageNumber, pageSize);
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
            return await _AlbumRepository.UpdateObjectAsync(obj);
        }
    }
}
