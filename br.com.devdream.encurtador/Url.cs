using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace br.com.devdream.encurtador
{
    public class Url
    {
        public string Original { get; set; }
        public string Encurtada { get; set; }

        public static string EncurtarUrl(string url)
        {
            string resultado = string.Empty;

            resultado = "aaaa";

            if (!VerificarUrlJaFoiEncurtada(url))
            {
                if (!GravarUrl(resultado, url))
                {
                    throw new Exception("Ocorreu um erro na inserção de dados");
                }
            }

            return resultado;
        }

        private static bool GravarUrl(string resultado, string url)
        {
            throw new NotImplementedException();
        }

        private static bool VerificarUrlJaFoiEncurtada(string url)
        {
            bool resultado = false;

            try
            {

            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao verificar se a URL já havia sido encurtada.", ex.InnerException);
            }

            return resultado;
        }
    }
}
