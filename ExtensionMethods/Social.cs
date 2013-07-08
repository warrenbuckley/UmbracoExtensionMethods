using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Umbraco.Community.ExtensionMethods
{
    public static class Social
    {
        //YouTube Embededed Video from VideoID or URL

        //Vimeo Embededed Video from VideoID or URL

        //Gravatar Image URL
        public static string GravtarImageURL(this string emailAddress, string defaultImageURL = "", int size = 80)
        {
            //Check size
            if (size > 512)
            {
                //If bigger than 512, set it to biggest size of 512
                size = 512;
            }

            var hashedEmail = string.Empty;

            //ensure emailAddress is an email
            if (IsValidEmail(emailAddress))
            {
                //MD5 hash the email address
                hashedEmail = GetMd5Hash(emailAddress);
            }

            //Return Gravatar URL
            return string.Format("http://www.gravatar.com/avatar/{0}?s={1}&d={2}", hashedEmail, size, defaultImageURL);
        }

        /// <summary>
        /// Generates an MD5 hash of the given string
        /// </summary>
        /// <remarks>Source: http://msdn.microsoft.com/en-us/library/system.security.cryptography.md5.aspx </remarks>
        private static string GetMd5Hash(string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        public static bool IsValidEmail(string input)
        {
            var pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";
            var regex   = new Regex(pattern, RegexOptions.IgnoreCase);

            return regex.IsMatch(input);
        }


    }
}
