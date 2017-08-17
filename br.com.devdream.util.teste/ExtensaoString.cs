using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace br.com.devdream.util.teste
{
    [TestFixture]
    public static class ExtensaoString
    {
        [Test]
        public static void AumentarUm()
        {
            string caractereEsperado = "b";
            string caractereGerado = "a";

            caractereGerado = caractereGerado.AumentarUm();

            Assert.AreEqual(caractereEsperado, caractereGerado);
        }


        [Test]
        public static void TratarCaracteresEspeciais()
        {
        }
    }
}
