using System;
using System.Collections.Generic;

namespace TheRacketPlaylistGenerator.Helpers
{
    public static class ShowTimesHelper
    {
        public static List<KeyValuePair<string, string>> ShowTimes()
        {
            var showTimesDictionary = new List<KeyValuePair<string, string>>();

            showTimesDictionary.Add(new KeyValuePair<string, string>("placeholder", "Select program"));
            showTimesDictionary.Add(new KeyValuePair<string, string>("6:00-9:00", "Breakfast"));
            showTimesDictionary.Add(new KeyValuePair<string, string>("9:00-12:00", "Mornings"));
            showTimesDictionary.Add(new KeyValuePair<string, string>("12:00-15:00", "Lunch"));
            showTimesDictionary.Add(new KeyValuePair<string, string>("15:00-17:30", "Drive"));
            showTimesDictionary.Add(new KeyValuePair<string, string>("18:00-21:00", "Good Nights"));
            showTimesDictionary.Add(new KeyValuePair<string, string>("21:00-22:00", "Home & Hosed"));
            showTimesDictionary.Add(new KeyValuePair<string, string>("22:00-01:00", "Roots 'n All"));
            showTimesDictionary.Add(new KeyValuePair<string, string>("22:00-01:00", "The Racket"));
            showTimesDictionary.Add(new KeyValuePair<string, string>("22:00-01:00", "Short.Fast.Loud"));
            showTimesDictionary.Add(new KeyValuePair<string, string>("22:00-01:00", "Hip Hop Show"));
            showTimesDictionary.Add(new KeyValuePair<string, string>("22:00-01:00", "Friday Night Shuffle"));
            showTimesDictionary.Add(new KeyValuePair<string, string>("18:00-21:00", "House Party"));
            showTimesDictionary.Add(new KeyValuePair<string, string>("21:00-01:00", "Mix Up"));
            showTimesDictionary.Add(new KeyValuePair<string, string>("01:00-06:00", "The Kick On"));
            showTimesDictionary.Add(new KeyValuePair<string, string>("18:00-21:00", "2018"));
            showTimesDictionary.Add(new KeyValuePair<string, string>("21:00-23:00", "The Hook Up"));
            showTimesDictionary.Add(new KeyValuePair<string, string>("23:00-01:00", "Something More"));
            showTimesDictionary.Add(new KeyValuePair<string, string>("06:00-10:00", "Weekend Brekky"));
            showTimesDictionary.Add(new KeyValuePair<string, string>("10:00-14:00", "Weekend Lunch"));
            showTimesDictionary.Add(new KeyValuePair<string, string>("14:00-18:00", "Weekend Arvos"));
            showTimesDictionary.Add(new KeyValuePair<string, string>("01:00-06:00", "Mid Dawns"));

            return showTimesDictionary;
        }

        public static DateTime CalculateShowEndTime(DateTime? date, TimeSpan start, TimeSpan end)
        {
            if (date == null) return DateTime.Today;

            if (start >= end)
                date = date.Value.AddDays(1);

            return date.Value.Add(end);
        }
    }

    public struct DateTimeWithZone
    {
        private readonly DateTime utcDateTime;
        private readonly TimeZoneInfo timeZone;

        public DateTimeWithZone(DateTime dateTime, TimeZoneInfo timeZone)
        {
            var dateTimeUnspec = DateTime.SpecifyKind(dateTime, DateTimeKind.Unspecified);
            utcDateTime = TimeZoneInfo.ConvertTimeToUtc(dateTimeUnspec, timeZone);
            this.timeZone = timeZone;
        }

        public DateTime UniversalTime { get { return utcDateTime; } }
        public TimeZoneInfo TimeZone { get { return timeZone; } }

        public DateTime LocalTime
        {
            get
            {
                return TimeZoneInfo.ConvertTime(utcDateTime, timeZone);
            }
        }
    }
}