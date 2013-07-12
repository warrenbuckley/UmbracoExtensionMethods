using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Umbraco.Core;
using Umbraco.Core.Models;
using Umbraco.Web;

namespace Umbraco.Community.ExtensionMethods.ImageGen
{
    public static class ImageGen
    {
        /// <summary>
        /// Generate an ImageGen URL from a Media Item
        /// </summary>
        /// <param name="mediaItem">The media item (iPublishedContent)</param>
        /// <param name="align">The horizontal alignment of the overlay image or text</param>
        /// <param name="allowUpsizing">Allow the image to be upsized</param>
        /// <param name="antiAlias">Boolean to allow the image to be Anti Aliased</param>
        /// <param name="border">Pass in a int to specifiy the border width</param>
        /// <param name="colorMode">The colour mode of the image (colour, greyscale, sepia)</param>
        /// <param name="compression">A percentage scale of the amount of compression to apply to the image</param>
        /// <param name="constrain">A boolean if to constrain the width and height of the image</param>
        /// <param name="flip">Apply x, y or x & y flipping of the image</param>
        /// <param name="fontSize">An int of the size of the font to be applied to the image</param>
        /// <param name="fontStyle">The font style such as bold, italic to be applied to the image</param>
        /// <param name="format">The output format of the image to be served, such as gif, jpb, png or tiff</param>
        /// <param name="height">The height of the image you want it to be resized to</param>
        /// <param name="lineHeight">An int of the lineheight used in conjuction with text & font params</param>
        /// <param name="maxHeight">An int of the max height of the image</param>
        /// <param name="maxWidth">An int of the max width of the image</param>
        /// <param name="noCache">A boolean to ensure the image is not cached</param>
        /// <param name="overlayMargin">An int to apply a margin to the overlay item, such as text or image</param>
        /// <param name="pad">An int to apply padding to the image</param>
        /// <param name="rotate">The number of degrees to rotate the image by</param>
        /// <param name="transparent">A bool to ensure the image is returned as transparent or not</param>
        /// <param name="vAlign">The vertical alignment of the overlay image or text</param>
        /// <param name="width">The width of the image you want it to be resized to</param>
        /// <param name="altImage">A path to an alternative image if the original image is not found</param>
        /// <param name="bgColor">The string of the Hexadecimal color value for the background of the image</param>
        /// <param name="borderColor">The string of the Hexadecimal color value for the border color</param>
        /// <param name="font">The path or the name of the font installed on the server</param>
        /// <param name="fontColor">The string of the Hexadecimal color value for the font</param>
        /// <param name="overlayImage">A path to the image you wish to display over the top of the image, such as PNG watermark</param>
        /// <param name="text">The text you wish to display over the top of the image</param>
        /// <param name="uploadPropertyAlias">If you are using a custom media type and need to change the upload property alias to something else apart from umbracoFile</param>
        /// <returns>A string to the ImageGen Url with the parameters passed in</returns>
        public static string ImageGenUrl(this IPublishedContent mediaItem,
            ImageGenAlign? align = null,
            bool? allowUpsizing = null,
            bool? antiAlias = null,
            int? border = null,
            ImageGenColorMode? colorMode = null,
            int? compression = null,
            bool? constrain = null,
            ImageGenFlip? flip = null,
            int? fontSize = null,
            ImageGenFontStyle? fontStyle = null,
            ImageGenFormat? format = null,
            int? height = null,
            int? lineHeight = null,
            int? maxHeight = null,
            int? maxWidth = null,
            bool? noCache = null,
            int? overlayMargin = null,
            bool? pad = null,
            int? rotate = null,
            bool? transparent = null,
            ImageGenVAlign? vAlign = null,
            int? width = null,
            string altImage = "",
            string bgColor = "",
            string borderColor = "",
            string font = "",
            string fontColor = "",
            string overlayImage = "",
            string text = "",
            string uploadPropertyAlias = "umbracoFile"
            )
        {
            //Try and get image upload property alias on media item (umbracoFile)
            var mediaImage = String.Empty;
            if (mediaItem.HasProperty(uploadPropertyAlias))
            {
                mediaImage = mediaItem.GetPropertyValue<string>(uploadPropertyAlias);
            }

            //Check we have a value
            if (!string.IsNullOrEmpty(mediaImage))
            {
                //Now call the main ImageGen method with our values
                return ImageGenUrl(mediaImage,
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
        /// <summary>
        /// Generate an ImageGen URL from a Media Item
        /// </summary>
        /// <param name="imageUrl">The string that is storing the image path</param>
        /// <param name="align">The horizontal alignment of the overlay image or text</param>
        /// <param name="allowUpsizing">Allow the image to be upsized</param>
        /// <param name="antiAlias">Boolean to allow the image to be Anti Aliased</param>
        /// <param name="border">Pass in a int to specifiy the border width</param>
        /// <param name="colorMode">The colour mode of the image (colour, greyscale, sepia)</param>
        /// <param name="compression">A percentage scale of the amount of compression to apply to the image</param>
        /// <param name="constrain">A boolean if to constrain the width and height of the image</param>
        /// <param name="flip">Apply x, y or x & y flipping of the image</param>
        /// <param name="fontSize">An int of the size of the font to be applied to the image</param>
        /// <param name="fontStyle">The font style such as bold, italic to be applied to the image</param>
        /// <param name="format">The output format of the image to be served, such as gif, jpb, png or tiff</param>
        /// <param name="height">The height of the image you want it to be resized to</param>
        /// <param name="lineHeight">An int of the lineheight used in conjuction with text & font params</param>
        /// <param name="maxHeight">An int of the max height of the image</param>
        /// <param name="maxWidth">An int of the max width of the image</param>
        /// <param name="noCache">A boolean to ensure the image is not cached</param>
        /// <param name="overlayMargin">An int to apply a margin to the overlay item, such as text or image</param>
        /// <param name="pad">An int to apply padding to the image</param>
        /// <param name="rotate">The number of degrees to rotate the image by</param>
        /// <param name="transparent">A bool to ensure the image is returned as transparent or not</param>
        /// <param name="vAlign">The vertical alignment of the overlay image or text</param>
        /// <param name="width">The width of the image you want it to be resized to</param>
        /// <param name="altImage">A path to an alternative image if the original image is not found</param>
        /// <param name="bgColor">The string of the Hexadecimal color value for the background of the image</param>
        /// <param name="borderColor">The string of the Hexadecimal color value for the border color</param>
        /// <param name="font">The path or the name of the font installed on the server</param>
        /// <param name="fontColor">The string of the Hexadecimal color value for the font</param>
        /// <param name="overlayImage">A path to the image you wish to display over the top of the image, such as PNG watermark</param>
        /// <param name="text">The text you wish to display over the top of the image</param>
        /// <returns>A string to the ImageGen Url with the parameters passed in</returns>
        public static string ImageGenUrl(
            this string imageUrl, 
            ImageGenAlign? align = null,
            bool? allowUpsizing = null,
            bool? antiAlias = null,
            int? border = null,
            ImageGenColorMode? colorMode = null,
            int? compression = null,
            bool? constrain = null,
            ImageGenFlip? flip = null,
            int? fontSize = null,
            ImageGenFontStyle? fontStyle = null,
            ImageGenFormat? format = null,
            int? height = null,
            int? lineHeight = null,
            int? maxHeight = null,
            int? maxWidth = null,
            bool? noCache = null,
            int? overlayMargin = null,
            bool? pad = null,
            int? rotate = null,
            bool? transparent = null,
            ImageGenVAlign? vAlign = null,
            int? width = null,
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
            var baseUrl = "/imagegen.ashx?image=" + imageUrl;


            //Align (Left, Center, Right, Near, Far)
            if (align != null)
            {
                baseUrl += string.Format("&Align={0}", align);
            }

            //Allow Upsizing (True False)
            if (allowUpsizing != null)
            {
                baseUrl += string.Format("&AllowUpsizing={0}", allowUpsizing);
            }

            //Alt Image (/photos/waterfall.png)
            if (!string.IsNullOrEmpty(altImage))
            {
                baseUrl += string.Format("&AltImage={0}", altImage);
            }

            //AntiAlias (True of False)
            if (antiAlias != null)
            {
                baseUrl += string.Format("&AntiAlias={0}", antiAlias);
            }

            //BgColor (FFFFFF)
            if (!string.IsNullOrEmpty(bgColor))
            {
                baseUrl += string.Format("&BgColor={0}", bgColor);
            }

            //Border (15)
            if (border != null)
            {
                baseUrl += string.Format("&Border={0}", border);
            }

            //BgColor (000000)
            if (!string.IsNullOrEmpty(borderColor))
            {
                baseUrl += string.Format("&BorderColor={0}", borderColor);
            }

            //Color Mode (enum)
            if (colorMode != null)
            {
                baseUrl += string.Format("&ColorMode={0}", colorMode);
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

                baseUrl += string.Format("&Compression={0}", compression);
            }

            //Constrain (true/false)
            if(constrain != null)
            {
                baseUrl += string.Format("&Constrain={0}", constrain);
            }

            //CROP - TODO?!

            //Flip (x,y,xy)
            if (flip != null)
            {
                baseUrl += string.Format("&Flip={0}", flip);
            }


            // ******************************************************************* TODO more to add


            //Height (int)
            if (height != null)
            {
                baseUrl += string.Format("&Height={0}", height);
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

                baseUrl += string.Format("&Rotate={0}", rotate);
            }
            

            //Transparent (Bool True of False)
            if (transparent != null)
            {
                baseUrl += string.Format("&Transparent={0}", transparent);
            }
            

            //VAlign (Enum Top, Middle, Bottom, Near, Far)
            if (vAlign != null)
            {
                baseUrl += string.Format("&VAlign={0}", vAlign);
            }
            

            //Width (int)
            if (width != null)
            {
                baseUrl += string.Format("&Width={0}", width);
            }


            //URL encode baseUrl to ensure it's all OK
            baseUrl = HttpUtility.HtmlEncode(baseUrl);

            //return the URL thats been built up
            return baseUrl;
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

        /// <summary>
        /// Makes image in Grayscale
        /// </summary>
        Grayscale,

        /// <summary>
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
