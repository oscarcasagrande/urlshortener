using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace br.com.devdream.encurtador.vo
{
    public class Url
    {
        public static string site = "http://localhost:56778/";
        public string Chave { get; set; }
        public DateTime DataCriacao { get; set; }
        public string Ip { get; set; }

        private string original = string.Empty;
        public string Original
        {
            get
            {
                if (!original.Contains("http://") && !original.Contains("ftp://"))
                {
                    return string.Format("http://{0}", original);
                }
                else
                {
                    return original;
                }
            }
            set
            {
                original = value;
            }
        }

        private string encurtada = string.Empty;
        public string Encurtada
        {
            get
            {
                if (!encurtada.Contains(site))
                {
                    return string.Format("{0}{1}", site, encurtada);
                }
                else
                {
                    return encurtada;
                }
            }
            set
            {
                encurtada = value;
            }
        }

        public Url()
        {
            Original = string.Empty;
            Encurtada = string.Empty;
            Ip = string.Empty;
            Chave = string.Empty;
        }
    }
}
