using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NhamiBackEnd1.Code.AcessoBD;
using ClassesPartilhadas;

namespace NhamiBackEnd1.Code.AcessoBD
{
    public class Testar
    {
        public static string testarBD()
        {
            DAOGestaoUtilizadores gestUtil = new DAOGestaoUtilizadores();
            DAORestaurante restaurantes = new DAORestaurante();
            StringBuilder s = new StringBuilder();

            //---------------------------------------------------------------//
            string username = "jose", password = "cunha1234";
            Utilizador r = gestUtil.LoginUtilizador(username, password);
            if (r is Proprietario)
            {
                // usar a funca de marshalling override do priprietario
                //  r.funcaoToByte();
                s.Append("Sou o prop ");
            }else
                if (r is Cliente)
                    s.Append("sou  o cli");
                // usar a funca de marshalling override do priprietario
                // r.funcaoToByte();
                                    
            //---------------------------------------------------------------//
            List<Restaurante> rests =  restaurantes.PesquisaTipoCozinha(2);
            if (rests != null){ s.Append("Nr de Restaurantes = " + rests.Count); }
                else { s.Append("Sem restaurantes"); }
            //---------------------------------------------------------------/

            return s.ToString();
        }
    }
}
