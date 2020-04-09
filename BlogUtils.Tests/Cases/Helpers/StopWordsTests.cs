using BlogUtils.Helpers;
using FluentAssertions;
using Xunit;

namespace BlogUtils.Tests.Cases.Helpers
{
    public class StopWordsTests
    {
        [InlineData("pt-BR", 296)]
        [InlineData("en-EN", 127)]
        [InlineData(null, 127)]
        [Theory]
        public void StopWordsShouldHave(string lang, int wordCount)
        {
            var words = StopWords.GetStopWords(lang);
            words.Should().HaveCount(wordCount);
        }
    }
}
