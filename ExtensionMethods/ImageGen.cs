using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Umbraco.Community.ExtensionMethods.ImageGen
{
    public static class ImageGen
    {
        public static string ImageGenUrlFromMediaItem(this Core.Models.Media mediaItem,
            ImageGenAlign? align,
            bool? allowUpsizing,
            bool? antiAlias,
            int? border,
            ImageGenColorMode? colorMode,
            int? compression,
            bool? constrain,
            ImageGenFlip? flip,
            int? fontSize,
            ImageGenFontStyle? fontStyle,
            ImageGenFormat? format,
            int? height,
            int? lineHeight,
            int? maxHeight,
            int? maxWidth,
            bool? noCache,
            int? overlayMargin,
            bool? pad,
            int? rotate,
            bool? transparent,
            ImageGenVAlign? vAlign,
            int? width,
            string altImage = "",
            string bgColor = "",
            string borderColor = "",
            string font = "",
            string fontColor = "",
            string overlayImage = "",
            string text = "")
        {
            //Try and get image upload property alias on media item (umbracoFile)
            var mediaImage = mediaItem.GetValue("umbracoFile").ToString();

            //Check we have a value
            if (!string.IsNullOrEmpty(mediaImage))
            {
                //Now call the main ImageGen method with our values
                ImageGenURL(mediaImage,
                    align,
                    allowUpsizing,
                    antiAlias,
                    border,
                    colorMode,
                    compression,
                    constrain,
                    flip,
                    fontSize,
                    fontStyle,
                    format,
                    height,
                    lineHeight,
                    maxHeight,
                    maxWidth,
                    noCache,
                    overlayMargin,
                    pad,
                    rotate,
                    transparent,
                    vAlign,
                    width,
                    altImage,
                    bgColor,
                    borderColor,
                    font,
                    fontColor,
                    overlayImage,
                    text);
            }

            //Couldn't find the value on the media item, so return empty string
            return string.Empty;
        }

        //ImageGen URL Helper
        public static string ImageGenURL(
            this string imageURL, 
            ImageGenAlign? align,
            bool? allowUpsizing,
            bool? antiAlias,
            int? border,
            ImageGenColorMode? colorMode,
            int? compression,
            bool? constrain,
            ImageGenFlip? flip,
            int? fontSize,
            ImageGenFontStyle? fontStyle,
            ImageGenFormat? format,
            int? height,
            int? lineHeight,
            int? maxHeight,
            int? maxWidth,
            bool? noCache,
            int? overlayMargin,
            bool? pad,
            int? rotate,
            bool? transparent,
            ImageGenVAlign? vAlign,
            int? width,
            string altImage = "",
            string bgColor = "",
            string borderColor = "",
            string font = "",
            string fontColor = "",
            string overlayImage = "",
            string text = ""
           )
        {

            //Base URL to ImageGen ashx handler
            var baseURL = "/imagegen.ashx?";


            //Align (Left, Center, Right, Near, Far)
            if (align != null)
            {
                baseURL += string.Format("&Align={0}", align);
            }

            //Allow Upsizing (True False)
            if (allowUpsizing != null)
            {
                baseURL += string.Format("&AllowUpsizing={0}", allowUpsizing);
            }

            //Alt Image (/photos/waterfall.png)
            if (!string.IsNullOrEmpty(altImage))
            {
                baseURL += string.Format("&AltImage={0}", altImage);
            }

            //AntiAlias (True of False)
            if (antiAlias != null)
            {
                baseURL += string.Format("&AntiAlias={0}", antiAlias);
            }

            //BgColor (FFFFFF)
            if (!string.IsNullOrEmpty(bgColor))
            {
                baseURL += string.Format("&BgColor={0}", bgColor);
            }

            //Border (15)
            if (border != null)
            {
                baseURL += string.Format("&Border={0}", border);
            }

            //BgColor (000000)
            if (!string.IsNullOrEmpty(borderColor))
            {
                baseURL += string.Format("&BorderColor={0}", borderColor);
            }

            //Color Mode (enum)
            if (colorMode != null)
            {
                baseURL += string.Format("&ColorMode={0}", colorMode);
            }

            //Compression 0 to 100 %
            if(compression != null)
            {
                if (compression > 100)
                {
                    compression = 100;
                }

                if (compression < 0)
                {
                    compression = 0;
                }

                baseURL += string.Format("&Compression={0}", compression);
            }

            //Constrain (true/false)
            if(constrain != null)
            {
                baseURL += string.Format("&Constrain={0}", constrain);
            }

            //CROP - TODO?!

            //Flip (x,y,xy)
            if (flip != null)
            {
                baseURL += string.Format("&Flip={0}", flip);
            }


            // ******************************************************************* TODO more to add


            //Height (int)
            if (height != null)
            {
                baseURL += string.Format("&Height={0}", height);
            }
            

            // ******************************************************************* TODO more to add


            //Rotate (0 - 360) int with validation -360 to 360
            if (rotate != null)
            {
                //Check values
                //If larger than 360 set it to 360
                if (rotate > 360)
                {
                    rotate = 360;
                }

                //If larger than minus 360 set it to minus 360
                if (rotate < -360)
                {
                    rotate = -360;
                }

                baseURL += string.Format("&Rotate={0}", rotate);
            }
            

            //Transparent (Bool True of False)
            if (transparent != null)
            {
                baseURL += string.Format("&Transparent={0}", transparent);
            }
            

            //VAlign (Enum Top, Middle, Bottom, Near, Far)
            if (vAlign != null)
            {
                baseURL += string.Format("&VAlign={0}", vAlign);
            }
            

            //Width (int)
            if (width != null)
            {
                baseURL += string.Format("&Width={0}", width);
            }
            

            //URL encode baseURL to ensure it's all OK
            baseURL = HttpUtility.UrlEncode(baseURL);

            //return the URL thats been built up
            return baseURL;
        }

    }

    //ENUMs
    public enum ImageGenAlign
    {
        /// <summary>
        /// Aligns image left
        /// </summary>
        Left,

        /// <summary>
        /// Aligns image center
        /// </summary>
        Center,

        /// <summary>
        /// Aligns image right
        /// </summary>
        Right,

        /// <summary>
        /// Aligns image near
        /// </summary>
        Near,

        /// <summary>
        /// Aligns image far
        /// </summary>
        Far
    }

    public enum ImageGenColorMode
    {
        /// <summary>
        /// Makes image in color
        /// </summary>
        Color,

        // <summary>
        /// Makes image in Grayscale
        /// </summary>
        Grayscale,

        // <summary>
        /// Makes image in Sepia
        /// </summary>
        Sepia 
    }

    public enum ImageGenVAlign
    {
        /// <summary>
        /// Aligns image top
        /// </summary>
        Top,

        /// <summary>
        /// Aligns image middle
        /// </summary>
        Middle,

        /// <summary>
        /// Aligns image bottom
        /// </summary>
        Bottom,

        /// <summary>
        /// Aligns image near
        /// </summary>
        Near,

        /// <summary>
        /// Aligns image far
        /// </summary>
        Far
    }

    public enum ImageGenFlip
    {
        /// <summary>
        /// Flip image on X axis
        /// </summary>
        X,

        /// <summary>
        /// Flip image on Y axis
        /// </summary>
        Y,

        /// <summary>
        /// Flip image on X and Y axis
        /// </summary>
        XY
    }

    public enum ImageGenFormat
    {
        /// <summary>
        /// Ouputs image as JPEG
        /// </summary>
        JPEG,

        /// <summary>
        /// Ouputs image as JPG
        /// </summary>
        JPG,

        /// <summary>
        /// Ouputs image as GIF
        /// </summary>
        GIF,

        /// <summary>
        /// Ouputs image as PNG
        /// </summary>
        PNG,

        /// <summary>
        /// Ouputs image as BMP
        /// </summary>
        BMP,

        /// <summary>
        /// Ouputs image as TIFF
        /// </summary>
        TIFF,

        /// <summary>
        /// Ouputs image as TIF 
        /// </summary>
        TIF
    }

    public enum ImageGenFontStyle
    {
        /// <summary>
        /// Font weight - Regular
        /// </summary>
        Regular,

        /// <summary>
        /// Font weight - Bold
        /// </summary>
        Bold,

        /// <summary>
        /// Font weight - Italic
        /// </summary>
        Italic,

        /// /// <summary>
        /// Font weight - Underline
        /// </summary>
        Underline,

        /// <summary>
        /// Font weight - Strikeout 
        /// </summary>
        Strikeout
    }
}
