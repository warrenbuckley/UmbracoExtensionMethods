using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using System.Xml.XPath;
using Umbraco.Community.ExtensionMethods.Linq.Xml.ExtensionMethods;

namespace Umbraco.Community.ExtensionMethods.YouTube {

    public class YouTubeVideo {

        public string Id { get; private set; }
        public DateTime Published { get; private set; }
        public DateTime LastUpdated { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string Link { get; private set; }
        public string Author { get; private set; }
        public TimeSpan Duration { get; private set; }
        public int FavoriteCount { get; private set; }
        public int ViewCount { get; private set; }
        public int Likes { get; private set; }
        public int Dislikes { get; private set; }
        public double Rating { get; private set; }
        public int NumberOfRaters { get; private set; }

        public static YouTubeVideo GetVideoFromId(string videoId) {

            // Validate the ID
            if (!Regex.IsMatch(videoId, "^[\\w-]{11}$")) throw new ArgumentException("Invalid video ID", videoId);

            // Get the XML response from the YouTube API
            return Parse(XElement.Load("https://gdata.youtube.com/feeds/api/videos/" + videoId + "?v=2"));

        }

        public static YouTubeVideo Parse(XElement xElement) {
            if (xElement == null) return null;
            if (xElement.Name.LocalName == "item") return ParseItem(xElement);
            if (xElement.Name.LocalName == "entry") return ParseEntry(xElement);
            return null;
        }

        private static YouTubeVideo ParseItem(XElement xItem) {
            
            // Get namespaces
            XNamespace atom = xItem.GetNamespaceOfPrefix("atom");
            XNamespace media = xItem.GetNamespaceOfPrefix("media");
            XNamespace yt = xItem.GetNamespaceOfPrefix("yt");
            XNamespace gd = xItem.GetNamespaceOfPrefix("gd");

            // Some pre-parsing
            XElement xMedia = xItem.Element(media + "group");
            XElement xDuration = xMedia.Element(yt + "duration");

            // Get the <yt:statistics> element describing the number of favorites and
            // number of views
            XElement xStatistics = xItem.Element(yt + "statistics");

            // Get the <yt:rating> element describing the number of lines and
            // number of dislikes (may not always be present)
            XElement xYouTubeRating = xItem.Element(yt + "rating");

            // Get the <gd:rating> element describing the video rating and
            // number of raters
            XElement xGoogleRating = xItem.Element(gd + "rating");

            // Initialize and return the object
            YouTubeVideo video = new YouTubeVideo();
            video.Id = GetVideoId(xItem);
            video.Published = xItem.GetElementValue<DateTime>("pubDate");
            video.LastUpdated = xItem.GetElementValue<DateTime>(atom + "updated");
            video.Title = xItem.GetElementValue("title");
            video.Description = xItem.GetElementValue("description");
            video.Link = xItem.GetElementValue("link");
            video.Author = xItem.GetElementValue("author");
            video.Duration = TimeSpan.FromSeconds(xDuration.GetAttributeValue<int>("seconds"));
            video.FavoriteCount = xStatistics == null ? 0 : xStatistics.GetAttributeValue<int>("favoriteCount");
            video.ViewCount = xStatistics == null ? 0 : xStatistics.GetAttributeValue<int>("viewCount");
            video.Likes = xYouTubeRating == null ? 0 : xYouTubeRating.GetAttributeValue<int>("numLikes");
            video.Dislikes = xYouTubeRating == null ? 0 : xYouTubeRating.GetAttributeValue<int>("numDislikes");
            video.Rating = xGoogleRating == null ? 0 : xGoogleRating.GetAttributeValue<int>("average");
            video.NumberOfRaters = xGoogleRating == null ? 0 : xGoogleRating.GetAttributeValue<int>("numRaters");
            return video;

        }

        private static YouTubeVideo ParseEntry(XElement xEntry) {

            // Get namespaces
            XNamespace atom = xEntry.GetDefaultNamespace();
            XNamespace media = xEntry.GetNamespaceOfPrefix("media");
            XNamespace yt = xEntry.GetNamespaceOfPrefix("yt");
            XNamespace gd = xEntry.GetNamespaceOfPrefix("gd");

            // Some pre-parsing
            XElement xAuthor = xEntry.Element(atom + "author");
            XElement xMedia = xEntry.Element(media + "group");
            XElement xDuration = xMedia.Element(yt + "duration");
            XElement xLink = xEntry.Elements(atom + "link").FirstOrDefault(x => x.GetAttributeValue("rel") == "alternate");


            // Get the <yt:statistics> element describing the number of favorites and
            // number of views
            XElement xStatistics = xEntry.Element(yt + "statistics");

            // Get the <yt:rating> element describing the number of lines and
            // number of dislikes (may not always be present)
            XElement xYouTubeRating = xEntry.Element(yt + "rating");

            // Get the <gd:rating> element describing the video rating and
            // number of raters
            XElement xGoogleRating = xEntry.Element(gd + "rating");
            
            // Initialize and return the object
            YouTubeVideo video = new YouTubeVideo();
            video.Id = xLink == null ? null : Regex.Match(xLink.GetAttributeValue("href"), "v=([\\w-]{11})").Groups[1].Value;
            video.Published = xEntry.GetElementValue<DateTime>(atom + "published");
            video.LastUpdated = xEntry.GetElementValue<DateTime>(atom + "updated");
            video.Title = xEntry.GetElementValue(atom + "title");
            video.Description = xMedia.GetElementValue(media + "description");
            video.Link = xLink == null ? null : xLink.GetAttributeValue("href");
            video.Author = xAuthor.GetElementValue(atom + "name");
            video.Duration = TimeSpan.FromSeconds(xDuration.GetAttributeValue<int>("seconds"));
            video.FavoriteCount = xStatistics == null ? 0 : xStatistics.GetAttributeValue<int>("favoriteCount");
            video.ViewCount = xStatistics == null ? 0 : xStatistics.GetAttributeValue<int>("viewCount");
            video.Likes = xYouTubeRating == null ? 0 : xYouTubeRating.GetAttributeValue<int>("numLikes");
            video.Dislikes = xYouTubeRating == null ? 0 : xYouTubeRating.GetAttributeValue<int>("numDislikes");
            video.Rating = xGoogleRating == null ? 0 : xGoogleRating.GetAttributeValue<double>("average", CultureInfo.InvariantCulture);
            video.NumberOfRaters = xGoogleRating == null ? 0 : xGoogleRating.GetAttributeValue<int>("numRaters");
            return video;

        }

        public static YouTubeVideo[] Parse(IEnumerable<XElement> items) {
            return (from item in items select Parse(item)).ToArray();
        }

        /// <summary>
        /// If the video is retrieved as part of a channel, it is described by
        /// an &lt;item&gt; element.If the video is retrieved directly, it is
        /// instead described by an &lt;entry&gt; element. This also affects
        /// how the URL (and ID) can be found.
        /// </summary>
        /// <param name="xElement"></param>
        /// <returns></returns>
        private static string GetVideoId(XElement xElement) {
            if (xElement == null) return null;
            if (xElement.Name == "item") return Regex.Match(xElement.GetElementValue("link"), "v=([\\w-]{11})").Groups[1].Value;
            if (xElement.Name == "entry") {
                var link = xElement.XPathSelectElement("link[@rel=alternate]");
                return link == null ? null : link.GetAttributeValue("href");
            }
            return null;
        }

    }

}
