using System;
using br.com.devdream.util;
using System.Text.RegularExpressions;

namespace br.com.devdream.encurtador.bo
{
    public static class Url
    {
        public static string Criar(string endereco, string ip)
        {
            string resultado = string.Empty;

            bool enderecoValido = false;

            enderecoValido = ValidarEndereco(endereco);
            if (enderecoValido)
            {
                try
                {
                    if (Existe(endereco) == false)
                    {
                        string urlEncurtada = ObterChaveEncurtar();

                        vo.Url url = new vo.Url()
                        {
                            Chave = urlEncurtada,
                            Original = endereco,
                            Encurtada = urlEncurtada,
                            Ip = ip
                        };

                        if (br.com.devdream.encurtador.dao.Url.Criar(url))
                        {
                            resultado = urlEncurtada;
                        }
                    }
                    else
                    {
                        vo.Url url = dao.Url.ObterPorEndereco(endereco);
                        resultado = url.Encurtada;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Ocorreu um erro ao criar a URL", ex.InnerException);
                }
            }
            return resultado.Replace("http://localhost:56778/", "");
        }

        public static bool ValidarEndereco(string endereco)
        {
            if (!endereco.Contains("http://") && !endereco.Contains("ftp://"))
            {
                endereco = string.Format("http://{0}", endereco);
            }

            bool resultado = false;

            string padrao = @"^(http|https|ftp)\://[a-zA-Z0-9\-\.]+\.[a-zA-Z]{2,3}(:[a-zA-Z0-9]*)?/?([a-zA-Z0-9\-\._\?\,\'/\\\+&amp;%\$#\=~])*[^\.\,\)\(\s]$";
            Regex reg = new Regex(padrao, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            resultado = reg.IsMatch(endereco);

            return resultado;
        }

        private static string ObterChaveEncurtar()
        {
            string resultado = string.Empty;

            string ultimaChaveUrlEncurtada = string.Empty;

            ultimaChaveUrlEncurtada = br.com.devdream.encurtador.dao.Url.ObterChaveUltimaUrlEncurtada();

            if (ultimaChaveUrlEncurtada == string.Empty)
            {
                resultado = "aaaa";
            }
            else
            {
                string caractereUm = string.Empty;
                string caractereDois = string.Empty;
                string caractereTres = string.Empty;
                string caractereQuatro = string.Empty;

                short caractereEleito = 0;

                caractereEleito = ObterCaractereEleito(ultimaChaveUrlEncurtada, out caractereUm, out caractereDois, out caractereTres, out caractereQuatro);

                switch (caractereEleito)
                {
                    case 1:
                        resultado =
                            string.Format(
                                "{0}{1}{2}{3}",
                                caractereUm.AumentarUm(),
                                caractereDois,
                                caractereTres,
                                caractereQuatro);
                        break;
                    case 2:
                        resultado =
                            string.Format(
                                "{0}{1}{2}{3}",
                                caractereUm,
                                caractereDois.AumentarUm(),
                                caractereTres,
                                caractereQuatro);
                        break;
                    case 3:
                        resultado =
                            string.Format(
                                "{0}{1}{2}{3}",
                                caractereUm,
                                caractereDois,
                                caractereTres.AumentarUm(),
                                caractereQuatro);
                        break;
                    case 4:
                        resultado =
                            string.Format(
                                "{0}{1}{2}{3}",
                                caractereUm,
                                caractereDois,
                                caractereTres,
                                caractereQuatro.AumentarUm());
                        break;
                    default:
                        break;
                }
            }

            return resultado;
        }

        public static short ObterCaractereEleito(string ultimaChaveUrlEncurtada, out string caractereUm, out string caractereDois, out string caractereTres, out string caractereQuatro)
        {
            short caractereEleito = 0;

            caractereUm = ultimaChaveUrlEncurtada.Substring(0, 1);
            caractereDois = ultimaChaveUrlEncurtada.Substring(1, 1);
            caractereTres = ultimaChaveUrlEncurtada.Substring(2, 1);
            caractereQuatro = ultimaChaveUrlEncurtada.Substring(3, 1);


            if (caractereUm == "9" && caractereDois == "9" && caractereTres == "9" && caractereQuatro == "9")
            {
                throw new Exception("Ocorreu um erro ao gerar a chave da URL, não há mais possibilidades de chaves.");
            }
            else if (caractereUm != "9" && caractereDois == "9" && caractereTres == "9" && caractereQuatro == "9")
            {
                caractereEleito = 1;
                caractereDois = "a";
                caractereTres = "a";
                caractereQuatro = "a";
            }
            else if (caractereUm != "9" && caractereDois != "9" && caractereTres == "9" && caractereQuatro == "9")
            {
                caractereEleito = 2;
                caractereTres = "a";
                caractereQuatro = "a";
            }
            else if ((caractereUm != "9" && caractereDois != "9" && caractereTres != "9" && caractereQuatro == "9")
                || (caractereUm != "9" && caractereDois == "9" && caractereTres != "9" && caractereQuatro == "9"))
            {
                caractereEleito = 3;
                caractereQuatro = "a";
            }
            else if ((caractereUm != "9" && caractereDois != "9" && caractereTres != "9" && caractereQuatro != "9")
                || (caractereUm != "9" && caractereDois != "9" && caractereTres == "9")
                || (caractereQuatro != "9"))
            {
                caractereEleito = 4;
            }

            return caractereEleito;
        }

        public static bool Existe(string endereco)
        {
            bool resultado = false;

            try
            {
                vo.Url url = new vo.Url();
                url = br.com.devdream.encurtador.dao.Url.ObterPorEndereco(endereco);

                if (url.Chave != string.Empty)
                {
                    resultado = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu m erro ao consultar a URL", ex.InnerException);
            }

            return resultado;
        }

        public static br.com.devdream.encurtador.vo.Url Obter(string chave)
        {
            vo.Url resultado = new vo.Url();

            resultado = dao.Url.ObterPorChave(chave);

            return resultado;
        }

        public static void ContabilizarAcesso(vo.Url url, string ip)
        {
            dao.Acesso.Criar(url, ip);
        }
    }
}
