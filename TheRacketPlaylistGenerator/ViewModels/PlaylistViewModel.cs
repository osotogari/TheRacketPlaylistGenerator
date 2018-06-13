using System;
using System.Collections.Generic;

namespace TheRacketPlaylistGenerator.ViewModels
{
    public class PlaylistViewModel
    {
        public DateTime? SelectedDate { get; set; }
        public string SelectedShowTime { get; set; }
        public List<KeyValuePair<string, string>> ShowTimes { get; set; }

        public List<PlaylistDetails> PlaylistDetails { get; set; }

        public PlaylistViewModel()
        {
            ShowTimes = Helpers.ShowTimesHelper.ShowTimes();
            SelectedDate = DateTime.Today;
            SelectedShowTime = "Please Select";

            PlaylistDetails = new List<PlaylistDetails>();
        }
    }

    public class PlaylistDetails
    {
        public string AlbumCoverUrl { get; set; }
        public TimeSpan Duration { get; set; }
        public string Artist { get; set; }
        public string SongTitle { get; set; }
        public string AlbumName { get; set; }
        public string SearchTerms { get; set; }
    }
}