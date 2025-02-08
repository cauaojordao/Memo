namespace Memo.Models
{
    public class Music
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string Link { get; set; } = string.Empty;
        public int PlaylistId { get; set; }
        public virtual Playlist Playlist { get; set; } = null!;
    }
}
