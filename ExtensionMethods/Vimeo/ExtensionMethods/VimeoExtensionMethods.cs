namespace Umbraco.Community.ExtensionMethods.Vimeo.ExtensionMethods {

    public static class VimeoExtensionMethods {

        /// <summary>
        /// Generates the HTML iframe for embedding a Vimeo video based on the specified ID.
        /// </summary>
        /// <param name="vimeoId">The ID of the video.</param>
        /// <param name="width">The width of the iframe.</param>
        /// <param name="height">The height of the iframe.</param>
        public static string VimeoEmbed(this int vimeoId, int width, int height) {
            return VimeoHelpers.GetEmbedHtml(vimeoId, width, height);
        }

        /// <summary>
        /// Generates the HTML iframe for embedding a Vimeo video based on the specified ID.
        /// </summary>
        /// <param name="vimeoId">The ID of the video.</param>
        /// <param name="width">The width of the iframe.</param>
        /// <param name="height">The height of the iframe.</param>
        public static string VimeoEmbed(this string vimeoId, int width, int height) {
            return VimeoHelpers.GetEmbedHtml(vimeoId, width, height);
        }

        /// <summary>
        /// Gets the duration of the Vimeo video with the specified ID.
        /// </summary>
        /// <param name="vimeoId">The ID of the video.</param>
        /// <returns>Returns the duration in seconds if the video is found, otherwise <var>-1</var> will be returned.</returns>
        public static int GetVimeoDuration(this int vimeoId) {
            VimeoVideo video = VimeoHelpers.GetCachedVideoById(vimeoId);
            return video == null ? -1 : (int) video.Duration.TotalSeconds;
        }

        /// <summary>
        /// Gets the duration of the Vimeo video with the specified ID.
        /// </summary>
        /// <param name="vimeoId">The ID of the video.</param>
        /// <returns>Returns the duration in seconds if the video is found, otherwise <var>-1</var> will be returned.</returns>
        public static int GetVimeoDuration(this string vimeoId) {
            VimeoVideo video = VimeoHelpers.GetCachedVideoById(vimeoId);
            return video == null ? -1 : (int) video.Duration.TotalSeconds;
        }

        /// <summary>
        /// Gets the URL for a thumbnail measuring 640x360 pixels.
        /// </summary>
        /// <param name="vimeoId">The ID of the video.</param>
        public static string GetVimeoThumbnail(this int vimeoId) {
            return GetVimeoThumbnail(vimeoId + "", VimeoThumbnail.Large);
        }

        /// <summary>
        /// Gets the URL for a thumbnail measuring 640x360 pixels.
        /// </summary>
        /// <param name="vimeoId">The ID of the video.</param>
        public static string GetVimeoThumbnail(this string vimeoId) {
            return GetVimeoThumbnail(vimeoId, VimeoThumbnail.Large);
        }

        /// <summary>
        /// Gets the URL for a thumbnail with the specified size.
        /// </summary>
        /// <param name="vimeoId">The ID of the video.</param>
        /// <param name="size">The size of the desired thumbnail.</param>
        public static string GetVimeoThumbnail(this int vimeoId, VimeoThumbnail size) {
            return GetVimeoThumbnail(vimeoId + "", size);
        }

        /// <summary>
        /// Gets the URL for a thumbnail with the specified size.
        /// </summary>
        /// <param name="vimeoId">The ID of the video.</param>
        /// <param name="size">The size of the desired thumbnail.</param>
        public static string GetVimeoThumbnail(this string vimeoId, VimeoThumbnail size) {
            VimeoVideo video = VimeoHelpers.GetCachedVideoById(vimeoId);
            if (video == null) return null;
            switch (size) {
                case VimeoThumbnail.Small:
                    return video.ThumbnailSmall;
                case VimeoThumbnail.Medium:
                    return video.ThumbnailMedium;
                default:
                    return video.ThumbnailLarge;
            }
        }

    }

}
