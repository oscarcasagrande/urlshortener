using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace br.com.devdream.encurtador.bo.teste
{
    public static class AcessoTeste
    {
        [Test]
        public static void ConsolidarAcessoMensal()
        {
            bool resultadoEsperado = true;
            bool resultadoGerado = false;

            resultadoGerado = bo.Acesso.ConsolidarAcessoMensal();

            Assert.AreEqual(resultadoEsperado, resultadoGerado);
        }

        [Test]
        public static void ConsolidarAcessoTotal()
        {
            bool resultadoEsperado = true;
            bool resultadoGerado = false;

            resultadoGerado = bo.Acesso.ConsolidarAcessoTotal();

            Assert.AreEqual(resultadoEsperado, resultadoGerado);
        }
    }
}
