using System;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace Umbraco.Community.ExtensionMethods.Vimeo {

    public class VimeoVideo {

        #region Properties

        /// <summary>
        /// The XML received from the Vimeo API.
        /// </summary>
        public XElement BaseElement { get; private set; }

        /// <summary>
        /// The ID of the video.
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// The title of the video.
        /// </summary>
        public string Title { get; private set; }

        /// <summary>
        /// The video description. May contain traces of HTML.
        /// </summary>
        public string Description { get; private set; }
        
        public string Url { get; private set; }
        public string MobileUrl { get; private set; }
        public DateTime UploadDate { get; private set; }
        public string ThumbnailSmall { get; private set; }
        public string ThumbnailMedium { get; private set; }
        public string ThumbnailLarge { get; private set; }
        public string UserId { get; private set; }
        public string UserName { get; private set; }
        public string UserUrl { get; private set; }
        public string UserPortraitSmall { get; private set; }
        public string UserPortraitMedium { get; private set; }
        public string UserPortraitLarge { get; private set; }
        public string UserPortraitHuge { get; private set; }
        public int Likes { get; private set; }
        public int Plays { get; private set; }
        public int Comments { get; private set; }
        public TimeSpan Duration { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        public string[] Tags { get; private set; }

        #endregion

        #region Constructor

        private VimeoVideo() {
            // Make default constructor private
        }

        #endregion

        #region Static intializers

        /// <summary>
        /// Gets information about a video with the specified ID.
        /// </summary>
        /// <param name="vimeoId">The ID of the video.</param>
        public static VimeoVideo GetVideoById(int vimeoId) {
            return GetVideoById(vimeoId + "");
        }

        /// <summary>
        /// Gets information about a video with the specified ID.
        /// </summary>
        /// <param name="vimeoId">The ID of the video.</param>
        public static VimeoVideo GetVideoById(string vimeoId) {

            // Validate the ID
            if (!Regex.IsMatch(vimeoId, "^[0-9]+$")) throw new ArgumentException("Invalid video ID", vimeoId);

            // Get the XML response from the Vimeo API
            XElement xVideos = XElement.Load("http://vimeo.com/api/v2/video/" + vimeoId + ".xml");

            // Get the <video> element
            return GetVideoFromXElement(xVideos.Element("video"));

        }

        public static VimeoVideo GetVideoFromXElement(XElement xVideo) {

            // Check whether xVideo is NULL
            if (xVideo == null) throw new ArgumentNullException("xVideo");

            // Some parsing
            return new VimeoVideo {
                BaseElement = xVideo,
                Id = xVideo.GetElementValue<int>("id"),
                Title = xVideo.GetElementValue<string>("title"),
                Description = xVideo.GetElementValue<string>("description"),
                Url = xVideo.GetElementValue<string>("url"),
                MobileUrl = xVideo.GetElementValue<string>("mobile_url"),
                UploadDate = xVideo.GetElementValue<DateTime>("upload_date"),
                ThumbnailSmall = xVideo.GetElementValue<string>("thumbnail_small"),
                ThumbnailMedium = xVideo.GetElementValue<string>("thumbnail_medium"),
                ThumbnailLarge = xVideo.GetElementValue<string>("thumbnail_large"),
                UserId = xVideo.GetElementValue<string>("user_id"),
                UserName = xVideo.GetElementValue<string>("user_name"),
                UserUrl = xVideo.GetElementValue<string>("user_url"),
                UserPortraitSmall = xVideo.GetElementValue<string>("user_portrait_small"),
                UserPortraitMedium = xVideo.GetElementValue<string>("user_portrait_medium"),
                UserPortraitLarge = xVideo.GetElementValue<string>("user_portrait_large"),
                UserPortraitHuge = xVideo.GetElementValue<string>("user_portrait_huge"),
                Likes = xVideo.GetElementValue<int>("stats_number_of_likes"),
                Plays = xVideo.GetElementValue<int>("stats_number_of_plays"),
                Comments = xVideo.GetElementValue<int>("stats_number_of_comments"),
                Duration = TimeSpan.FromSeconds(xVideo.GetElementValue<int>("duration")),
                Width = xVideo.GetElementValue<int>("width"),
                Height = xVideo.GetElementValue<int>("height"),
                Tags = (xVideo.GetElementValue<string>("tags") ?? "").Split(new [] { ", " }, StringSplitOptions.RemoveEmptyEntries)
            };

        }

        #endregion

    }
    
    internal static class LinqXmlExtensions {

        public static string GetAttributeValue(this XElement xElement, string name) {
            if (xElement == null) return null;
            XAttribute attr = xElement.Attribute(name);
            return attr == null ? null : attr.Value;
        }

        public static T GetAttributeValue<T>(this XElement xElement, string name) {
            if (xElement == null) return default(T);
            XAttribute attr = xElement.Attribute(name);
            return attr == null ? default(T) : (T) Convert.ChangeType(attr.Value, typeof(T));
        }

        public static string GetElementValue(this XElement xElement, XName name) {
            if (xElement == null) return null;
            XElement child = xElement.Element(name);
            return child == null ? null : child.Value;
        }

        public static T GetElementValue<T>(this XElement xElement, XName name) {
            if (xElement == null) return default(T);
            XElement child = xElement.Element(name);
            return child == null ? default(T) : (T) Convert.ChangeType(child.Value, typeof(T));
        }

    }

}