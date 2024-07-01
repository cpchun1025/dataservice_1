using System;
using Xunit;

namespace MY_WEB_APP_TEST
{
    public class StringExtensionsTests
    {
        [Theory]
        [InlineData("USDCNY", "USDCNY")]
        [InlineData("CNYUSD", "USDCNY")]
        [InlineData("HKDUSD", "USDHKD")]
        [InlineData("EURJPY", "USDEUR")]
        public void ToUsdFormat_ValidPairs_ReturnsExpected(string input, string expected)
        {
            // Act
            var result = input.ToUsdFormat();

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void ToUsdFormat_NullInput_ThrowsArgumentNullException()
        {
            // Arrange
            string input = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => input.ToUsdFormat());
        }

        [Theory]
        [InlineData("")]
        [InlineData("USDCN")]
        [InlineData("CNYUSDD")]
        [InlineData("INVALID")]
        public void ToUsdFormat_InvalidLengthOrFormat_ThrowsArgumentException(string input)
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => input.ToUsdFormat());
        }
    }
}