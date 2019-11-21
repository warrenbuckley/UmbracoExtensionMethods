using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Umbraco.Community.ExtensionMethods.YouTube {

    public static class YouTubeHelpers {

        /// <summary>
        /// Gets the videos of the specified channel.
        /// </summary>
        /// <param name="channelName">The name of the channel (use the authors name for their default channel).</param>
        public static YouTubeChannel GetChannel(string channelName) {
            return YouTubeChannel.GetChannel(channelName);
        }
        
        /// <summary>
        /// Gets the videos of the specified channel.
        /// </summary>
        /// <param name="offset">The offset (must be 1 or higher - default is 1).</param>
        /// <param name="channelName">The name of the channel (use the authors name for their default channel).</param>
        public static YouTubeChannel GetChannel(string channelName, int offset) {
            return YouTubeChannel.GetChannel(channelName, offset);
        }

        /// <summary>
        /// Gets the videos of the specified channel.
        /// </summary>
        /// <param name="channelName">The name of the channel (use the authors name for their default channel).</param>
        /// <param name="offset">The offset (must be 1 or higher - default is 1).</param>
        /// <param name="maxResults">The maximum of videos per page (cannot be greater than 50).</param>
        public static YouTubeChannel GetChannel(string channelName, int offset, int maxResults) {
            return YouTubeChannel.GetChannel(channelName, offset, maxResults);
        }

        /// <summary>
        /// Gets information about a video with the specified.
        /// </summary>
        /// <param name="videoId">The ID of the video.</param>
        public static YouTubeVideo GetVideoFromId(string videoId) {
            return YouTubeVideo.GetVideoFromId(videoId);
        }
        
        /// <summary>
        /// Attempts to find a YouTube video ID the specified string and get
        /// information about that video.
        /// </summary>
        /// <param name="subject">The string to search.</param>
        public static YouTubeVideo GetVideoFromString(string subject) {
            return YouTubeVideo.GetVideoFromId(GetIdFromString(subject));
        }

        /// <summary>
        /// Uses regular expressions for finding a YouTube video ID in the string.
        /// </summary>
        /// <param name="subject">The string to search.</param>
        /// <returns>The YouTube video ID if found, otherwise <var>NULL</var>.</returns>
        public static string GetIdFromString(string subject) {
            
            // The four regular expressions cover the scenarios
            // I've been able to find so far
            var tests = new[] {
                Regex.Match(subject, "^((\\w|-){11}$)"),
                Regex.Match(subject, "v=((\\w|-){11})"),
                Regex.Match(subject.Split('?')[0], "\\/((\\w|-){11})$"),
                Regex.Match(subject, "\\/vi|v|embed/((\\w|-){11})")
            };

            // Run through the tests
            return (
                from test in tests
                where test.Success
                select test.Groups[1].Value
            ).FirstOrDefault();
        
        }

        /// <summary>
        /// Uses regular expressions for finding a YouTube video ID in the string.
        /// </summary>
        /// <param name="subject">The string to search.</param>
        /// <param name="videoId">The YouTube video ID if found, otherwise <var>NULL</var>.</param>
        /// <returns>Returns <var>TRUE</var> if a video ID is found, otherwise <var>FALSE</var>.</returns>
        public static bool GetIdFromString(string subject, out string videoId) {
            videoId = GetIdFromString(subject);
            return videoId != null;
        }

        /// <summary>
        /// Builds the HTML embed iframe for the specified video.
        /// </summary>
        /// <param name="videoId">The YouTube ID of the video.</param>
        /// <param name="width">The desired width of the iframe.</param>
        /// <param name="height">The desired height of the iframe.</param>
        public static string GetEmbedHtml(string videoId, int width, int height) {
            if (!Regex.IsMatch(videoId, "^[\\w|-]{11}$")) return null;
            return String.Format(
                "<iframe src=\"{0}\" width=\"{1}\" height=\"{2}\" frameborder=\"0\" allowfullscreen></iframe>",
                "http://www.youtube.com/embed/" + videoId,
                width,
                height
            );
        }

        /// <summary>
        /// Builds the HTML embed iframe for the specified video.
        /// </summary>
        /// <param name="videoId">The YouTube ID of the video.</param>
        /// <param name="width">The desired width of the iframe.</param>
        /// <param name="height">The desired height of the iframe.</param>
        /// <param name="showRelations">By the default, YouTube will show
        /// related videos at the end of videos. Setting this to
        /// <var>FALSE</var> will disable the feature.</param>
        /// <param name="wmode">The flash video player doesn't really
        /// play well with layers (mostly in IE). Setting this
        /// parameter to <var>transarent</var> will solve most
        /// of these issues.</param>
        public static string GetEmbedHtml(string videoId, int width, int height, bool showRelations, string wmode) {
            if (!Regex.IsMatch(videoId, "^[\\w|-]{11}$")) return null;
            return String.Format(
                "<iframe src=\"{0}\" width=\"{1}\" height=\"{2}\" frameborder=\"0\" allowfullscreen></iframe>",
                "http://www.youtube.com/embed/" + videoId + "?rel=" + (showRelations ? 1 : 0) + "&wmode=" + wmode,
                width,
                height
            );
        }

        /// <summary>
        /// Gets the default thumbnail URL for a video with the specified ID. The default
        /// thumbnail measures 480x360 pixels.
        /// </summary>
        /// <param name="videoId">The ID of the video.</param>
        /// <returns>The thumbnail URL if the video ID is valid, otherwise <var>NULL</var>.</returns>
        public static string GetYouTubeThumbnail(string videoId) {
            return GetYouTubeThumbnail(videoId, 0);
        }

        /// <summary>
        /// Gets the thumbnail URL for a video with the specified ID. The default thumbnail (index = 0)
        /// measures 480x360 pixels, while the others measures 120x90 pixels.
        /// </summary>
        /// <param name="videoId">The ID of the video.</param>
        /// <param name="index">The index of the thumbnail URL to return
        /// (valid range is from 0 to 3 - both inclusive).</param>
        /// <returns>The thumbnail URL if the video ID is valid, otherwise <var>NULL</var>.</returns>
        public static string GetYouTubeThumbnail(string videoId, int index) {
            if (!Regex.IsMatch(videoId, "^[\\w|-]{11}$")) return null;
            return "http://i.ytimg.com/vi/" + videoId + "/" + index + ".jpg";
        }

    }

}
