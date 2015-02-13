using System;
using System.Net;
using CoreFXTestLibrary;

namespace HttpWebUtilityTests
{
    [ContractsRequired("System.Runtime, System.Runtime.Extensions")]
    public class WebUtilityTests
    {

        [TestMethod]
        public static void HtmlDecodeWithoutTextWriter()
        {
            // Arrange
            string input = "Hello! &apos;&quot;&lt;&amp;&gt;♥&hearts;ç&#xe7;&#231;";
            string expected = @"Hello! '""<&>♥♥ççç";

            // Act
            string returned = WebUtility.HtmlDecode(input);

            // Assert
            Assert.AreEqual(expected, returned);
        }

        [TestMethod]
        public static  void HtmlDecodeWithoutTextWriterReturnsNullIfInputIsNull()
        {
            // Act
            string returned = WebUtility.HtmlDecode(null);

            // Assert
            Assert.IsNull(returned);
        }

        [TestMethod]
        public static  void HtmlDecodeNoTextWriterOriginalStringNoSpecialCharacters()
        {
            // Arrange
            string input = @"Hello, world! ""<>♥ç";

            // Act
            string returned = WebUtility.HtmlDecode(input);

            // Assert
            Assert.AreEqual(input, returned);
        }

        [TestMethod]
        public static  void HtmlEncodeSingleQuote()
        {
            // Single quotes need to be encoded as &#39; rather than &apos; since &#39; is valid both for
            // HTML and XHTML, but &apos; is valid only for XHTML.
            // For more info: http://fishbowl.pastiche.org/2003/07/01/the_curse_of_apos/

            // Arrange
            string input = "'";
            string expected = "&#39;";

            // Act
            string returned = WebUtility.HtmlEncode(input);

            // Assert
            Assert.AreEqual(expected, returned);
        }

        [TestMethod]
        public static  void HtmlEncodeWithoutTextWriter()
        {
            // Arrange
            string input = @"Hello! '""<&>♥ç";
            string expected = "Hello! &#39;&quot;&lt;&amp;&gt;♥&#231;";

            // Act
            string returned = WebUtility.HtmlEncode(input);

            // Assert
            Assert.AreEqual(expected, returned);
        }

        [TestMethod]
        public static  void HtmlEncodeWithoutTextWriterReturnsNullIfInputIsNull()
        {
            // Act
            string returned = WebUtility.HtmlEncode((string)null);

            // Assert
            Assert.IsNull(returned);
        }

        [TestMethod]
        public static  void HtmlEncodeNoTextWriterOriginalStringNoSpecialCharacters()
        {
            // Arrange
            string input = "Hello, world!";

            // Act
            string returned = WebUtility.HtmlEncode(input);

            // Assert
            Assert.AreEqual(input, returned);
        }

        [TestMethod]
        public static  void UrlDecodeFromStringNoEncodingReturnsNullIfInputIsNull()
        {
            // Act
            string returned = WebUtility.UrlDecode((string)null);

            // Assert
            Assert.IsNull(returned);
        }

        [TestMethod]
        public static  void UrlEncodeFromStringNoEncoding()
        {
            // Recent change brings function inline with RFC 3986 to return hex-encoded chars in uppercase
            // Arrange
            string input = "/\\\"\tHello! ♥?/\\\"\tWorld! ♥?♥";
            string expected = "%2F%5C%22%09Hello!+%E2%99%A5%3F%2F%5C%22%09World!+%E2%99%A5%3F%E2%99%A5";

            // Act
            string returned = WebUtility.UrlEncode(input);

            // Assert
            Assert.AreEqual(expected, returned); 
        }

        [TestMethod]
        public static  void UrlEncodeFromStringNoEncodingReturnsNullIfInputIsNull()
        {
            // Act
            string returned = WebUtility.UrlEncode((string)null);

            // Assert
            Assert.IsNull(returned);
        }

        [TestMethod]
        public static  void UrlEncodeSingleQuote()
        {
            Assert.AreEqual("%27", WebUtility.UrlEncode("'"));
        }

        [TestMethod]
        public static void HtmlDefaultStrictSettingEncode()
        {
            Assert.AreEqual(WebUtility.HtmlEncode(Char.ConvertFromUtf32(144308)),"&#144308;");
        }

        [TestMethod]
        public static void HtmlDefaultStrictSettingDecode()
        {
            Assert.AreEqual(Char.ConvertFromUtf32(144308), WebUtility.HtmlDecode("&#144308;"));
        }
    }
}