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
                s.Append("Nome Proprietario: " + r.GetNome() + " | ");
                Proprietario p = (Proprietario) r; 
                List<Restaurante> l = p.GetRestaurantesProprietario();
                s.Append("Nome Restaurante : " + l[0].GetDesignacao() + " | ");
             }
             else
                 if (r is Cliente)
                 s.Append("Cliente encontrado | ");
                 // usar a funca de marshalling override do priprietario
                 // r.funcaoToByte();
                    else s.Append("Utilizador nao existente | ");
                    

            //---------------------------------------------------------------//
            List<Restaurante> rests =  restaurantes.PesquisaTipoCozinha(2);
            if (rests != null){ s.Append("Nr de Restaurantes = " + rests.Count + "| "); }
                else { s.Append("Sem restaurantes | "); }
            //---------------------------------------------------------------/

            return s.ToString();
        }
    }
}
