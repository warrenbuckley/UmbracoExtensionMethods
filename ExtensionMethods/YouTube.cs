using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Umbraco.Community.ExtensionMethods.YouTube
{
    public static class YouTube
    {

        //TODO
        public static string YouTubeEmbed(this string youtubeID, int width, int height)
        {
            return string.Empty;
        }

        /// <summary>
        /// This will return the ID part of Youtube URLs
        /// </summary>
        /// <param name="url">video url</param>
        /// <returns>video id</returns>
        public static string GetYoutubeId(string url)
        {
            // Example: http://www.youtube.com/watch?v=MD5nU7kt7pg will return MD5nU7kt7pg

            string id = string.Empty;
            Regex youtubeVideoRegex = new Regex(@"youtu(?:\.be|be\.com)/(?:.*v(?:/|=)|(?:.*/)?)([a-zA-Z0-9-_]+)");
            Match youtubeMatch = youtubeVideoRegex.Match(url);
            if (youtubeMatch.Success)
                id = youtubeMatch.Groups[1].Value;
            return id;
        }
        
    }
}
