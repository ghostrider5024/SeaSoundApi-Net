using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SeaSound.Repository.Model;
using SeaSound.Service.IService;
using SeaSound.Service.Model.SongAlbum;
using SeaSound.Utilities;
using SeaSound.Utilities.Const;

namespace SeaSound.Controllers
{
    [ApiController]
    public class SongAlbumController : ControllerBase
    {
        private readonly ISongAlbumService _SongAlbumService;
        private readonly IMapper _mapper;

        public SongAlbumController(ISongAlbumService SongAlbumService, IMapper mapper)
        {
            _SongAlbumService = SongAlbumService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route(WebApiEndPoint.SongAlbum.GetAllSongAlbums)]

        public async Task<IActionResult> GetAllSongAlbums(int pageNumber = -1, int pageSize = -1)
        {
            var result = await _SongAlbumService.GetAllObjectAsync(pageNumber, pageSize);
            return Ok(new ReturnResponse<List<SongAlbumResponse>>(_mapper.Map<List<SongAlbumResponse>>(result)));
        }

        //[HttpGet("SongAlbums")]
        //public async Task<IActionResult> GetSongAlbum(int pageNumber = -1, int pageSize = -1)
        //{
        //    var result = await _SongAlbumService.GetAllObjectAsync(pageNumber, pageSize);
        //    return Ok(new ReturnResponse<List<SongAlbumResponse>>(_mapper.Map<List<SongAlbumResponse>>(result)));
        //}

        [HttpPost]
        [Route(WebApiEndPoint.SongAlbum.CreateSongAlbum)]
        public async Task<IActionResult> CreateSongAlbum(SongAlbumResponse SongAlbum)
        {
            var result = await _SongAlbumService.AddObjectAsync(_mapper.Map<SongAlbum>(SongAlbum));
            return Ok(new ReturnResponse<SongAlbumResponse>(_mapper.Map<SongAlbumResponse>(result)));
        }

        [HttpPut]
        [Route(WebApiEndPoint.SongAlbum.UpdateSongAlbum)]
        public async Task<IActionResult> UpdateSongAlbum(string albumId, string songId, SongAlbumResponse SongAlbum)
        {
            SongAlbum.AlbumId = albumId;
            SongAlbum.SongId = songId;
            var result = await _SongAlbumService.UpdateObjectAsync(_mapper.Map<SongAlbum>(SongAlbum));
            return Ok(new ReturnResponse<SongAlbumResponse>(_mapper.Map<SongAlbumResponse>(result)));
        }

        [HttpDelete]
        [Route(WebApiEndPoint.SongAlbum.DeleteSongAlbum)]
        public async Task<IActionResult> DeleteSongAlbum(string albumId, string songId)
        {
            var result = await _SongAlbumService.DeleteObjectSync(albumId, songId);
            return Ok(new ReturnResponse<SongAlbumResponse>(_mapper.Map<SongAlbumResponse>(result)));
        }
    }
}
