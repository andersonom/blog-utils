using BlogUtils.Helpers;
using HtmlAgilityPack;
using System.Collections.Generic;
using System.Linq;
using System;
using BlogUtils.Interfaces.Infrastructure;

namespace BlogUtils.Infrastructure
{
    public class ContentWordExtractor : IContentWordExtractor
    {
        private readonly char[] invalidChars = { ' ', '\n', '/', '.', ',', ';', '?', '!', ')',
                                                 '(', '\'', '\"', '\0', ':', '”', '—', '“', '–' };

        private readonly string[] stopWords = StopWords.GetStopWords(Environment.GetEnvironmentVariable("BLOG_LANG"));

        public (string Topic, IEnumerable<string> Words) GetWordList(string html)
        {
            var lst = new List<string>(); 
            var htmlDoc = new HtmlDocument();

            htmlDoc.LoadHtml(html);

            var topic = htmlDoc.DocumentNode.Descendants()
                                            .Where(i => i.NodeType == HtmlNodeType.Element)
                                            .Reverse()
                                            .Skip(1)
                                            .FirstOrDefault().InnerText;

            foreach (var nNode in htmlDoc.DocumentNode.Descendants())
            {
                if (nNode.NodeType == HtmlNodeType.Element)
                {
                    lst.AddRange(nNode.InnerText
                        .ToLower()
                        .Split(invalidChars)
                        .Where(i => !string.IsNullOrWhiteSpace(i) && !stopWords.Contains(i))
                        .ToList());
                }
            }

            return (Topic: topic, Words: lst);
        }
    }
}
