using System;
using System.Linq;
using TheRacketPlaylistGenerator.Models;
using TheRacketPlaylistGenerator.ViewModels;

namespace TheRacketPlaylistGenerator.Services
{
    public static class PlaylistTransformationService
    {

        public static PlaylistDetails TransformPlaylistDataEntity(Item dataEntity)
        {
            var playlistDetails = new PlaylistDetails
            {
                AlbumCoverUrl = dataEntity.Recording.Releases.Count > 0 && dataEntity.Recording.Releases[0].Artwork.Count > 0 ? dataEntity.Recording.Releases.First().Artwork.First().Url : @"https://radio.abc.net.au/images/album-cover.svg",
                AlbumName = dataEntity.Recording.Releases.Count > 0 ? dataEntity.Recording.Releases.First().Title : string.Empty,
                SongTitle = dataEntity.Recording.Title,
                Duration = new TimeSpan(0, 0, (int)dataEntity.Recording.Duration),
                Artist = dataEntity.Recording.Artists.First().Name
            };

            return playlistDetails;
        }

    }
}