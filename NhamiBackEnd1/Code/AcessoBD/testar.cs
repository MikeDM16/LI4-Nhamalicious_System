using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NhamiBackEnd1.Code.AcessoBD
{
    class Testar
    {
        public static string testarBD()
        {
            DAOGestaoUtilizadores gestUtil = new DAOGestaoUtilizadores();
            DAORestaurante restaurantes = new DAORestaurante();
            StringBuilder s = new StringBuilder();

            string username = "joe", password = "cunha1234";
            Boolean r = gestUtil.loginProprietário(username, password);
            s.Append("Existe utilizador: " + r + "\n");

            restaurantes.pesquisaRestaurante(1);

            return s.ToString() ;
        }
    }
}
