using System;
using System.ComponentModel.DataAnnotations;

namespace TheRacketPlaylistGenerator.Models
{
    public class Playlist
    {
        public int Id { get; set; }

        public string AlbumCoverUrl { get; set; }
        public string Artist { get; set; }
        public string SongTitle { get; set; }
        public string AlbumName { get; set; }
        public TimeSpan Duration { get; set; }

        [Required]
        public string ArtistId { get; set; }
        public ApplicationUser User { get; set; }

        public DateTime Created { get; set; }

    }
}