namespace Memo.Models
{
    internal class PlaylistViewModel
    {
        public Playlist Playlist { get; set; } = new Playlist();
        public List<Playlist> Playlists { get; set; } = new List<Playlist>();

        public Music Music { get; set; } = new Music();
    }
}