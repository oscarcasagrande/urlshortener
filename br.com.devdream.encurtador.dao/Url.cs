using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.Common;

namespace br.com.devdream.encurtador.dao
{
    public class Url
    {
        public static bool Criar(vo.Url url)
        {
            bool resultado = false;

            Database database = Banco.ObterBancoDeDados();

            DbCommand command = database.GetStoredProcCommand("procUrl_criar");

            database.AddInParameter(command, "chave", DbType.String, url.Chave);
            database.AddInParameter(command, "endereco", DbType.String, url.Original);
            database.AddInParameter(command, "ip", DbType.String, url.Ip);

            if (database.ExecuteNonQuery(command) > 0)
                resultado = true;

            return resultado;
        }

        public static string ObterChaveUltimaUrlEncurtada()
        {
            string resultado = string.Empty;

            Database database = Banco.ObterBancoDeDados();

            DbCommand command = database.GetStoredProcCommand("procUrlUltima_ler");

            using (IDataReader reader = database.ExecuteReader(command))
            {
                if (reader.Read())
                {
                    resultado = Convert.ToString(reader["chave"]);
                }
            }
            return resultado;
        }

        public static br.com.devdream.encurtador.vo.Url ObterPorChave(string chave)
        {
            vo.Url resultado = new vo.Url();

            Database database = Banco.ObterBancoDeDados();

            DbCommand command = database.GetStoredProcCommand("procUrl_Ler");

            database.AddInParameter(command, "chave", DbType.String, chave);

            using (IDataReader reader = database.ExecuteReader(command))
            {
                if (reader.Read())
                {
                    resultado.Encurtada = Convert.ToString(reader["chave"]);
                    resultado.Original = Convert.ToString(reader["endereco"]);
                    resultado.DataCriacao = Convert.ToDateTime(Convert.ToString(reader["dataCriacao"]));
                    resultado.Chave = Convert.ToString(reader["chave"]);
                }
            }

            return resultado;
        }

        public static vo.Url ObterPorEndereco(string endereco)
        {
            vo.Url resultado = new vo.Url();

            Database database = Banco.ObterBancoDeDados();

            DbCommand command = database.GetStoredProcCommand("procUrlEndereco_Ler");

            database.AddInParameter(command, "endereco", DbType.String, endereco);

            using (IDataReader reader = database.ExecuteReader(command))
            {
                if (reader.Read())
                {
                    resultado.Chave = Convert.ToString(reader["chave"]);
                    resultado.Encurtada = Convert.ToString(reader["chave"]);
                    resultado.Original = Convert.ToString(reader["endereco"]);
                    resultado.DataCriacao = Convert.ToDateTime(Convert.ToString(reader["dataCriacao"]));
                }
            }

            return resultado;

        }
    }
}
