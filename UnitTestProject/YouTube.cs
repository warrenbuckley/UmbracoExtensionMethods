using Microsoft.VisualStudio.TestTools.UnitTesting;
using Umbraco.Community.ExtensionMethods.YouTube;

namespace UnitTestProject {
    
    [TestClass]
    public class YouTube {

        [TestMethod]
        public void GetYouTubeId() {

            Assert.IsNull(YouTubeHelpers.GetIdFromString("123"));

            // Mest test URLs from https://gist.github.com/FinalAngel/1876898

            Assert.AreEqual("dQw4w9WgXcQ", YouTubeHelpers.GetIdFromString("http://www.youtube.com/watch?v=dQw4w9WgXcQ"));
            Assert.AreEqual("1p3vcRhsYGo", YouTubeHelpers.GetIdFromString("http://www.youtube.com/user/Scobleizer#p/u/1/1p3vcRhsYGo"));
            Assert.AreEqual("1p3vcRhsYGo", YouTubeHelpers.GetIdFromString("http://www.youtube.com/user/Scobleizer#p/u/1/1p3vcRhsYGo?rel=0"));
            Assert.AreEqual("yZ-K7nCVnBI", YouTubeHelpers.GetIdFromString("http://www.youtube.com/watch?v=yZ-K7nCVnBI&playnext_from=TL&videos=osPknwzXEas&feature=sub"));
            Assert.AreEqual("NRHVzbJVx8I", YouTubeHelpers.GetIdFromString("http://www.youtube.com/ytscreeningroom?v=NRHVzbJVx8I"));
            Assert.AreEqual("6dwqZw0j_jY", YouTubeHelpers.GetIdFromString("http://youtu.be/6dwqZw0j_jY"));
            Assert.AreEqual("6dwqZw0j_jY", YouTubeHelpers.GetIdFromString("http://www.youtube.com/watch?v=6dwqZw0j_jY&feature=youtu.be"));
            Assert.AreEqual("afa-5HQHiAs", YouTubeHelpers.GetIdFromString("http://youtu.be/afa-5HQHiAs"));
            Assert.AreEqual("cKZDdG9FTKY", YouTubeHelpers.GetIdFromString("http://www.youtube.com/watch?v=cKZDdG9FTKY&feature=channel"));
            Assert.AreEqual("nas1rJpm7wY", YouTubeHelpers.GetIdFromString("http://www.youtube.com/embed/nas1rJpm7wY?rel=0"));
            Assert.AreEqual("peFZbP64dsU", YouTubeHelpers.GetIdFromString("http://www.youtube.com/watch?v=peFZbP64dsU"));
        
        }
    
    }

}
