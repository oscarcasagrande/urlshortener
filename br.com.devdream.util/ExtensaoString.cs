using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace br.com.devdream.util
{
    public static class ExtensaoString
    {
        public static string AumentarUm(this string valor)
        {
            string resultado = string.Empty;

            string[] numeros = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };

            bool ehNumero = false;

            foreach (var item in numeros)
            {
                int valorInteiro = 0;

                if (item == valor)
                {
                    if (int.TryParse(item.ToString(), out valorInteiro))
                    {
                        resultado = Convert.ToString(valorInteiro + 1);
                    }
                    ehNumero = true;
                    break;
                }
            }

            if (ehNumero == false)
            {
                if (valor == "z")
                {
                    resultado = "A";
                }
                else if (valor == "Z")
                {
                    resultado = "0";
                }
                else
                {
                    int valorAscii = ConverterTextoParaAscii(valor);

                    valorAscii++;

                    resultado = ConverterAsciiParaTexto(valorAscii);
                }
            }

            return resultado;
        }

        private static string ConverterAsciiParaTexto(int valorAscii)
        {
            string resultado = string.Empty;

            resultado = Char.ConvertFromUtf32(valorAscii);

            return resultado;
        }

        private static int ConverterTextoParaAscii(string valor)
        {
            int resultado = 0;
            
            for (int i = 0; i < valor.Length; i++)
            {
                resultado = resultado + valor[i];
            }

            return resultado;
        }

        public static string TratarCaracteresEspeciais(this string valor)
        {
            string resultado = "";

            return resultado;
        }
    }
}
