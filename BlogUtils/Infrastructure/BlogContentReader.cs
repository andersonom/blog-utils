using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using BlogUtils.Interfaces.Infrastructure;

namespace BlogUtils.Infrastructure
{
    public class BlogContentReader : IBlogContentReader
    {
        private readonly XNamespace xmlNamespace;
        private const string ContentTag = "encoded";
        public BlogContentReader()
        {
            xmlNamespace = XNamespace.Get(Environment.GetEnvironmentVariable("XML_NAMESPACE") ?? throw new InvalidOperationException("XML_NAMESPACE environment variable was not set"));
        }

        public List<string> GetContentHtmlList(XDocument document, int contentsLimit)
        {
            return document.Descendants(xmlNamespace + ContentTag)
                           .Take(contentsLimit)
                           .ToList()
                           .Select(i => System.Net.WebUtility.HtmlDecode(i.Value))
                           .ToList();
        }
    }
}
