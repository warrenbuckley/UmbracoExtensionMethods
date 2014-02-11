using Microsoft.VisualStudio.TestTools.UnitTesting;
using Umbraco.Community.ExtensionMethods.Strings;

namespace UnitTestProject {
    
    [TestClass]
    public class Strings {
        
        [TestMethod]
        public void FirstCharToUpper() {

            Assert.AreEqual("".FirstCharToUpper(), "");
            Assert.AreEqual("bacon".FirstCharToUpper(), "Bacon");
            Assert.AreEqual("hello world".FirstCharToUpper(), "Hello world");
            Assert.AreEqual("Hello World".FirstCharToUpper(), "Hello World");

        }

    
    }

}
