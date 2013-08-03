namespace Umbraco.Community.ExtensionMethods.YouTube.ExtensionMethods {
    
    public static class YouTubeExtensionMethods {

        /// <summary>
        /// Assuming the value of the string is a valid channel name, this method will get the videos of the specified
        /// channel. Theresponse uses pagination, so you might need to make multiple calls to get all videos of a
        /// channel.
        /// </summary>
        /// <param name="channelName">The name of the channel (use the authors name for their default channel).</param>
        public static YouTubeChannel GetChannel(this string channelName) {
            return YouTubeChannel.GetChannel(channelName);
        }

        /// <summary>
        /// Assuming the value of the string is a valid channel name, this method will get the videos of the specified
        /// channel. Theresponse uses pagination, so you might need to make multiple calls to get all videos of a
        /// channel.
        /// </summary>
        /// <param name="channelName">The name of the channel (use the authors name for their default channel).</param>
        /// <param name="offset">The offset (must be 1 or higher - default is 1).</param>
        public static YouTubeChannel GetChannel(this string channelName, int offset) {
            return YouTubeChannel.GetChannel(channelName, offset);
        }

        /// <summary>
        /// Assuming the value of the string is a valid channel name, this method will get the videos of the specified
        /// channel. Theresponse uses pagination, so you might need to make multiple calls to get all videos of a
        /// channel.
        /// </summary>
        /// <param name="channelName">The name of the channel (use the authors name for their default channel).</param>
        /// <param name="offset">The offset (must be 1 or higher - default is 1).</param>
        /// <param name="maxResults">The maximum of videos per page (cannot be greater than 50).</param>
        public static YouTubeChannel GetChannel(this string channelName, int offset, int maxResults) {
            return YouTubeChannel.GetChannel(channelName, offset, maxResults);
        }

        /// <summary>
        /// Attempts to find a YouTube video ID the specified string and get
        /// information about that video.
        /// </summary>
        /// <param name="subject">The string to search.</param>
        public static YouTubeVideo GetYouTubeVideo(this string subject) {
            return YouTubeHelpers.GetVideoFromString(subject);
        }

        /// <summary>
        /// Uses regular expressions for finding a YouTube video ID in the string.
        /// </summary>
        /// <param name="subject">The string to search.</param>
        /// <returns>The YouTube video ID if found, otherwise <var>NULL</var>.</returns>
        public static string GetYouTubeId(this string subject) {
            return YouTubeHelpers.GetIdFromString(subject);
        }

        /// <summary>
        /// Uses regular expressions for finding a YouTube video ID in the string.
        /// </summary>
        /// <param name="subject">The string to search.</param>
        /// <param name="videoId">The YouTube video ID if found, otherwise <var>NULL</var>.</param>
        /// <returns>Returns <var>TRUE</var> if a video ID is found, otherwise <var>FALSE</var>.</returns>
        public static bool GetYouTubeId(this string subject, out string videoId) {
            return YouTubeHelpers.GetIdFromString(subject, out videoId);
        }

        /// <summary>
        /// Builds the HTML embed iframe for the specified video.
        /// </summary>
        /// <param name="videoId">The YouTube ID of the video.</param>
        /// <param name="width">The desired width of the iframe.</param>
        /// <param name="height">The desired height of the iframe.</param>
        public static string YouTubeEmbed(this string videoId, int width, int height) {
            return YouTubeHelpers.GetEmbedHtml(videoId, width, height);
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
        public static string YouTubeEmbed(this string videoId, int width, int height, bool showRelations, string wmode) {
            return YouTubeHelpers.GetEmbedHtml(videoId, width, height, showRelations, wmode);
        }

        /// <summary>
        /// Gets the default thumbnail URL for a video with the specified ID. The default
        /// thumbnail measures 480x360 pixels.
        /// </summary>
        /// <param name="videoId">The ID of the video.</param>
        /// <returns>The thumbnail URL if the video ID is valid, otherwise <var>NULL</var>.</returns>
        public static string GetYouTubeThumbnail(this string videoId) {
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
        public static string GetYouTubeThumbnail(this string videoId, int index) {
            return YouTubeHelpers.GetYouTubeThumbnail(videoId, index);
        }

    }

}
