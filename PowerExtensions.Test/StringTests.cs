using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PowerExtensions.Test
{
    [TestClass]
    public class StringTests
    {
        [TestMethod]
        public void IsNullOrEmptyTest()
        {
            string rat = null;
            Assert.IsTrue(rat.IsNullOrEmpty());

            rat = string.Empty;
            Assert.IsTrue(rat.IsNullOrEmpty());
        }

        [TestMethod]
        public void ContainsTest()
        {
            string text = "a quick brown fox jumps over the lazy dog";
            string find = "FOX";

            Assert.IsTrue(text.Contains(find, System.StringComparison.OrdinalIgnoreCase));
        }

        [TestMethod]
        public void ContainsAnyTest()
        {
            char[] vowels = new char[] { 'a', 'e', 'i', 'o', 'u' };

            // False Test
            string text = "qck brwn fx jmps vr th lzy dg";
            Assert.IsFalse(text.ContainsAny(vowels));

            // True Test
            text = "a quick brown fox jumps over the lazy dog";
            Assert.IsTrue(text.ContainsAny(vowels));

        }

        [TestMethod]
        public void ContainsAnyCaseInsensitiveTest()
        {
            char[] vowels = new char[] { 'A', 'E', 'I', 'O', 'U' };

            // False Test
            string text = "qck brwn fx jmps vr th lzy dg";
            Assert.IsFalse(text.ContainsAny(vowels, System.StringComparison.OrdinalIgnoreCase));

            // True Test
            text = "a quick brown fox jumps over the lazy dog";
            Assert.IsTrue(text.ContainsAny(vowels, System.StringComparison.OrdinalIgnoreCase));
        }
    }
}
