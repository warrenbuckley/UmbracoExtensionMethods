using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Umbraco.Community.ExtensionMethods.Linq.Xml.ExtensionMethods;

namespace Umbraco.Community.ExtensionMethods.YouTube {

    public class YouTubeChannel {

        public string Link { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public int TotalResults { get; private set; }
        public int StartIndex { get; private set; }
        public int ItemsPerPage { get; private set; }
        public YouTubeChannelVideo[] Items { get; private set; }

        public static YouTubeChannel GetChannel(string author, int offset = 1, int maxResults = 50) {

            if (offset < 1) throw new ArgumentException("\"offset\" must be 1 or greater");
            if (maxResults < 1) throw new ArgumentException("\"max-results\" must be 1 or greater");
            if (maxResults > 50) throw new ArgumentException("\"max-results\" must not be greater than 50");

            string url = "http://gdata.youtube.com/feeds/api/videos/?alt=rss&orderby=published&format=5&author=" + author + "&max-results=" + maxResults + "&start-index=" + offset + "&v=2";

            // Load the XML document
            XElement xFeed = XElement.Load(url);
            if (xFeed.Name != "rss") return null;

            // Get the namespaces
            var atom = xFeed.GetNamespaceOfPrefix("atom");
            var openSearch = xFeed.GetNamespaceOfPrefix("openSearch");

            // Get the channel
            XElement xChannel = xFeed.Element("channel");
            if (xChannel == null) return null;

            // Some pre-parsing
            XElement xLink = xChannel.Element(atom + "link");

            // Initialize and return the object
            return new YouTubeChannel {
                Link = xLink.GetAttributeValue("href"),
                Title = xChannel.GetElementValue("title"),
                Description = xChannel.GetElementValue("description"),
                TotalResults = xChannel.GetElementValue<int>(openSearch + "totalResults"),
                StartIndex = xChannel.GetElementValue<int>(openSearch + "startIndex"),
                ItemsPerPage = xChannel.GetElementValue<int>(openSearch + "itemsPerPage"),
                Items = YouTubeChannelVideo.Parse(xChannel.Elements("item"))
            };

        }

    }

}
