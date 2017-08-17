using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;

namespace br.com.devdream.encurtador.dao
{
    public static class Acesso
    {
        public static void Criar(vo.Url url, string ip)
        {
            Database database = Banco.ObterBancoDeDados();

            DbCommand command = database.GetStoredProcCommand("procAcesso_criar");

            database.AddInParameter(command, "chave", DbType.String, url.Chave);
            database.AddInParameter(command, "ip", DbType.String, ip);
            try
            {
                database.ExecuteNonQuery(command);
            }
            catch
            { }
        }

        public static bool ConsolidarAcessoTotal()
        {
            bool resultado = false;
            Database database = Banco.ObterBancoDeDados();

            try
            {
                DbCommand command = database.GetStoredProcCommand("procAcessoConsolidadoTotal_Criar");
                resultado = database.ExecuteNonQuery(command) > 0;
            }
            catch (Exception ex)
            {
            }
            return resultado;
        }

        public static bool ConsolidarAcessoMensal()
        {
            bool resultado = false;
            Database database = Banco.ObterBancoDeDados();

            try
            {
                DbCommand command = database.GetStoredProcCommand("procAcessoConsolidadoMensal_Criar");
                resultado = database.ExecuteNonQuery(command) > 0;
            }
            catch (Exception ex)
            {
            }
            return resultado;
        }
    }
}
