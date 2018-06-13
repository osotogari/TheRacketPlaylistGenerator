using System.Collections.Generic;

namespace TheRacketPlaylistGenerator.Models
{

    public partial class PlaylistSearchResult
    {
        public long Total { get; set; }
        public long Offset { get; set; }
        public List<Item> Items { get; set; }
        public string StartTimeHour { get; set; }
        public string StartTimeMinute { get; set; }
        public string EndTimeHour { get; set; }
        public string EndTimeMinute { get; set; }
        public string SelectedShowTime { get; set; }

        public Dictionary<string, string> ShowTimes { get; set; }
    }

    public partial class Item
    {
        public string Entity { get; set; }
        public string Arid { get; set; }
        public string PlayedTime { get; set; }
        public string ServiceId { get; set; }
        public Recording Recording { get; set; }
    }

    public partial class Recording
    {
        public string Entity { get; set; }
        public string Arid { get; set; }
        public string Title { get; set; }
        public long Duration { get; set; }
        public List<Artist> Artists { get; set; }
        public List<Release> Releases { get; set; }
        public List<object> Artwork { get; set; }
        public List<Link> Links { get; set; }
    }

    public partial class Artist
    {
        public string Entity { get; set; }
        public string Arid { get; set; }
        public string Name { get; set; }
        public List<Artwork> Artwork { get; set; }
        public List<Link> Links { get; set; }
        public string Type { get; set; }
    }

    public partial class Artwork
    {
        public string Entity { get; set; }
        public string Arid { get; set; }
        public string Url { get; set; }
        public string Type { get; set; }
        public long Width { get; set; }
        public long Height { get; set; }
        public List<Size> Sizes { get; set; }
    }

    public partial class Size
    {
        public string Url { get; set; }
        public long Width { get; set; }
        public long Height { get; set; }
        public string AspectRatio { get; set; }
    }

    public partial class Link
    {
        public string Entity { get; set; }
        public string Arid { get; set; }
        public string Url { get; set; }
        public string IdComponent { get; set; }
        public string ServiceId { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string Provider { get; set; }
        public bool External { get; set; }
    }

    public partial class Release
    {
        public string Entity { get; set; }
        public string Arid { get; set; }
        public string Title { get; set; }
        public string Format { get; set; }
        public List<Artwork> Artwork { get; set; }
        public List<Link> Links { get; set; }
        public List<Artist> Artists { get; set; }
    }
}
