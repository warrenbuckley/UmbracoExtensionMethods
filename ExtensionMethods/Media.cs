using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Umbraco.Community.ExtensionMethods.Media
{
    public static class Media
    {
        //ImageGen URL Helper
        public static string ImageGenURL(this string imageURL, int width, int height)
        {
            //Base URL
            var baseURL = "/imagegen.ashx?";


            //Align (Left, Center, Right, Near, Far)
            baseURL += string.Format("Align={0}", align);

            //Allow Upsizing (True False)
            baseURL += string.Format("AllowUpsizing={0}", allowUpsizing);

            //Alt Image (/photos/waterfall.png)
            baseURL += string.Format("AltImage={0}", altImage);

            //AntiAlias (True of False)
            baseURL += string.Format("AntiAlias={0}", antiAlias);

            //BgColor (FFFFFF)
            baseURL += string.Format("BgColor={0}", bgColor);

            //Border (0, 10)
            baseURL += string.Format("Border={0}", border);

            //BgColor (000000)
            baseURL += string.Format("BorderColor={0}", borderColor);

            //... TODO more to add


            //Height
            baseURL += string.Format("&height={0}", height);

            //... TODO more to add


            //Rotate (0 - 360)
            baseURL += string.Format("Rotate={0}", rotate);

            //Transparent (True of False)
            baseURL += string.Format("Transparent={0}", transparent);

            //VAlign (Top, Middle, Bottom, Near, Far)
            baseURL += string.Format("VAlign={0}", vAlign);

            //Width
            baseURL += string.Format("width={0}", width);

            //return the URL thats been built up
            return baseURL;
        }


        //ImageResizing.net URL Helper

    }
}
