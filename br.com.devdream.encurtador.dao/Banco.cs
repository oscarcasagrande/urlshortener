using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace br.com.devdream.encurtador.dao
{
    public static class Banco
    {
        public static Database ObterBancoDeDados()
        {
            return DatabaseFactory.CreateDatabase("conexao");
        }
    }
}
