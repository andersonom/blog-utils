using System.Collections.Generic;
using System.Xml.Linq;

namespace BlogUtils.Interfaces.Infrastructure
{
    public interface IBlogContentReader
    {
        List<string> GetContentHtmlList(XDocument doc, int contentsLimit);
    }
}
