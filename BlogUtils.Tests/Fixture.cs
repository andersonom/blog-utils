using System;
using BlogUtils.Core;
using BlogUtils.Infrastructure;
using BlogUtils.Interfaces.Core;
using BlogUtils.Interfaces.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace BlogUtils.Tests
{
    public class Fixture
    {
        public Fixture()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddTransient<IBlogContentReader, BlogContentReader>();
            serviceCollection.AddTransient<IContentWordExtractor, ContentWordExtractor>();
            serviceCollection.AddScoped<IBlogTopUsedWords, BlogTopUsedWords>();

            var loggerFactory = LoggerFactory.Create(builder =>
              {
                  builder
                      .AddFilter("Microsoft", LogLevel.Warning)
                      .AddFilter("System", LogLevel.Warning)
                      .AddFilter("BlogUtils", LogLevel.Debug)
                      .AddConsole();

              });
            serviceCollection.AddSingleton(loggerFactory.CreateLogger<BlogTopUsedWords>());  

            ServiceProvider = serviceCollection.BuildServiceProvider();

            Environment.SetEnvironmentVariable("XML_NAMESPACE", "http://purl.org/rss/1.0/modules/content/");
            Environment.SetEnvironmentVariable("BLOG_FEED_PATH", "..\\..\\..\\feed.xml");
            Environment.SetEnvironmentVariable("BLOG_LANG", "pt-BR");
        }

        public IServiceProvider ServiceProvider { get; set; }
    }
}
