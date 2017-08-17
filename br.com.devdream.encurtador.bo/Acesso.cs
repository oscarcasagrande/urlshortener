using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace br.com.devdream.encurtador.bo
{
    public static class Acesso
    {
        public static bool ConsolidarAcessoMensal()
        {
            bool resultado = false;

            resultado = dao.Acesso.ConsolidarAcessoMensal();

            return resultado;
        }

        public static bool ConsolidarAcessoTotal()
        {
            bool resultado = false;

            resultado = dao.Acesso.ConsolidarAcessoTotal();

            return resultado;
        }
    }
}
