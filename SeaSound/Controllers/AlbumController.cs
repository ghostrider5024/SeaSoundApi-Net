using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SeaSound.Repository.Model;
using SeaSound.Service.IService;
using SeaSound.Service.Model.Album;
using SeaSound.Utilities;
using SeaSound.Utilities.Const;

namespace SeaSound.Controllers
{
    [ApiController]
    public class AlbumController : ControllerBase
    {
        private readonly IAlbumService _albumService;
        private readonly IMapper _mapper;

        public AlbumController(IAlbumService albumService, IMapper mapper)
        {
            _albumService = albumService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route(WebApiEndPoint.Album.GetAllAlbums)]

        public async Task<IActionResult> GetAllAlbums(int pageNumber = -1, int pageSize = -1)
        {
            var result = await _albumService.GetAllObjectAsync(pageNumber, pageSize);
            return Ok(new ReturnResponse<List<AlbumResponse>>(_mapper.Map<List<AlbumResponse>>(result)));
        }

        //[HttpGet("Albums")]
        //public async Task<IActionResult> GetAlbum(int pageNumber = -1, int pageSize = -1)
        //{
        //    var result = await _AlbumService.GetAllObjectAsync(pageNumber, pageSize);
        //    return Ok(new ReturnResponse<List<AlbumResponse>>(_mapper.Map<List<AlbumResponse>>(result)));
        //}

        [HttpPost]
        [Route(WebApiEndPoint.Album.CreateAlbum)]
        public async Task<IActionResult> CreateAlbum(AlbumResponse Album)
        {
            var result = await _albumService.AddObjectAsync(_mapper.Map<Album>(Album));
            return Ok(new ReturnResponse<AlbumResponse>(_mapper.Map<AlbumResponse>(result)));
        }

        [HttpPut]
        [Route(WebApiEndPoint.Album.UpdateAlbum)]
        public async Task<IActionResult> UpdateAlbum(string id, AlbumResponse Album)
        {
            Album.Id = id;
            var result = await _albumService.UpdateObjectAsync(_mapper.Map<Album>(Album));
            return Ok(new ReturnResponse<AlbumResponse>(_mapper.Map<AlbumResponse>(result)));
        }

        [HttpDelete]
        [Route(WebApiEndPoint.Album.DeleteAlbum)]
        public async Task<IActionResult> DeleteAlbum(string id)
        {
            var result = await _albumService.DeleteObjectSync(id);
            return Ok(new ReturnResponse<AlbumResponse>(_mapper.Map<AlbumResponse>(result)));
        }
    }
}
