using System;
using System.Linq;
using System.Xml.Linq;
using BlogUtils.Interfaces.Infrastructure;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace BlogUtils.Tests.Cases.Infrastructure
{
    public class BlogContentReaderTests : IClassFixture<Fixture>
    {
        private readonly IBlogContentReader blogCntRdr;
        public BlogContentReaderTests(Fixture fixture)
        {
            blogCntRdr = fixture.ServiceProvider.GetService<IBlogContentReader>();
        }

        [InlineData(1, 7050)]
        [InlineData(10, 96279)]
        [Theory]
        public void ShouldHaveStringLength(int blogContentLimit, int htmlStringLength)
        {
            //Arrange
            var blogFeedPath = Environment.GetEnvironmentVariable("BLOG_FEED_PATH");
            var document = XDocument.Load(blogFeedPath);

            //Act             
            var contentList = blogCntRdr.GetContentHtmlList(document, blogContentLimit);

            //Assert
            contentList.Aggregate((current, next) => current + string.Empty + next)
                       .Length.Should().Be(htmlStringLength);
        }
    }
}
