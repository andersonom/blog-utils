using BlogUtils.Interfaces.Core;
using System.Collections.Generic;
using System.Xml.Linq;
using BlogUtils.Interfaces.Infrastructure;
using System.Linq;
using System;
using Microsoft.Extensions.Logging;

namespace BlogUtils.Core
{
    public class BlogTopUsedWords : IBlogTopUsedWords
    {
        private readonly IBlogContentReader blogCntRdr;
        private readonly IContentWordExtractor cntWrdExt;
        private readonly ILogger logger;
        public BlogTopUsedWords(IContentWordExtractor cntWrdExt, IBlogContentReader blogCntRdr, ILogger<BlogTopUsedWords> logger)
        {
            this.cntWrdExt = cntWrdExt;
            this.blogCntRdr = blogCntRdr;
            this.logger = logger;
        }

        public IEnumerable<(string Topic, IEnumerable<string> Words)> GetWordsByFile(string blogFilePath, int contentLimit)
        {
            try
            {
                var document = XDocument.Load(blogFilePath);

                var contentList = blogCntRdr.GetContentHtmlList(document, contentLimit);

                var wordsList = new List<(string Topic, IEnumerable<string> Words)>();

                contentList.ForEach(html => wordsList.Add(cntWrdExt.GetWordList(html)));

                return wordsList;
            }
            catch (Exception e)
            {
                logger?.LogError(e, e.Message, "GetWordsByFile({blogFilePath},{contentLimit}) finished with exception", 
                    blogFilePath, contentLimit);
                throw;
            } 
        }

        public IEnumerable<(string Topic, List<(string Word, int WordsCount)>)> GetWordsCountByFile(string blogFilePath, int contentLimit, int topWordCount)
        {
            try
            {
                var wordsList = GetWordsByFile(blogFilePath, contentLimit);

                return wordsList.Select(i => (
                                              Topic: i.Topic,
                                              WordsCount: i.Words.GroupBy(g => g)
                                                                 .Select(w => (Word: w.Key, WordsCount: w.Count()))
                                                                 .OrderByDescending(o => o.WordsCount)
                                                                 .Take(topWordCount)
                                                                 .ToList()
                                            )).ToList();

            }
            catch (Exception e)
            {
                logger?.LogError(e, e.Message, "GetWordsCountByFile({blogFilePath},{contentLimit},{topWordCount}) finished with exception",
                    blogFilePath, contentLimit, topWordCount);
                throw;
            } 
        }
    }
}
