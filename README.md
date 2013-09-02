Umbraco Community Extension Methods
========================
This is a community project to create a library of Umbraco Extension Methods to use in Razor files and with the ContentService?

##Umbraco Test Site - Details
* Username: admin
* Password: password

## ASP.NET
* GetMasterPageByType(this Page page, Type type)
* RenderUserControl(this string path, Dictionary<string, object> propertiesToSet = null)

## Content
* .

## DataTypes
* .

## Dates

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
* FormatDateTime(string format) `FormatDateTime("ddd ddS MMMM yyyy")` note the S for suffix
* GetMonthName()
* GetDayName()

## Numeric

* ToInt()
* AbsoluteValue()

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
* RemoveDiacritics(string input)
* StripHtml(bool ignoreParagraphs = true, bool ignoreItalic = true, bool ignoreUnderline = true, bool ignoreBold = true, bool ignoreLinebreak = true, List<string> otherTagsToIgnore = null)
* ShortenHtml(out bool inputIsShortened, int length = 300, string elipsis = "...")
* ShortenHtml(int length = 300, string elipsis = "...")
* GetSentence(sentenceIndex)
* GetParagraph(paragraphIndex) 
* TruncateAtWord(int length)
* InvertCase()
* SubstringBefore(string string2)
* SubstringAfter(string string2)



## Templates
* .

## Users
* GetAllUsers()
* GetUsersByType(int userTypeId)
* GetUsersByType(string typeAlias)
* GetCurrentUserTypes()
* GetCurrentUser()

## Vimeo
* string VimeoEmbed(this int vimeoId, int width, int height)
* string VimeoEmbed(this string vimeoId, int width, int height)
* int GetVimeoDuration(this int vimeoId)
* int GetVimeoDuration(this string vimeoId)
* string GetVimeoThumbnail(this int vimeoId)
* string GetVimeoThumbnail(this string vimeoId)
* string GetVimeoThumbnail(this int vimeoId, VimeoThumbnail size)
* string GetVimeoThumbnail(this string vimeoId, VimeoThumbnail size)


## YouTube
* string GetYouTubeId(this string subject)
* bool GetYouTubeId(this string subject, out string videoId)
* string YouTubeEmbed(this string videoId, int width, int height)
* string YouTubeEmbed(this string videoId, int width, int height, bool showRelations, string wmode)
* string GetYouTubeThumbnail(this string videoId)
* string GetYouTubeThumbnail(this string videoId, int index)


## Do you have any ideas?
Get in touch with me on twitter @warrenbuckley and let's get this project going...
