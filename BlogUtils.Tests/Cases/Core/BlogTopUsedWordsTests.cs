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
                                            "mente", "oferecer", "seguro", "vida", "grupo", "funcion�rios", "maneira", "ficam", "protegidos", "caso" };

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
             ("funcion�rios", 6),
             ("coberturas", 6),
             ("benef�cio", 6),
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
         ("Diferen�as entre Plano de Sa�de e Seguro Sa�de: descubra quais s�o e saiba por qual optar",
            new List<(string Word, int WordsCount)>() {
             ("sa�de", 59),
             ("seguro", 34),
             ("plano", 26),
             ("diferen�as", 10),
             ("servi�os", 7),
             ("segurado", 6),
             ("pr�mio", 6),
             ("mensalidade", 5),
             ("seguros", 5),
             ("empresas", 4)
            }),
         ("5 motivos para n�o cancelar seu Seguro Auto agora",
            new List<(string Word, int WordsCount)>() {
             ("seguro", 57),
             ("ve�culo", 22),
             ("carro", 20),
             ("cancelar", 18),
             ("caso", 14),
             ("assist�ncia", 11),
             ("auto", 11),
             ("b�nus", 11),
             ("exemplo", 10),
             ("ap�lice", 10),
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
         ("Seguro de Vida: como funciona e por que voc� deve ter?",
            new List<(string Word, int WordsCount)>() {
             ("seguro", 82),
             ("vida", 79),
             ("segurado", 42),
             ("acidente", 34),
             ("cobertura", 24),
             ("valor", 20),
             ("invalidez", 18),
             ("ap�lice", 18),
             ("coberturas", 16),
             ("fam�lia", 16)
            }),
         ("Por que contratar um Seguro Residencial: 6 motivos que com certeza v�o te convencer",
            new List<(string Word, int WordsCount)>() {
             ("seguro", 34),
             ("residencial", 26),
             ("contratar", 16),
             ("resid�ncia", 6),
             ("motivos", 5),
             ("coberturas", 5),
             ("servi�os", 5),
             ("minuto", 5),
             ("seguros", 5),
             ("convencer", 4)
            }),
         ("Seguro auto anual ou plurianual: quais as diferen�as?",
            new List<(string Word, int WordsCount)>() {
             ("seguro", 39),
             ("anual", 34),
             ("plurianual", 32),
             ("auto", 25),
             ("vig�ncia", 14),
             ("segurado", 12),
             ("ano", 12),
             ("pagamento", 12),
             ("contrata��o", 10),
             ("cada", 10)
            }),
        ("Seguro viagem para esportes: descubra como montar o seu",
            new List<(string Word, int WordsCount)>() {
             ("viagem", 35),
             ("esportes", 32),
             ("seguro", 31),
             ("pa�s", 10),
             ("caso", 10),
             ("cobertura", 8),
             ("turista", 8),
             ("necessidade", 7),
             ("prote��o", 6),
             ("exemplo", 6),
            }),
        ("Europa fecha fronteiras: o que fazer se estiver por l�?",
            new List<(string Word, int WordsCount)>() {
             ("viagem", 29),
             ("fronteiras", 28),
             ("seguro", 25),
             ("europa", 22),
             ("pa�ses", 18),
             ("coronav�rus", 15),
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
