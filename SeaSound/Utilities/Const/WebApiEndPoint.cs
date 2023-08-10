namespace SeaSound.Utilities.Const
{
    public static class WebApiEndPoint
    {
        private const string AreaName = "api";

        public static class Song
        {
            private const string BaseEndpoint = "~/" + AreaName + "/Song";
            public const string GetAllSongs = BaseEndpoint + "/get-all";
            public const string SearchSongs = BaseEndpoint + "/search";
            public const string CreateSong = BaseEndpoint + "/create";
            public const string UpdateSong = BaseEndpoint + "/update";
            public const string DeleteSong = BaseEndpoint + "/delete";
        }

        public static class Album
        {
            private const string BaseEndpoint = "~/" + AreaName + "/Album";
            public const string GetAllAlbums = BaseEndpoint + "/get-all";
            public const string SearchAlbums = BaseEndpoint + "/search";
            public const string CreateAlbum = BaseEndpoint + "/create";
            public const string UpdateAlbum = BaseEndpoint + "/update";
            public const string DeleteAlbum = BaseEndpoint + "/delete";
        }
    }
}
