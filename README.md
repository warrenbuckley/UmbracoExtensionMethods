Umbraco Community Extension Methods
========================
This is a community project to create a library of Umbraco Extension Methods to use in Razor files and with the ContentService?

## ASP.NET
* GetMasterPageByType(this Page page, Type type)
* RenderUserControl(this string path, Dictionary<string, object> propertiesToSet = null)

## Content
* .

## DataTypes
* .

## Dates
Kudos to the uComponents team for these methods. So kudos for these methods go to them.

* Age()
* GetDayNumber()
* IsWeekday()
* IsWeekend()
* IsLeapYear()
* ElapsedSeconds()
* DateWithinLastDays(int days)
* ToUnixTime()
* GetFirstDayOfMonth()
* GetLastDayOfMonth()
* PrettyDate()


## DocumentTypes
* .

## ImageGen
* .

## ImageResizing
* .

## Media
* .

## MediaTypes
* .

## Members
* .

## Social
* GravatarImageURL(string defaultImageURL, int size)

## Strings
* FirstCharToUpper()
* HighlightKeywords(IEnumerable<string> keywords, string className)
* StripHTML(bool ignoreParagraphs = true, bool ignoreItalic = true, bool ignoreUnderline = true, bool ignoreBold = true, bool ignoreLinebreak = true, List<string> otherTagsToIgnore = null)
* ShortenHTML(out bool inputIsShortened, int length = 300, string elipsis = "...")
* ShortenHTML(int length = 300, string elipsis = "...")

## Templates
* .

## Users
* .

## Vimeo
* VimeoEmbed(int width, int height)


## YouTube
* .


## Do you have any ideas?
Get in touch with me on twitter @warrenbuckley and let's get this project going...
