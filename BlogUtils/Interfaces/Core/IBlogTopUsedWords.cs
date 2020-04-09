using System.Collections.Generic;

namespace BlogUtils.Interfaces.Core
{
    public interface IBlogTopUsedWords
    {
        IEnumerable<(string Topic, IEnumerable<string> Words)> GetWordsByFile(string blogFilePath, int contentLimit);

        IEnumerable<(string Topic, List<(string Word, int WordsCount)>)> GetWordsCountByFile(string blogFilePath, int contentLimit, int topWordCount);
    }
}
