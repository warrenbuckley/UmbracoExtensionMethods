using Microsoft.VisualStudio.TestTools.UnitTesting;
using Umbraco.Community.ExtensionMethods.Strings;

namespace UnitTestProject {
    
    [TestClass]
    public class Strings {

        [TestMethod]
        public void WordCount() {
            
            Assert.AreEqual("".WordCount(), 0);
            Assert.AreEqual("hello world".WordCount(), 2);
            Assert.AreEqual(" hello world ".WordCount(), 2);
            Assert.AreEqual("hello       world".WordCount(), 2);
            Assert.AreEqual("hello world!!!".WordCount(), 2);
            //Assert.AreEqual("S.H.I.E.L.D.".WordCount(), 1); // Current logic consideres this a word per letter. Wrong?
        
        }

        [TestMethod]
        public void FirstCharToUpper() {

            Assert.AreEqual("", "".FirstCharToUpper());
            Assert.AreEqual("Bacon", "bacon".FirstCharToUpper());
            Assert.AreEqual("Hello world", "hello world".FirstCharToUpper());
            Assert.AreEqual("Hello World", "Hello World".FirstCharToUpper());

        }

        [TestMethod]
        public void InvertCase() {

            Assert.AreEqual("hELLOwORLD", "HelloWorld".InvertCase());
            Assert.AreEqual("HELLOWORLD", "helloworld".InvertCase());
            Assert.AreEqual("bACON", "Bacon".InvertCase());

        }
    
    }

}
