using GzipSimplSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace GzipSimplSharpTest
{
    /// <summary>
    ///This is a test class for GzipTest and is intended
    ///to contain all GzipTest Unit Tests
    ///</summary>
    [TestClass()]
    public class GzipTest
    {
        /// <summary>
        ///A test for Decompress
        ///</summary>
        [TestMethod()]
        public void DecompressTest()
        {
            Gzip target = new Gzip();
            string str = "\u001F\u008B\u0008\u0000\u0000\u0000\u0000\u0000\u0000\u0003\u00CB\u0048\u00CD\u00C9\u00C9\u0057\u0028\u00CF\u002F\u00CA\u0049\u0051\u0004\u0000\u006D\u00C2\u00B4\u0003\u000C\u0000\u0000\u0000";
            string expected = "hello world!";
            string actual;
            actual = target.Decompress(str);
            Assert.AreEqual(expected, actual);
        }
    }
}
