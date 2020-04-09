namespace BlogUtils.Helpers
{
    public static class StopWords
    {
        public static string[] GetStopWords(string lang = null)
        {
            switch (lang)
            {
                case "pt-BR":
                    return new[] { "ainda", "alem", "ambas", "ambos", "antes", "aonde", "pode", "deve", "fazer",
                                          "apos", "aquele", "aqueles", "as", "assim", "com", "como", "contra",
                                          "contudo", "cuja", "cujas", "cujo", "cujos", "dela",
                                          "dele", "deles", "demais", "depois", "desde", "desta", "deste", "dispoe",
                                          "dispoem", "diversa", "diversas", "diversos", "do", "dos", "durante", "e",
                                          "ela", "elas", "ele", "eles", "em", "entao", "entre", "essa", "essas",
                                          "esse", "esses", "esta", "estas", "este", "estes", "ha", "isso", "isto",
                                          "logo", "mais", "mas", "mediante", "menos", "mesma", "mesmas", "mesmo",
                                          "mesmos", "na", "nao", "nas", "nem", "nesse", "neste",
                                          "ou", "outra", "outras", "outro", "outros",
                                          "perante", "pois", "por", "porque", "portanto", "propios", "proprio",
                                          "quais", "qual", "qualquer", "quando", "quanto", "que", "quem", "quer", "se",
                                          "seja", "sem", "sendo", "seu", "seus", "sob", "sobre", "sua", "suas", "tal",
                                          "tambem", "teu", "teus", "toda", "todas", "todo", "todos", "tua", "tuas",
                                          "tudo", "um", "uma", "umas", "uns",
                                          "a", "ao", "aos", "à", "às", "o", "os",
                                          "de", "do", "dos", "da", "das", "dum", "duns", "duma", "dumas",
                                          "em", "no", "nos", "na", "nas", "num", "nuns", "numa", "numas",
                                          "por", "per", "pelo", "pelos", "pela", "pelas",
                                          "para", "é", "não", "foi", "tem", "ser", "muito", "há", "já", "está", "eu",
                                          "também", "só", "até", "era", "ter", "me", "estão", "você", "tinha", "foram",
                                          "meu", "minha", "têm", "havia", "será", "nós", "tenho", "lhe", "fosse", "tu",
                                          "te", "vocês", "vos", "lhes", "meus", "minhas", "nosso", "nossa", "nossos",
                                          "nossas", "delas", "aquela", "aquelas", "aquilo", "estou", "está", "estamos",
                                          "estão", "estive", "esteve", "estivemos", "estiveram", "estava", "estávamos",
                                          "estavam", "estivera", "estivéramos", "esteja", "estejamos", "estejam",
                                          "estivesse", "estivéssemos", "estivessem", "estiver", "estivermos", "estiverem",
                                          "hei", "há", "havemos", "hão", "houve", "houvemos", "houveram", "houvera", "houvéramos",
                                          "haja", "hajamos", "hajam", "houvesse", "houvéssemos", "houvessem", "houver", "houvermos",
                                          "houverem", "houverei", "houverá", "houveremos", "houverão", "houveria", "houveríamos",
                                          "houveriam", "sou", "somos", "são", "era", "éramos", "eram", "fui", "foi", "fomos",
                                          "foram", "fora", "fôramos", "sejamos", "sejam", "fosse", "fôssemos", "fossem", "for",
                                          "formos", "forem", "serei", "será", "seremos", "serão", "seria", "seríamos", "seriam",
                                          "tenho", "tem", "temos", "tém", "tinha", "tínhamos", "tinham", "tive", "teve", "tivemos",
                                          "tiveram", "tivera", "tivéramos", "tenha", "tenhamos", "tenham", "tivesse", "tivéssemos",
                                          "tivessem", "tiver", "tivermos", "tiverem", "terei", "terá", "teremos", "terão", "teria",
                                          "teríamos", "teriam" };
                case "en-EN":
                default:
                    return new[] { "i", "me", "my", "myself", "we", "our", "ours", "ourselves", "you", "your", "yours",
                                          "yourself", "yourselves", "he", "him", "his", "himself", "she", "her", "hers", "herself",
                                          "it", "its", "itself", "they", "them", "their", "theirs", "themselves", "what", "which",
                                          "who","being", "if","between", "in", "out", "where", "why", "how", "all",  "only", "own",
                                          "whom", "this", "that", "these", "those", "am", "is", "are", "was", "were", "be", "been",
                                          "have", "has", "had", "having", "do", "does", "did", "doing", "a", "an", "the", "and", "but",
                                          "or", "because", "as", "until", "while", "of", "at", "by", "for", "with", "about", "against",
                                          "into", "through", "during", "before", "after", "above", "below", "to", "from", "up", "down",
                                          "on", "off", "over", "under", "again", "further", "then", "once", "here", "there", "when",
                                          "any", "both", "each", "few", "more", "most", "other", "some", "such", "no", "nor", "not",
                                          "than", "too", "very", "s", "t", "can", "will", "just", "don", "should", "now", "same", "so"};
            }
        }
    }
}
