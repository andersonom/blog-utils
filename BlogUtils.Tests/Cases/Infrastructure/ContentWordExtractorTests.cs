using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Xml.Linq;
using BlogUtils.Interfaces.Infrastructure;
using Xunit;

namespace BlogUtils.Tests.Cases.Infrastructure
{
    public class ContentWordExtractorTests : IClassFixture<Fixture>
    {
        private readonly IContentWordExtractor cntWrdExt;
        private readonly List<string> content;
        private const int ContentLimit = 10;
        public ContentWordExtractorTests(Fixture fixture)
        {
            cntWrdExt = fixture.ServiceProvider.GetService<IContentWordExtractor>();

            //Arrange
            var blogFeedPath = Environment.GetEnvironmentVariable("BLOG_FEED_PATH");

            var document = XDocument.Load(blogFeedPath);

            content = fixture.ServiceProvider.GetService<IBlogContentReader>()
                                             .GetContentHtmlList(document, ContentLimit);
        }

        [Fact]
        public void ShouldWordListHave8222Count()
        {
            //Sut
            var wordsList = new List<(string topic, IEnumerable<string> Words)>(); 
            
            //Act
            content.ForEach(html => wordsList.Add(cntWrdExt.GetWordList(html)));

            //Assert
            var flattenedContentList = wordsList.SelectMany(i => i.Words).ToList();
            flattenedContentList.Count.Should().Be(8222);
        }
    }
}
