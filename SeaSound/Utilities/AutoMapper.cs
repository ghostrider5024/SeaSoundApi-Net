using AutoMapper;
using SeaSound.Repository.Model;
using SeaSound.Service.Model.Album;
using SeaSound.Service.Model.Song;
using SeaSound.Service.Model.SongAlbum;

namespace SeaSound.Utilities
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            MapSong();
            MapAlbum();
            MapSongAlbum();
            //MapArtist();
            //MapSongArtist();
        }

        private void MapSong()
        {
            CreateMap<Song, SongResponse>()
             //.ForMember(dest => dest.Artists, opt => opt.MapFrom(src => src.SongArtists.Select(sc => sc.ArtistId)))
             //.ForMember(dest => dest.Playlists, opt => opt.MapFrom(src => src.SongPlaylists.Select(sc => sc.PlaylistId)))
             .ReverseMap();

        }  
        
        private void MapAlbum()
        {
            CreateMap<Album, AlbumResponse>().ReverseMap();
        }
        private void MapSongAlbum()
        {
            CreateMap<SongAlbum, SongAlbumResponse>().ReverseMap();
        }

        //private void MapArtist()
        //{
        //    CreateMap<Artist, ArtistResponse>().ReverseMap();
        //}

        //private void MapSongArtist()
        //{
        //    CreateMap<SongArtist, SongArtistResponse>().ReverseMap();
        //}
    }
}
