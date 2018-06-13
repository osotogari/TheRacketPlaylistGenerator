using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using TheRacketPlaylistGenerator.Helpers;
using TheRacketPlaylistGenerator.Models;
using TheRacketPlaylistGenerator.ViewModels;

namespace TheRacketPlaylistGenerator.Controllers
{
    public class PlaylistController : Controller
    {
        private static HttpClient client;

        public PlaylistController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://music.abcradio.net.au/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        [HttpGet]
        public async Task<ActionResult> GeneratePlaylist(DateTime? showDate, string showTime, string showName)
        {
            var playlist = new PlaylistViewModel();
            playlist.SelectedDate = showDate != null ? showDate : DateTime.Today;
            playlist.SelectedShowTime = showName;
            var playlistDetailsList = new List<PlaylistDetails>();

            if (showDate.HasValue && !string.IsNullOrWhiteSpace(showTime))
            {
                var showTimeSpan = showTime.Split('-');
                var fromTimeSpan = TimeSpan.Parse(showTimeSpan[0]);
                var toTimeSpan = TimeSpan.Parse(showTimeSpan[1]);

                var showDateTime = showDate.Value.Add(fromTimeSpan);
                var toDateTime = ShowTimesHelper.CalculateShowEndTime(showDate, fromTimeSpan, toTimeSpan);

                var timeZone = TimeZoneInfo.FindSystemTimeZoneById("E. Australia Standard Time");

                var from = new DateTimeWithZone(showDateTime, timeZone).UniversalTime;
                var to = new DateTimeWithZone(toDateTime, timeZone).UniversalTime;

                var apiPath = string.Format(@"api/v1/plays/search.json?&from={0}&to={1}&order=asc&station=triplej&limit=50", from.ToString("yyyy-MM-ddTHH:mm:ss"), to.ToString("yyyy-MM-ddTHH:mm:ss"));
                var snapshot = await GetPlaylist(apiPath);

                if (snapshot != null && snapshot.Items != null)
                {
                    foreach (var item in snapshot.Items)
                        playlistDetailsList.Add(Services.PlaylistTransformationService.TransformPlaylistDataEntity(item));

                    playlist.PlaylistDetails = playlistDetailsList;
                }

                return View(playlist);
            }

            return View(playlist);
        }


        public static async Task<PlaylistSearchResult> GetPlaylist(string apiPath)
        {
            PlaylistSearchResult result = null;

            using (client)
            {
                var url = client.BaseAddress + apiPath;
                HttpResponseMessage response = await client.GetAsync(url).ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    result = await response.Content.ReadAsAsync<PlaylistSearchResult>();
                }
            }

            return result;
        }
    }
}