using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Reflection;
using System.Collections;

namespace br.com.devdream.encurtador.bo.teste
{
    [TestFixture]
    public static class Url
    {
        [Test]
        public static void Criar()
        {
            string endereco = "http://www.google.com.br/search?sourceid=chrome&ie=UTF-8&q=oscar+casagrande";
            string ip = "127.0.0.1";
            string chaveEsperada = "aaaa";
            string chaveGerada = string.Empty;
            chaveGerada = bo.Url.Criar(endereco, ip);
            Assert.AreEqual(chaveEsperada, chaveGerada);
        }

        [Test]
        public static void ValidarEnderecoCorreto()
        {
            string endereco = "http://www.google.com.br/search?sourceid=chrome&ie=UTF-8&q=oscar+casagrande";
            bool validoEsperado = true;
            bool validoGerado = false;
            validoGerado = bo.Url.ValidarEndereco(endereco);
            Assert.AreEqual(validoEsperado, validoGerado);
        }

        [Test]
        public static void ValidarEnderecoErrado()
        {
            string endereco = "http://w,ww.google.com.br/search?sourceid=chrome&ie=UTF-8&q=oscar+casagrande";
            bool validoEsperado = false;
            bool validoGerado = false;
            validoGerado = bo.Url.ValidarEndereco(endereco);
            Assert.AreEqual(validoEsperado, validoGerado);
        }

        [Test]
        public static void ObterCaractereEleitoUm()
        {
            short caractereELeitoEsperado = 1;
            short caractereEleitoGerado = 0;
            string chave = "a999";

            string caractereUm = string.Empty;
            string caractereDois = string.Empty;
            string caractereTres = string.Empty;
            string caractereQuatro = string.Empty;

            caractereEleitoGerado = bo.Url.ObterCaractereEleito(chave, out caractereUm, out caractereDois, out caractereTres, out caractereQuatro);

            Assert.AreEqual(caractereELeitoEsperado, caractereEleitoGerado);
        }

        [Test]
        public static void ObterCaractereEleitoDois()
        {
            short caractereELeitoEsperado = 2;
            short caractereEleitoGerado = 0;
            string chave = "aa99";

            string caractereUm = string.Empty;
            string caractereDois = string.Empty;
            string caractereTres = string.Empty;
            string caractereQuatro = string.Empty;

            caractereEleitoGerado = bo.Url.ObterCaractereEleito(chave, out caractereUm, out caractereDois, out caractereTres, out caractereQuatro);

            Assert.AreEqual(caractereELeitoEsperado, caractereEleitoGerado);
        }

        [Test]
        public static void ObterCaractereEleitoTres()
        {
            short caractereELeitoEsperado = 3;
            short caractereEleitoGerado = 0;
            string chave = "aaa9";

            string caractereUm = string.Empty;
            string caractereDois = string.Empty;
            string caractereTres = string.Empty;
            string caractereQuatro = string.Empty;

            caractereEleitoGerado = bo.Url.ObterCaractereEleito(chave, out caractereUm, out caractereDois, out caractereTres, out caractereQuatro);

            Assert.AreEqual(caractereELeitoEsperado, caractereEleitoGerado);
        }

        [Test]
        public static void ObterCaractereEleitoQuatro()
        {
            short caractereELeitoEsperado = 4;
            short caractereEleitoGerado = 0;
            string chave = "aaaa";

            string caractereUm = string.Empty;
            string caractereDois = string.Empty;
            string caractereTres = string.Empty;
            string caractereQuatro = string.Empty;

            caractereEleitoGerado = bo.Url.ObterCaractereEleito(chave, out caractereUm, out caractereDois, out caractereTres, out caractereQuatro);

            Assert.AreEqual(caractereELeitoEsperado, caractereEleitoGerado);
        }

        [Test]
        public static void Existe()
        {
            bool existeEsperado = true;
            bool existeGerado = false;
            existeGerado = bo.Url.Existe("http://www.google.com.br/search?sourceid=chrome&ie=UTF-8&q=oscar+casagrande");
            Assert.AreEqual(existeGerado, existeEsperado);
        }

        [Test]
        public static void Obter()
        {
            vo.Url urlEsperada = new vo.Url()
            {
                Chave = "aaaa",
                Encurtada = "http://localhost:56778/aaaa",
                Ip = "",
                Original = "http://www.google.com.br/search?sourceid=chrome&ie=UTF-8&q=oscar+casagrande",
                DataCriacao = new DateTime(2012, 6, 4, 16, 40, 40)
            };
            vo.Url urlGerada = new vo.Url();
            urlGerada = bo.Url.Obter("aaaa");

            TesteHelper.PropertyValuesAreEquals(urlEsperada, urlGerada);
        }
    }
}
