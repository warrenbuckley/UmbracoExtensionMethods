using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Umbraco.Community.ExtensionMethods.Vimeo
{
    public static class Vimeo
    {

        //Vimeo Embededed Video from VideoID or URL
        public static string VimeoEmbed(this string vimeoID, int width, int height)
         {
            return
                string.Format(
                "<iframe src='http://player.vimeo.com/video/{0}' width='{1}' height='{2}' frameborder='0' webkitAllowFullScreen mozallowfullscreen allowFullScreen></iframe>",
                vimeoID, width, height);
        }
         
        //Todo - Vimeo API get thumbnail & more

       

    }
}
