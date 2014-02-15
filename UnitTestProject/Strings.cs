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

            Assert.AreEqual("".FirstCharToUpper(), "");
            Assert.AreEqual("bacon".FirstCharToUpper(), "Bacon");
            Assert.AreEqual("hello world".FirstCharToUpper(), "Hello world");
            Assert.AreEqual("Hello World".FirstCharToUpper(), "Hello World");

        }

        [TestMethod]
        public void InvertCase() {

            Assert.AreEqual("HelloWorld".InvertCase(), "hELLOwORLD");
            Assert.AreEqual("helloworld".InvertCase(), "HELLOWORLD");
            Assert.AreEqual("Bacon".InvertCase(), "bACON");

        }
    
    }

}
