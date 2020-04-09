using Microsoft.Extensions.DependencyInjection;
using System;
using BlogUtils.Interfaces.Core;
using Xunit;
using System.Collections.Generic;
using FluentAssertions;
using System.Linq;

namespace BlogUtils.Tests.Cases.Core
{
    public class BlogTopUsedWordsTests : IClassFixture<Fixture>
    {
        private readonly IBlogTopUsedWords blogTopUsedWords;
        private readonly string blogFeedPath = Environment.GetEnvironmentVariable("BLOG_FEED_PATH");

        public BlogTopUsedWordsTests(Fixture fixture)
        {
            blogTopUsedWords = fixture.ServiceProvider.GetService<IBlogTopUsedWords>();
        }

        [Fact]
        public void ShoudBlogHaveExpectedFirstTop20Words()
        {
            //Arrange
            var expectedFirstTop20 = new[]{ "muitos", "dizem", "empresa", "reflexo", "colaboradores", "cuidar", "equipe", "trabalho", "fundamental", "gestor",
                                            "mente", "oferecer", "seguro", "vida", "grupo", "funcionários", "maneira", "ficam", "protegidos", "caso" };

            //Act
            var res = blogTopUsedWords.GetWordsByFile(blogFeedPath, 10);

            //Assert
            var firstTop20res = res.First().Words.Take(20).ToList();
            firstTop20res.Should().BeEquivalentTo(expectedFirstTop20.ToList());
        }

        [Fact]
        public void ShoudBlogHaveExpectedTop10WordCount()
        {
            //Arrange
            var expected =
            #region Expected Object Arranged
         new List<(string Topic, List<(string Word, int WordsCount)>)>() {
         ("Seguro de Vida em Grupo: qual o conceito e como funciona?",
         new List<(string Word, int WordsCount)>() {
             ("seguro", 31),
             ("vida", 28),
             ("grupo", 18),
             ("empresa", 7),
             ("funciona", 7),
             ("trabalho", 6),
             ("funcionários", 6),
             ("coberturas", 6),
             ("benefício", 6),
             ("colaboradores", 5) }),
         ("6 dicas para se adaptar ao home office",
            new List<(string Word, int WordsCount)>() {
            ("trabalho", 24),
             ("casa", 20),
             ("manter", 14),
             ("vai", 12),
             ("home", 10),
             ("office", 10),
             ("dia", 10),
             ("trabalhar", 10),
             ("seguro", 10),
             ("ajudar", 8)
            }),
         ("Diferenças entre Plano de Saúde e Seguro Saúde: descubra quais são e saiba por qual optar",
            new List<(string Word, int WordsCount)>() {
             ("saúde", 59),
             ("seguro", 34),
             ("plano", 26),
             ("diferenças", 10),
             ("serviços", 7),
             ("segurado", 6),
             ("prêmio", 6),
             ("mensalidade", 5),
             ("seguros", 5),
             ("empresas", 4)
            }),
         ("5 motivos para não cancelar seu Seguro Auto agora",
            new List<(string Word, int WordsCount)>() {
             ("seguro", 57),
             ("veículo", 22),
             ("carro", 20),
             ("cancelar", 18),
             ("caso", 14),
             ("assistência", 11),
             ("auto", 11),
             ("bônus", 11),
             ("exemplo", 10),
             ("apólice", 10),
            }),
         ("Seguro para carro: veja mitos e verdades sobre o produto",
            new List<(string Word, int WordsCount)>() {
             ("seguro", 42),
             ("carro", 30),
             ("seguros", 13),
             ("mitos", 12),
             ("verdades", 12),
             ("barato", 11),
             ("verdade", 10),
             ("carros", 10),
             ("geral", 8),
             ("mulheres", 8)
            }),
         ("Seguro de Vida: como funciona e por que você deve ter?",
            new List<(string Word, int WordsCount)>() {
             ("seguro", 82),
             ("vida", 79),
             ("segurado", 42),
             ("acidente", 34),
             ("cobertura", 24),
             ("valor", 20),
             ("invalidez", 18),
             ("apólice", 18),
             ("coberturas", 16),
             ("família", 16)
            }),
         ("Por que contratar um Seguro Residencial: 6 motivos que com certeza vão te convencer",
            new List<(string Word, int WordsCount)>() {
             ("seguro", 34),
             ("residencial", 26),
             ("contratar", 16),
             ("residência", 6),
             ("motivos", 5),
             ("coberturas", 5),
             ("serviços", 5),
             ("minuto", 5),
             ("seguros", 5),
             ("convencer", 4)
            }),
         ("Seguro auto anual ou plurianual: quais as diferenças?",
            new List<(string Word, int WordsCount)>() {
             ("seguro", 39),
             ("anual", 34),
             ("plurianual", 32),
             ("auto", 25),
             ("vigência", 14),
             ("segurado", 12),
             ("ano", 12),
             ("pagamento", 12),
             ("contratação", 10),
             ("cada", 10)
            }),
        ("Seguro viagem para esportes: descubra como montar o seu",
            new List<(string Word, int WordsCount)>() {
             ("viagem", 35),
             ("esportes", 32),
             ("seguro", 31),
             ("país", 10),
             ("caso", 10),
             ("cobertura", 8),
             ("turista", 8),
             ("necessidade", 7),
             ("proteção", 6),
             ("exemplo", 6),
            }),
        ("Europa fecha fronteiras: o que fazer se estiver por lá?",
            new List<(string Word, int WordsCount)>() {
             ("viagem", 29),
             ("fronteiras", 28),
             ("seguro", 25),
             ("europa", 22),
             ("países", 18),
             ("coronavírus", 15),
             ("contato", 12),
             ("fecha", 10),
             ("covid-19", 8),
             ("dia", 8)
            })
         };
            #endregion

            //Act
            var res = blogTopUsedWords.GetWordsCountByFile(blogFeedPath, 10, 10);

            //Assert
            res.Should().BeEquivalentTo(expected);
        }
    }
}
