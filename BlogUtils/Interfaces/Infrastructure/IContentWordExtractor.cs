using System.Collections.Generic;

namespace BlogUtils.Interfaces.Infrastructure
{
    public interface IContentWordExtractor
    {
        (string Topic, IEnumerable<string> Words) GetWordList(string html);
    }
}
