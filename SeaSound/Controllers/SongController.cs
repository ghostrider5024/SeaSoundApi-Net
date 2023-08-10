using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SeaSound.Repository.Model;
using SeaSound.Service.IService;
using SeaSound.Service.Model;
using SeaSound.Utilities;
using SeaSound.Utilities.Const;

namespace SeaSound.Controllers
{
    [ApiController]
    public class SongController : ControllerBase
    {
        private readonly ISongService _songService;
        private readonly IMapper _mapper;

        public SongController(ISongService songService, IMapper mapper)
        {
            _songService = songService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route(WebApiEndPoint.Song.GetAllSongs)]

        public async Task<IActionResult> GetAllSongs(int pageNumber = -1, int pageSize = -1)
        {
            var result = await _songService.GetAllObjectAsync(pageNumber, pageSize);
            return Ok(new ReturnResponse<List<SongResponse>>(_mapper.Map<List<SongResponse>>(result)));
        }
        
        //[HttpGet("songs")]
        //public async Task<IActionResult> GetSong(int pageNumber = -1, int pageSize = -1)
        //{
        //    var result = await _songService.GetAllObjectAsync(pageNumber, pageSize);
        //    return Ok(new ReturnResponse<List<SongResponse>>(_mapper.Map<List<SongResponse>>(result)));
        //}

        [HttpPost]
        [Route(WebApiEndPoint.Song.CreateSong)]
        public async Task<IActionResult> CreateSong(SongResponse song)
        {
            var result = await _songService.AddObjectAsync(_mapper.Map<Song>(song));
            return Ok(new ReturnResponse<SongResponse>(_mapper.Map<SongResponse>(result)));
        }

        [HttpPut]
        [Route(WebApiEndPoint.Song.UpdateSong)]
        public async Task<IActionResult> UpdateSong(string id, SongResponse song)
        {
            song.Id = id;
            var result = await _songService.UpdateObjectAsync(_mapper.Map<Song>(song));
            return Ok(new ReturnResponse<SongResponse>(_mapper.Map<SongResponse>(result)));
        }

        [HttpDelete]
        [Route(WebApiEndPoint.Song.DeleteSong)]
        public async Task<IActionResult> DeleteSong(string id)
        {
            var result = await _songService.DeleteObjectSync(id);
            return Ok(new ReturnResponse<SongResponse>(_mapper.Map<SongResponse>(result)));
        }
    }
}
