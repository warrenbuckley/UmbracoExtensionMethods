using System;
using System.Web;

namespace Umbraco.Community.ExtensionMethods.Vimeo {
    
    public static class VimeoHelpers {

        /// <summary>
        /// Gets information about a video with the specified ID. Any exceptions that might
        /// occur during the calls to the API will be catched, and the method will instead
        /// return <var>NULL</var>.
        /// </summary>
        /// <param name="vimeoId">The ID of the video.</param>
        public static VimeoVideo GetVideoById(int vimeoId) {
            try {
                return VimeoVideo.GetVideoById(vimeoId);
            } catch {
                return null;
            }
        }

        /// <summary>
        /// Gets information about a video with the specified ID. Any exceptions that might
        /// occur during the calls to the API will be catched, and the method will instead
        /// return <var>NULL</var>.
        /// </summary>
        /// <param name="vimeoId">The ID of the video.</param>
        public static VimeoVideo GetVideoById(string vimeoId) {
            try {
                return VimeoVideo.GetVideoById(vimeoId);
            } catch {
                return null;
            }
        }

        /// <summary>
        /// Gets information about a video with the specified ID. Any exceptions that might
        /// occur during the calls to the API will be catched, and the method will instead
        /// return <var>NULL</var>. If the video is found, it is cached for the current
        /// request so calling the method multiple times will only result in a single
        /// request to the Vimeo API.
        /// </summary>
        /// <param name="vimeoId">The ID of the video.</param>
        public static VimeoVideo GetCachedVideoById(int vimeoId) {
            return GetCachedVideoById(vimeoId + "");
        }

        /// <summary>
        /// Gets information about a video with the specified ID. Any exceptions that might
        /// occur during the calls to the API will be catched, and the method will instead
        /// return <var>NULL</var>. If the video is found, it is cached for the current
        /// request so calling the method multiple times will only result in a single
        /// request to the Vimeo API.
        /// </summary>
        /// <param name="vimeoId">The ID of the video.</param>
        public static VimeoVideo GetCachedVideoById(string vimeoId) {

            // If there is no HttpContext, we just get the video directly from the API
            if (HttpContext.Current == null) return GetVideoById(vimeoId);

            // Attempt to get the video from the cache
            VimeoVideo video = HttpContext.Current.Items["VimeoVideo:" + vimeoId] as VimeoVideo;
            
            // Download the video information if not in the cache
            if (video == null) {
                video = GetVideoById(vimeoId);
                if (video != null) HttpContext.Current.Items["VimeoVideo:" + vimeoId] = video;
            }

            return video;

        }

        /// <summary>
        /// Generates the HTML iframe for embedding a Vimeo video based on the specified ID.
        /// </summary>
        /// <param name="vimeoId">The ID of the video.</param>
        /// <param name="width">The width of the iframe.</param>
        /// <param name="height">The height of the iframe.</param>
        public static string GetEmbedHtml(int vimeoId, int width, int height) {
            return GetEmbedHtml(vimeoId + "", width, height);
        }

        /// <summary>
        /// Generates the HTML iframe for embedding a Vimeo video based on the specified ID.
        /// </summary>
        /// <param name="vimeoId">The ID of the video.</param>
        /// <param name="width">The width of the iframe.</param>
        /// <param name="height">The height of the iframe.</param>
        public static string GetEmbedHtml(string vimeoId, int width, int height) {
            return String.Format(
                "<iframe src='http://player.vimeo.com/video/{0}' width='{1}' height='{2}' frameborder='0' webkitAllowFullScreen mozallowfullscreen allowFullScreen></iframe>",
                vimeoId, width, height
            );
        }

    }

}