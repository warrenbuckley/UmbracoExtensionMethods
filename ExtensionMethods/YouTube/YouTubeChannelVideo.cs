using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using Umbraco.Community.ExtensionMethods.Linq.Xml.ExtensionMethods;

namespace Umbraco.Community.ExtensionMethods.YouTube {
    
    public class YouTubeChannelVideo {

        public string Id { get; private set; }
        public DateTime Published { get; private set; }
        public DateTime LastUpdated { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string Link { get; private set; }
        public string Author { get; private set; }
        public int Duration { get; private set; }

        public static YouTubeChannelVideo Parse(XElement xItem) {

            // Get namespaces
            XNamespace atom = xItem.GetNamespaceOfPrefix("atom");
            XNamespace media = xItem.GetNamespaceOfPrefix("media");
            XNamespace yt = xItem.GetNamespaceOfPrefix("yt");

            // Some pre-parsing
            XElement xMedia = xItem.Element(media + "group");
            XElement xDuration = xMedia.Element(yt + "duration");
            
            // Initialize and return the object
            return new YouTubeChannelVideo {
                Id = Regex.Match(xItem.GetElementValue("link"), "v=([v-]{11})").Groups[1].Value,
                Published = xItem.GetElementValue<DateTime>("pubDate"),
                LastUpdated = xItem.GetElementValue<DateTime>(atom + "updated"),
                Title = xItem.GetElementValue("title"),
                Description = xMedia.GetElementValue(media + "description"),
                Link = xItem.GetElementValue("link"),
                Author = xItem.GetElementValue("author"),
                Duration = xDuration.GetAttributeValue<int>("seconds")
            };

        }

        public static YouTubeChannelVideo[] Parse(IEnumerable<XElement> items) {
            return (from item in items select Parse(item)).ToArray();
        }
    
    }

}
